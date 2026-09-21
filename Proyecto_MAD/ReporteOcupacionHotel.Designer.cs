namespace Proyecto_MAD
{
    partial class ReporteOcupacionHotel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteOcupacionHotel));
            this.button4 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnFiltrarHot = new System.Windows.Forms.Button();
            this.GrdReporte2 = new System.Windows.Forms.DataGridView();
            this.GrdReporte1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.ComBoxCiudad = new System.Windows.Forms.ComboBox();
            this.ComBoxPais = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BoxYears = new System.Windows.Forms.ComboBox();
            this.BoxHoteles = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.GrdReporte2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdReporte1)).BeginInit();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Gainsboro;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Location = new System.Drawing.Point(1034, 815);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(114, 23);
            this.button4.TabIndex = 8;
            this.button4.Text = "Regresar";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(25, 22);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 17);
            this.label4.TabIndex = 79;
            this.label4.Text = "Hotel";
            // 
            // btnFiltrarHot
            // 
            this.btnFiltrarHot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrarHot.Location = new System.Drawing.Point(742, 38);
            this.btnFiltrarHot.Margin = new System.Windows.Forms.Padding(4);
            this.btnFiltrarHot.Name = "btnFiltrarHot";
            this.btnFiltrarHot.Size = new System.Drawing.Size(100, 28);
            this.btnFiltrarHot.TabIndex = 5;
            this.btnFiltrarHot.Text = "Filtrar";
            this.btnFiltrarHot.UseVisualStyleBackColor = true;
            this.btnFiltrarHot.Click += new System.EventHandler(this.btnFiltrarHot_Click);
            // 
            // GrdReporte2
            // 
            this.GrdReporte2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdReporte2.Location = new System.Drawing.Point(28, 485);
            this.GrdReporte2.Margin = new System.Windows.Forms.Padding(4);
            this.GrdReporte2.MultiSelect = false;
            this.GrdReporte2.Name = "GrdReporte2";
            this.GrdReporte2.ReadOnly = true;
            this.GrdReporte2.RowHeadersWidth = 51;
            this.GrdReporte2.Size = new System.Drawing.Size(829, 353);
            this.GrdReporte2.StandardTab = true;
            this.GrdReporte2.TabIndex = 7;
            // 
            // GrdReporte1
            // 
            this.GrdReporte1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdReporte1.Location = new System.Drawing.Point(28, 93);
            this.GrdReporte1.Margin = new System.Windows.Forms.Padding(4);
            this.GrdReporte1.MultiSelect = false;
            this.GrdReporte1.Name = "GrdReporte1";
            this.GrdReporte1.ReadOnly = true;
            this.GrdReporte1.RowHeadersWidth = 51;
            this.GrdReporte1.Size = new System.Drawing.Size(1120, 367);
            this.GrdReporte1.StandardTab = true;
            this.GrdReporte1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(230, 19);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 17);
            this.label2.TabIndex = 85;
            this.label2.Text = "Año";
            // 
            // ComBoxCiudad
            // 
            this.ComBoxCiudad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComBoxCiudad.FormattingEnabled = true;
            this.ComBoxCiudad.Location = new System.Drawing.Point(546, 42);
            this.ComBoxCiudad.Name = "ComBoxCiudad";
            this.ComBoxCiudad.Size = new System.Drawing.Size(170, 24);
            this.ComBoxCiudad.TabIndex = 4;
            // 
            // ComBoxPais
            // 
            this.ComBoxPais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComBoxPais.FormattingEnabled = true;
            this.ComBoxPais.Location = new System.Drawing.Point(383, 42);
            this.ComBoxPais.Name = "ComBoxPais";
            this.ComBoxPais.Size = new System.Drawing.Size(145, 24);
            this.ComBoxPais.TabIndex = 3;
            this.ComBoxPais.SelectedIndexChanged += new System.EventHandler(this.cbPaises_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(380, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 18);
            this.label1.TabIndex = 95;
            this.label1.Text = "País:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(543, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 18);
            this.label3.TabIndex = 94;
            this.label3.Text = "Ciudad:";
            // 
            // BoxYears
            // 
            this.BoxYears.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BoxYears.FormattingEnabled = true;
            this.BoxYears.Items.AddRange(new object[] {
            "Todos",
            "1990",
            "1991",
            "1992",
            "1993",
            "1994",
            "1995",
            "1996",
            "1997",
            "1998",
            "1999",
            "2000",
            "2001",
            "2002",
            "2003",
            "2004",
            "2005",
            "2006",
            "2007",
            "2008",
            "2009",
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025",
            "2026",
            "2027"});
            this.BoxYears.Location = new System.Drawing.Point(233, 42);
            this.BoxYears.Name = "BoxYears";
            this.BoxYears.Size = new System.Drawing.Size(121, 24);
            this.BoxYears.TabIndex = 2;
            // 
            // BoxHoteles
            // 
            this.BoxHoteles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BoxHoteles.FormattingEnabled = true;
            this.BoxHoteles.Location = new System.Drawing.Point(28, 42);
            this.BoxHoteles.Name = "BoxHoteles";
            this.BoxHoteles.Size = new System.Drawing.Size(181, 24);
            this.BoxHoteles.TabIndex = 1;
            // 
            // ReporteOcupacionHotel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1170, 879);
            this.Controls.Add(this.BoxHoteles);
            this.Controls.Add(this.BoxYears);
            this.Controls.Add(this.ComBoxCiudad);
            this.Controls.Add(this.ComBoxPais);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnFiltrarHot);
            this.Controls.Add(this.GrdReporte2);
            this.Controls.Add(this.GrdReporte1);
            this.Controls.Add(this.button4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReporteOcupacionHotel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de ocupación por hotel";
            this.Load += new System.EventHandler(this.ReporteOcupacionHotel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrdReporte2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdReporte1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnFiltrarHot;
        private System.Windows.Forms.DataGridView GrdReporte2;
        private System.Windows.Forms.DataGridView GrdReporte1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ComBoxCiudad;
        private System.Windows.Forms.ComboBox ComBoxPais;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox BoxYears;
        private System.Windows.Forms.ComboBox BoxHoteles;
    }
}