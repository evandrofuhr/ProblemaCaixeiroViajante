using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCV.App
{
    public partial class FrmDetalhe : Form
    {
        private Calculo calculo;

        public FrmDetalhe()
        {
            InitializeComponent();
        }

        public void CarregaCalculo(Calculo calculo)
        {
            this.calculo = calculo;
            lbCalculo.Text = calculo.Codigo.ToString();
            lbTempo.Text = calculo.Milisegundos.ToString();
            lbTipo.Text = calculo.TipoCalculo.Descricao();
            lbMemoria.Text = Help.Memoria(calculo.CustoMemoria);
            lbCidade.Text = calculo.QuantidadeCidades.ToString();
            lbQtdCalculo.Text = calculo.PercursosCalculados.ToString();

            btnGrafico.Visible = calculo.TipoCalculo == Calculo.ETipoCalculo.Genetico;

            var row = 1;
            foreach (var item in calculo.MelhoresResultados)
            {
                dgvResultado.Rows.Add(row, item.MontaRotasArr(), item.distancia);
                row++;
            }
            AjustaTela();
        }

        private void AjustaTela()
        {
            for (int i = 0; i < dgvResultado.Columns.Count; i++)
            {
                dgvResultado.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
        }

        private void btnGrafico_Click(object sender, EventArgs e)
        {
            FrmGrafico frm = new FrmGrafico();
            frm.CarregaGrafico(calculo.GraficoGenetico);
            frm.ShowDialog();
        }
    }
}
