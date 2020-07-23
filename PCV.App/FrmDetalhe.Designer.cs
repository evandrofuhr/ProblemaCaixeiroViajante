namespace PCV.App
{
    partial class FrmDetalhe
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
            this.dgvResultado = new System.Windows.Forms.DataGridView();
            this.Posicao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Distancia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.lbCalculo = new System.Windows.Forms.Label();
            this.lbTempo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbTipo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbMemoria = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbCidade = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbQtdCalculo = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnGrafico = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultado)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvResultado
            // 
            this.dgvResultado.AllowUserToAddRows = false;
            this.dgvResultado.AllowUserToDeleteRows = false;
            this.dgvResultado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Posicao,
            this.Rota,
            this.Distancia});
            this.dgvResultado.Location = new System.Drawing.Point(12, 82);
            this.dgvResultado.Name = "dgvResultado";
            this.dgvResultado.Size = new System.Drawing.Size(770, 259);
            this.dgvResultado.TabIndex = 0;
            // 
            // Posicao
            // 
            this.Posicao.HeaderText = "Posição";
            this.Posicao.Name = "Posicao";
            this.Posicao.ReadOnly = true;
            // 
            // Rota
            // 
            this.Rota.HeaderText = "Rota";
            this.Rota.Name = "Rota";
            this.Rota.ReadOnly = true;
            this.Rota.Width = 600;
            // 
            // Distancia
            // 
            this.Distancia.HeaderText = "Distância";
            this.Distancia.Name = "Distancia";
            this.Distancia.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cálculo";
            // 
            // lbCalculo
            // 
            this.lbCalculo.AutoSize = true;
            this.lbCalculo.Location = new System.Drawing.Point(86, 9);
            this.lbCalculo.Name = "lbCalculo";
            this.lbCalculo.Size = new System.Drawing.Size(42, 13);
            this.lbCalculo.TabIndex = 2;
            this.lbCalculo.Text = "Cálculo";
            // 
            // lbTempo
            // 
            this.lbTempo.AutoSize = true;
            this.lbTempo.Location = new System.Drawing.Point(86, 31);
            this.lbTempo.Name = "lbTempo";
            this.lbTempo.Size = new System.Drawing.Size(40, 13);
            this.lbTempo.TabIndex = 4;
            this.lbTempo.Text = "Tempo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tempo(ms)";
            // 
            // lbTipo
            // 
            this.lbTipo.AutoSize = true;
            this.lbTipo.Location = new System.Drawing.Point(86, 56);
            this.lbTipo.Name = "lbTipo";
            this.lbTipo.Size = new System.Drawing.Size(28, 13);
            this.lbTipo.TabIndex = 6;
            this.lbTipo.Text = "Tipo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Tipo";
            // 
            // lbMemoria
            // 
            this.lbMemoria.AutoSize = true;
            this.lbMemoria.Location = new System.Drawing.Point(310, 9);
            this.lbMemoria.Name = "lbMemoria";
            this.lbMemoria.Size = new System.Drawing.Size(47, 13);
            this.lbMemoria.TabIndex = 8;
            this.lbMemoria.Text = "Memoria";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(225, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Uso memória";
            // 
            // lbCidade
            // 
            this.lbCidade.AutoSize = true;
            this.lbCidade.Location = new System.Drawing.Point(310, 31);
            this.lbCidade.Name = "lbCidade";
            this.lbCidade.Size = new System.Drawing.Size(45, 13);
            this.lbCidade.TabIndex = 10;
            this.lbCidade.Text = "Cidades";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(225, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Cidades";
            // 
            // lbQtdCalculo
            // 
            this.lbQtdCalculo.AutoSize = true;
            this.lbQtdCalculo.Location = new System.Drawing.Point(310, 56);
            this.lbQtdCalculo.Name = "lbQtdCalculo";
            this.lbQtdCalculo.Size = new System.Drawing.Size(64, 13);
            this.lbQtdCalculo.TabIndex = 12;
            this.lbQtdCalculo.Text = "Qtd. calculo";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(225, 56);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "Qtd. cálculo";
            // 
            // btnGrafico
            // 
            this.btnGrafico.Location = new System.Drawing.Point(707, 51);
            this.btnGrafico.Name = "btnGrafico";
            this.btnGrafico.Size = new System.Drawing.Size(75, 23);
            this.btnGrafico.TabIndex = 13;
            this.btnGrafico.Text = "Gráfico";
            this.btnGrafico.UseVisualStyleBackColor = true;
            this.btnGrafico.Click += new System.EventHandler(this.btnGrafico_Click);
            // 
            // FrmDetalhe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 353);
            this.Controls.Add(this.btnGrafico);
            this.Controls.Add(this.lbQtdCalculo);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lbCidade);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lbMemoria);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbTipo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbTempo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbCalculo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvResultado);
            this.Name = "FrmDetalhe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PCV - SI - FTEC [Dados cálculo]";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvResultado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbCalculo;
        private System.Windows.Forms.Label lbTempo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbTipo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbMemoria;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbCidade;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbQtdCalculo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Posicao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rota;
        private System.Windows.Forms.DataGridViewTextBoxColumn Distancia;
        private System.Windows.Forms.Button btnGrafico;
    }
}