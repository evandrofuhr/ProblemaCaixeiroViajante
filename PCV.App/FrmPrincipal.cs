using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCV.App
{
    public partial class FrmPrincipal : Form
    {
        private List<Cidade> distancias;
        private int codigo;
        private Calculo calculo;

        public FrmPrincipal()
        {
            InitializeComponent();
        }
        

        private void dgvCidades_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    dgvCidades.Rows.RemoveAt(dgvCidades.SelectedCells[0].RowIndex);
                }
            }
            catch
            {

            }
        }

        private void atualizaPossibilidades()
        {
            lPossibilidades.Text = string.Format("Fatorial : {0}", MathNet.Numerics.SpecialFunctions.Factorial(distancias.Count - 1));
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if ((distancias != null) && (distancias.Count > 0))
            {
                if (MessageBox.Show("Deseja apagar as distâncias existentes?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dgvDistancia.Rows.Clear();
                }
            }

            distancias.Clear();
            var posicao = 0;

            for (int i = 0; i < dgvCidades.RowCount-1; i++)
            {
                var nome = dgvCidades.Rows[i].Cells[0].Value.ToString().Trim().ToUpper();
                if (!string.IsNullOrEmpty(nome))
                {
                    if (distancias.Where(w => w.Nome.Equals(nome)).Count() == 0)
                    {
                        distancias.Add(new Cidade(nome, posicao));
                        posicao++;
                    }
                }
            }

            if (distancias.Count == 0)
                return;

            dgvCidades.Rows.Clear();

            var combinacoes = new List<string>();
            for (int i = 0; i < dgvDistancia.RowCount; i++)
            {
                combinacoes.Add(
                    string.Format(
                        "{0}{1}",
                        dgvDistancia.Rows[i].Cells[0].Value.ToString().Trim().ToUpper(),
                        dgvDistancia.Rows[i].Cells[1].Value.ToString().Trim().ToUpper()
                    )
                );
            }

            foreach (var item in distancias)
            {
                dgvCidades.Rows.Add(item.Nome);

                foreach (var cidade in distancias)
                {
                    if (item.Nome.Equals(cidade.Nome))
                        continue;

                    var existe = false;
                    for (int i = 0; i < dgvDistancia.RowCount; i++)
                    {
                        if ((dgvDistancia.Rows[i].Cells[0].Value.ToString().Trim().ToUpper().Equals(item.Nome)) &&
                            (dgvDistancia.Rows[i].Cells[1].Value.ToString().Trim().ToUpper().Equals(cidade.Nome)))
                        {
                            existe = true;
                            dgvDistancia.Rows[i].Cells[3].Value = item.Posicao;
                            dgvDistancia.Rows[i].Cells[4].Value = cidade.Posicao;
                        }
                    }

                    if ((item.cidades.Where(w => w.Nome.Equals(cidade.Nome)).FirstOrDefault() == null) &&
                        (cidade.cidades.Where(w => w.Nome.Equals(item.Nome)).FirstOrDefault() == null))
                           item.cidades.Add(new Cidade(cidade.Nome, cidade.Posicao));

                    if ((combinacoes.IndexOf(string.Format("{0}{1}", item.Nome, cidade.Nome)) >= 0) ||
                        (combinacoes.IndexOf(string.Format("{0}{1}", cidade.Nome, item.Nome)) >= 0))
                        continue;

                    if (!existe) {
                        dgvDistancia.Rows.Add(item.Nome, cidade.Nome, 0, item.Posicao, cidade.Posicao);
                        combinacoes.Add(string.Format("{0}{1}", item.Nome, cidade.Nome));
                    }

                }
            }

            atualizaPossibilidades();
            AjustaColunas();
        }

        private void btnCalcularRota_Click(object sender, EventArgs e)
        {
            Help.tabelaDistancias = new Hashtable();
            if (!backgroundWorker1.IsBusy)
            {
                
                for (int j = 0; j < dgvDistancia.RowCount; j++)
                {
                    var nomeOrigem = dgvDistancia.Rows[j].Cells[0].Value.ToString().Trim().ToUpper();
                    var nomeDestino = dgvDistancia.Rows[j].Cells[1].Value.ToString().Trim().ToUpper();
                            
                    var posicaoOrigem = dgvDistancia.Rows[j].Cells[3].Value.ToString().Trim().ToUpper();
                    var posicaoDestino = dgvDistancia.Rows[j].Cells[4].Value.ToString().Trim().ToUpper();

                    var cid = distancias.Where(w => w.Nome.Equals(nomeOrigem)).FirstOrDefault().cidades.Where(w=>w.Nome.Equals(nomeDestino)).FirstOrDefault();
                    
                    if (cid != null)
                        cid.Distancia = int.Parse(dgvDistancia.Rows[j].Cells[2].Value.ToString().Trim().ToUpper());

                    if (!Help.tabelaDistancias.Contains(string.Format("{0}{1}", posicaoOrigem, posicaoDestino)))
                        Help.tabelaDistancias.Add(string.Format("{0}{1}", posicaoOrigem, posicaoDestino), int.Parse(dgvDistancia.Rows[j].Cells[2].Value.ToString().Trim().ToUpper()));

                    if (!Help.tabelaDistancias.Contains(string.Format("{0}{1}", posicaoDestino, posicaoOrigem)))
                        Help.tabelaDistancias.Add(string.Format("{0}{1}", posicaoDestino, posicaoOrigem), int.Parse(dgvDistancia.Rows[j].Cells[2].Value.ToString().Trim().ToUpper()));
                }

                var json = JsonConvert.SerializeObject(distancias);
                File.WriteAllText("rotas.json", json);
                
                dgvCalculo.Enabled = false;
                dgvDistancia.Enabled = false;
                dgvCidades.Enabled = false;
                btnCalcular.Enabled = false;
                btnCalcularRota.Enabled = false;

                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Help.cidades = distancias;
            calculo = new Calculo() { QuantidadeResultados = int.Parse(txtTopRotas.Text) };
            if (rbForcaBruta.Checked)
                calculo.TipoCalculo = Calculo.ETipoCalculo.ForcaBruta;
            if (rbVizinho.Checked)
                calculo.TipoCalculo = Calculo.ETipoCalculo.Vizinho;
            /*if (rbForcaBrutaNovo.Checked)
            {
                calculo.TipoCalculo = Calculo.ETipoCalculo.ForcaBrutaNovo;
                calculo.Inicial = 0;
                calculo.Final = 0;         
            }*/

            if (rbGenetico.Checked)
            {
                calculo.TipoCalculo = Calculo.ETipoCalculo.Genetico;
                calculo.PopulacaoInicial = int.Parse(txtPopulacaoInicial.Text);
                calculo.QuantidadeReproducoes = int.Parse(txtQtdReproducao.Text);
            }

            calculo.Calcular();

            var json = JsonConvert.SerializeObject(
                new
                {
                    TipoCalculo = (int)calculo.TipoCalculo,
                    Registros = txtTopRotas.Text,
                    Populacao = txtPopulacaoInicial.Text,
                    Reproducao = txtQtdReproducao.Text
                }
            );

            File.WriteAllText("config.json", json);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            codigo++;
            var row = dgvCalculo.Rows.Add(codigo, calculo.TipoCalculo.Descricao());
            calculo.Codigo = codigo;
            dgvCalculo.Rows[row].Tag = calculo;

            dgvCalculo.Enabled = true;
            dgvDistancia.Enabled = true;
            dgvCidades.Enabled = true;
            btnCalcular.Enabled = true;
            btnCalcularRota.Enabled = true;
            AjustaColunas();
        }

        private void dgvCalculo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbMemoria.Text = string.Format("Memória: {0}",Help.Memoria(Process.GetCurrentProcess().WorkingSet64));
        }

        private void dgvCalculo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FrmDetalhe frm = new FrmDetalhe();
            frm.CarregaCalculo(((Calculo)dgvCalculo.Rows[dgvCalculo.SelectedCells[0].RowIndex].Tag));
            frm.ShowDialog();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            distancias = new List<Cidade>();
            if (File.Exists("rotas.json"))
            {
                var json = File.ReadAllText("rotas.json");
                distancias = JsonConvert.DeserializeObject<List<Cidade>>(json);

                foreach (var item in distancias.OrderBy(o=>o.Posicao).ToList())
                {
                    dgvCidades.Rows.Add(item.Nome);
                    foreach (var cidade in item.cidades)
                    {
                        dgvDistancia.Rows.Add(item.Nome, cidade.Nome, cidade.Distancia,item.Posicao,cidade.Posicao);
                    }
                }
                atualizaPossibilidades();
            }

            if (File.Exists("config.json"))
            {
                var json = File.ReadAllText("config.json");

                var objAnonimo = 
                    new
                    {
                        TipoCalculo = 0,
                        Registros = string.Empty,
                        Populacao = string.Empty,
                        Reproducao = string.Empty
                    };
                var obj = JsonConvert.DeserializeAnonymousType(json, objAnonimo);

                switch ((Calculo.ETipoCalculo)obj.TipoCalculo)
                {
                    case Calculo.ETipoCalculo.ForcaBruta:
                        rbForcaBruta.Checked = true;
                        break;
                    case Calculo.ETipoCalculo.Vizinho:
                        rbVizinho.Checked = true;
                        break;
                    case Calculo.ETipoCalculo.ForcaBrutaNovo:
                        break;
                    case Calculo.ETipoCalculo.Genetico:
                        rbGenetico.Checked = true;
                        break;
                    default:
                        break;
                }

                txtTopRotas.Text = obj.Registros;
                txtPopulacaoInicial.Text = obj.Populacao;
                txtQtdReproducao.Text = obj.Reproducao;
            }

            AjustaColunas();
            AtivaControles();
        }

        private void dgvCidades_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            gbCidade.Text = string.Format("Cidades ({0})", dgvCidades.RowCount-1);
        }

        private void dgvCidades_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            gbCidade.Text = string.Format("Cidades ({0})", dgvCidades.RowCount - 1);
        }

        private void dgvDistancia_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            gbDistancia.Text = string.Format("Distâncias ({0})", dgvDistancia.RowCount);
        }

        private void dgvDistancia_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            gbDistancia.Text = string.Format("Distâncias ({0})", dgvDistancia.RowCount);
        }

        private void dgvDistancia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AjustaColunas()
        {
            for (int i = 0; i < dgvCidades.Columns.Count; i++)
            {
                dgvCidades.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }

            for (int i = 0; i < dgvDistancia.Columns.Count; i++)
            {
                dgvDistancia.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }

            for (int i = 0; i < dgvCalculo.Columns.Count; i++)
            {
                dgvCalculo.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }

        }

        private void rbGenetico_CheckedChanged(object sender, EventArgs e)
        {
            AtivaControles();
        }

        private void AtivaControles()
        {
            txtPopulacaoInicial.Enabled = rbGenetico.Checked;
            txtQtdReproducao.Enabled = rbGenetico.Checked;
            txtTopRotas.Enabled = !rbVizinho.Checked;
        }

        private void rbForcaBruta_CheckedChanged(object sender, EventArgs e)
        {
            AtivaControles();
        }

        private void rbVizinho_CheckedChanged(object sender, EventArgs e)
        {
            AtivaControles();
        }
    }
}
