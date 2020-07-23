namespace PCV.App
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gbTipo = new System.Windows.Forms.GroupBox();
            this.rbGenetico = new System.Windows.Forms.RadioButton();
            this.rbVizinho = new System.Windows.Forms.RadioButton();
            this.rbForcaBruta = new System.Windows.Forms.RadioButton();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.btnCalcularRota = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.gbDistancia = new System.Windows.Forms.GroupBox();
            this.dgvDistancia = new System.Windows.Forms.DataGridView();
            this.Origem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Destino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Distancia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PosicaoOrigem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PosicaoDestino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbResultado = new System.Windows.Forms.GroupBox();
            this.dgvCalculo = new System.Windows.Forms.DataGridView();
            this.CodigoCalculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbCidade = new System.Windows.Forms.GroupBox();
            this.dgvCidades = new System.Windows.Forms.DataGridView();
            this.Cidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTopRotas = new System.Windows.Forms.TextBox();
            this.lbQtdRegistros = new System.Windows.Forms.Label();
            this.lbPopulacao = new System.Windows.Forms.Label();
            this.txtPopulacaoInicial = new System.Windows.Forms.TextBox();
            this.lblQtdReproducao = new System.Windows.Forms.Label();
            this.txtQtdReproducao = new System.Windows.Forms.TextBox();
            this.lPossibilidades = new System.Windows.Forms.Label();
            this.lbMemoria = new System.Windows.Forms.Label();
            this.gbTipo.SuspendLayout();
            this.gbDistancia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDistancia)).BeginInit();
            this.gbResultado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalculo)).BeginInit();
            this.gbCidade.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCidades)).BeginInit();
            this.SuspendLayout();
            // 
            // gbTipo
            // 
            this.gbTipo.Controls.Add(this.rbGenetico);
            this.gbTipo.Controls.Add(this.rbVizinho);
            this.gbTipo.Controls.Add(this.rbForcaBruta);
            this.gbTipo.Location = new System.Drawing.Point(279, 13);
            this.gbTipo.Name = "gbTipo";
            this.gbTipo.Size = new System.Drawing.Size(197, 88);
            this.gbTipo.TabIndex = 0;
            this.gbTipo.TabStop = false;
            this.gbTipo.Text = "Tipo de cálculo";
            // 
            // rbGenetico
            // 
            this.rbGenetico.AutoSize = true;
            this.rbGenetico.Location = new System.Drawing.Point(20, 63);
            this.rbGenetico.Name = "rbGenetico";
            this.rbGenetico.Size = new System.Drawing.Size(68, 17);
            this.rbGenetico.TabIndex = 7;
            this.rbGenetico.TabStop = true;
            this.rbGenetico.Text = "Genético";
            this.rbGenetico.UseVisualStyleBackColor = true;
            this.rbGenetico.CheckedChanged += new System.EventHandler(this.rbGenetico_CheckedChanged);
            // 
            // rbVizinho
            // 
            this.rbVizinho.AutoSize = true;
            this.rbVizinho.Location = new System.Drawing.Point(20, 40);
            this.rbVizinho.Name = "rbVizinho";
            this.rbVizinho.Size = new System.Drawing.Size(122, 17);
            this.rbVizinho.TabIndex = 2;
            this.rbVizinho.TabStop = true;
            this.rbVizinho.Text = "Vizinho mais próximo";
            this.rbVizinho.UseVisualStyleBackColor = true;
            this.rbVizinho.CheckedChanged += new System.EventHandler(this.rbVizinho_CheckedChanged);
            // 
            // rbForcaBruta
            // 
            this.rbForcaBruta.AutoSize = true;
            this.rbForcaBruta.Location = new System.Drawing.Point(20, 17);
            this.rbForcaBruta.Name = "rbForcaBruta";
            this.rbForcaBruta.Size = new System.Drawing.Size(79, 17);
            this.rbForcaBruta.TabIndex = 0;
            this.rbForcaBruta.TabStop = true;
            this.rbForcaBruta.Text = "Força-bruta";
            this.rbForcaBruta.UseVisualStyleBackColor = true;
            this.rbForcaBruta.CheckedChanged += new System.EventHandler(this.rbForcaBruta_CheckedChanged);
            // 
            // btnCalcular
            // 
            this.btnCalcular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCalcular.Location = new System.Drawing.Point(421, 129);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(111, 23);
            this.btnCalcular.TabIndex = 2;
            this.btnCalcular.Text = "Gerar combinações";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // btnCalcularRota
            // 
            this.btnCalcularRota.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCalcularRota.Location = new System.Drawing.Point(539, 129);
            this.btnCalcularRota.Name = "btnCalcularRota";
            this.btnCalcularRota.Size = new System.Drawing.Size(75, 23);
            this.btnCalcularRota.TabIndex = 4;
            this.btnCalcularRota.Text = "Calcular";
            this.btnCalcularRota.UseVisualStyleBackColor = true;
            this.btnCalcularRota.Click += new System.EventHandler(this.btnCalcularRota_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // gbDistancia
            // 
            this.gbDistancia.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDistancia.Controls.Add(this.dgvDistancia);
            this.gbDistancia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDistancia.Location = new System.Drawing.Point(12, 155);
            this.gbDistancia.Name = "gbDistancia";
            this.gbDistancia.Size = new System.Drawing.Size(608, 301);
            this.gbDistancia.TabIndex = 8;
            this.gbDistancia.TabStop = false;
            this.gbDistancia.Text = "Distâncias";
            // 
            // dgvDistancia
            // 
            this.dgvDistancia.AllowUserToAddRows = false;
            this.dgvDistancia.AllowUserToDeleteRows = false;
            this.dgvDistancia.AllowUserToResizeRows = false;
            this.dgvDistancia.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDistancia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDistancia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Origem,
            this.Destino,
            this.Distancia,
            this.PosicaoOrigem,
            this.PosicaoDestino});
            this.dgvDistancia.Location = new System.Drawing.Point(6, 16);
            this.dgvDistancia.MultiSelect = false;
            this.dgvDistancia.Name = "dgvDistancia";
            this.dgvDistancia.Size = new System.Drawing.Size(596, 265);
            this.dgvDistancia.TabIndex = 4;
            this.dgvDistancia.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDistancia_CellContentClick);
            this.dgvDistancia.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvDistancia_RowsAdded);
            this.dgvDistancia.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvDistancia_RowsRemoved);
            // 
            // Origem
            // 
            this.Origem.HeaderText = "Origem";
            this.Origem.Name = "Origem";
            this.Origem.ReadOnly = true;
            // 
            // Destino
            // 
            this.Destino.HeaderText = "Destino";
            this.Destino.Name = "Destino";
            this.Destino.ReadOnly = true;
            // 
            // Distancia
            // 
            this.Distancia.HeaderText = "Distância";
            this.Distancia.Name = "Distancia";
            // 
            // PosicaoOrigem
            // 
            this.PosicaoOrigem.HeaderText = "PosicaoOrigem";
            this.PosicaoOrigem.Name = "PosicaoOrigem";
            this.PosicaoOrigem.Visible = false;
            // 
            // PosicaoDestino
            // 
            this.PosicaoDestino.HeaderText = "PosicaoDestino";
            this.PosicaoDestino.Name = "PosicaoDestino";
            this.PosicaoDestino.Visible = false;
            // 
            // gbResultado
            // 
            this.gbResultado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbResultado.Controls.Add(this.dgvCalculo);
            this.gbResultado.Location = new System.Drawing.Point(620, 13);
            this.gbResultado.Name = "gbResultado";
            this.gbResultado.Size = new System.Drawing.Size(261, 443);
            this.gbResultado.TabIndex = 9;
            this.gbResultado.TabStop = false;
            this.gbResultado.Text = "Resultados";
            // 
            // dgvCalculo
            // 
            this.dgvCalculo.AllowUserToAddRows = false;
            this.dgvCalculo.AllowUserToDeleteRows = false;
            this.dgvCalculo.AllowUserToResizeRows = false;
            this.dgvCalculo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCalculo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCalculo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodigoCalculo,
            this.Tipo});
            this.dgvCalculo.Location = new System.Drawing.Point(6, 14);
            this.dgvCalculo.Name = "dgvCalculo";
            this.dgvCalculo.Size = new System.Drawing.Size(249, 423);
            this.dgvCalculo.TabIndex = 7;
            this.dgvCalculo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvCalculo_MouseDoubleClick);
            // 
            // CodigoCalculo
            // 
            this.CodigoCalculo.HeaderText = "Cód. calc.";
            this.CodigoCalculo.Name = "CodigoCalculo";
            this.CodigoCalculo.ReadOnly = true;
            // 
            // Tipo
            // 
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            // 
            // gbCidade
            // 
            this.gbCidade.Controls.Add(this.dgvCidades);
            this.gbCidade.Location = new System.Drawing.Point(12, 12);
            this.gbCidade.Name = "gbCidade";
            this.gbCidade.Size = new System.Drawing.Size(261, 137);
            this.gbCidade.TabIndex = 10;
            this.gbCidade.TabStop = false;
            this.gbCidade.Text = "Cidades";
            // 
            // dgvCidades
            // 
            this.dgvCidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCidades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cidade});
            this.dgvCidades.Location = new System.Drawing.Point(6, 19);
            this.dgvCidades.Name = "dgvCidades";
            this.dgvCidades.Size = new System.Drawing.Size(249, 112);
            this.dgvCidades.TabIndex = 11;
            this.dgvCidades.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvCidades_RowsAdded);
            this.dgvCidades.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvCidades_RowsRemoved);
            this.dgvCidades.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvCidades_KeyDown);
            // 
            // Cidade
            // 
            this.Cidade.HeaderText = "Cidade";
            this.Cidade.Name = "Cidade";
            // 
            // txtTopRotas
            // 
            this.txtTopRotas.Location = new System.Drawing.Point(577, 13);
            this.txtTopRotas.Name = "txtTopRotas";
            this.txtTopRotas.Size = new System.Drawing.Size(37, 20);
            this.txtTopRotas.TabIndex = 11;
            this.txtTopRotas.Text = "5";
            // 
            // lbQtdRegistros
            // 
            this.lbQtdRegistros.AutoSize = true;
            this.lbQtdRegistros.Location = new System.Drawing.Point(502, 16);
            this.lbQtdRegistros.Name = "lbQtdRegistros";
            this.lbQtdRegistros.Size = new System.Drawing.Size(69, 13);
            this.lbQtdRegistros.TabIndex = 12;
            this.lbQtdRegistros.Text = "Qtd. registros";
            // 
            // lbPopulacao
            // 
            this.lbPopulacao.AutoSize = true;
            this.lbPopulacao.Location = new System.Drawing.Point(484, 42);
            this.lbPopulacao.Name = "lbPopulacao";
            this.lbPopulacao.Size = new System.Drawing.Size(87, 13);
            this.lbPopulacao.TabIndex = 14;
            this.lbPopulacao.Text = "População inicial";
            // 
            // txtPopulacaoInicial
            // 
            this.txtPopulacaoInicial.Location = new System.Drawing.Point(577, 39);
            this.txtPopulacaoInicial.Name = "txtPopulacaoInicial";
            this.txtPopulacaoInicial.Size = new System.Drawing.Size(37, 20);
            this.txtPopulacaoInicial.TabIndex = 13;
            this.txtPopulacaoInicial.Text = "100";
            // 
            // lblQtdReproducao
            // 
            this.lblQtdReproducao.AutoSize = true;
            this.lblQtdReproducao.Location = new System.Drawing.Point(482, 68);
            this.lblQtdReproducao.Name = "lblQtdReproducao";
            this.lblQtdReproducao.Size = new System.Drawing.Size(89, 13);
            this.lblQtdReproducao.TabIndex = 16;
            this.lblQtdReproducao.Text = "Qtd. reproduções";
            // 
            // txtQtdReproducao
            // 
            this.txtQtdReproducao.Location = new System.Drawing.Point(577, 65);
            this.txtQtdReproducao.Name = "txtQtdReproducao";
            this.txtQtdReproducao.Size = new System.Drawing.Size(37, 20);
            this.txtQtdReproducao.TabIndex = 15;
            this.txtQtdReproducao.Text = "1000";
            // 
            // lPossibilidades
            // 
            this.lPossibilidades.AutoSize = true;
            this.lPossibilidades.Location = new System.Drawing.Point(279, 104);
            this.lPossibilidades.Name = "lPossibilidades";
            this.lPossibilidades.Size = new System.Drawing.Size(34, 13);
            this.lPossibilidades.TabIndex = 17;
            this.lPossibilidades.Text = "Total:";
            // 
            // lbMemoria
            // 
            this.lbMemoria.AutoSize = true;
            this.lbMemoria.Location = new System.Drawing.Point(279, 134);
            this.lbMemoria.Name = "lbMemoria";
            this.lbMemoria.Size = new System.Drawing.Size(46, 13);
            this.lbMemoria.TabIndex = 7;
            this.lbMemoria.Text = "memória";
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 468);
            this.Controls.Add(this.lPossibilidades);
            this.Controls.Add(this.lblQtdReproducao);
            this.Controls.Add(this.txtQtdReproducao);
            this.Controls.Add(this.lbPopulacao);
            this.Controls.Add(this.txtPopulacaoInicial);
            this.Controls.Add(this.lbQtdRegistros);
            this.Controls.Add(this.txtTopRotas);
            this.Controls.Add(this.gbCidade);
            this.Controls.Add(this.gbResultado);
            this.Controls.Add(this.gbDistancia);
            this.Controls.Add(this.lbMemoria);
            this.Controls.Add(this.btnCalcularRota);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.gbTipo);
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PCV - SI - FTEC";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.gbTipo.ResumeLayout(false);
            this.gbTipo.PerformLayout();
            this.gbDistancia.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDistancia)).EndInit();
            this.gbResultado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalculo)).EndInit();
            this.gbCidade.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCidades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbTipo;
        private System.Windows.Forms.RadioButton rbForcaBruta;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Button btnCalcularRota;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RadioButton rbVizinho;
        private System.Windows.Forms.GroupBox gbDistancia;
        private System.Windows.Forms.DataGridView dgvDistancia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Origem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Destino;
        private System.Windows.Forms.DataGridViewTextBoxColumn Distancia;
        private System.Windows.Forms.GroupBox gbResultado;
        private System.Windows.Forms.DataGridView dgvCalculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoCalculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.GroupBox gbCidade;
        private System.Windows.Forms.DataGridView dgvCidades;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cidade;
        private System.Windows.Forms.RadioButton rbGenetico;
        private System.Windows.Forms.DataGridViewTextBoxColumn PosicaoOrigem;
        private System.Windows.Forms.DataGridViewTextBoxColumn PosicaoDestino;
        private System.Windows.Forms.TextBox txtTopRotas;
        private System.Windows.Forms.Label lbQtdRegistros;
        private System.Windows.Forms.Label lbPopulacao;
        private System.Windows.Forms.TextBox txtPopulacaoInicial;
        private System.Windows.Forms.Label lblQtdReproducao;
        private System.Windows.Forms.TextBox txtQtdReproducao;
        private System.Windows.Forms.Label lPossibilidades;
        private System.Windows.Forms.Label lbMemoria;
    }
}

