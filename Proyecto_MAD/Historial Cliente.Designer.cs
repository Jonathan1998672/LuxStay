namespace Proyecto_MAD
{
    partial class Historial_Cliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Historial_Cliente));
            this.GrdHistorial = new System.Windows.Forms.DataGridView();
            this.btnYear = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.BoxFiltro = new System.Windows.Forms.ComboBox();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.GrdHistorial)).BeginInit();
            this.SuspendLayout();
            // 
            // GrdHistorial
            // 
            this.GrdHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdHistorial.Location = new System.Drawing.Point(13, 71);
            this.GrdHistorial.Margin = new System.Windows.Forms.Padding(4);
            this.GrdHistorial.MultiSelect = false;
            this.GrdHistorial.Name = "GrdHistorial";
            this.GrdHistorial.ReadOnly = true;
            this.GrdHistorial.RowHeadersWidth = 51;
            this.GrdHistorial.Size = new System.Drawing.Size(1476, 426);
            this.GrdHistorial.StandardTab = true;
            this.GrdHistorial.TabIndex = 6;
            // 
            // btnYear
            // 
            this.btnYear.Enabled = false;
            this.btnYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYear.Location = new System.Drawing.Point(878, 33);
            this.btnYear.Margin = new System.Windows.Forms.Padding(4);
            this.btnYear.Name = "btnYear";
            this.btnYear.Size = new System.Drawing.Size(100, 28);
            this.btnYear.TabIndex = 5;
            this.btnYear.Text = "Filtrar";
            this.btnYear.UseVisualStyleBackColor = true;
            this.btnYear.Click += new System.EventHandler(this.btnYear_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(737, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 17);
            this.label2.TabIndex = 31;
            this.label2.Text = "Año";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Gainsboro;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Location = new System.Drawing.Point(1359, 522);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(114, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "Regresar";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(577, 36);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(107, 23);
            this.btnFiltrar.TabIndex = 3;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // BoxFiltro
            // 
            this.BoxFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BoxFiltro.FormattingEnabled = true;
            this.BoxFiltro.Items.AddRange(new object[] {
            "Apellidos",
            "Nombre"});
            this.BoxFiltro.Location = new System.Drawing.Point(13, 35);
            this.BoxFiltro.Name = "BoxFiltro";
            this.BoxFiltro.Size = new System.Drawing.Size(148, 24);
            this.BoxFiltro.TabIndex = 1;
            this.BoxFiltro.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // txtFiltro
            // 
            this.txtFiltro.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtFiltro.Location = new System.Drawing.Point(252, 37);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(319, 22);
            this.txtFiltro.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(182, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 17);
            this.label1.TabIndex = 32;
            this.label1.Text = "Cliente:";
            // 
            // txtYear
            // 
            this.txtYear.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtYear.Location = new System.Drawing.Point(740, 36);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(131, 22);
            this.txtYear.TabIndex = 4;
            this.txtYear.TextChanged += new System.EventHandler(this.txtYear_TextChanged);
            // 
            // Historial_Cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1502, 560);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.BoxFiltro);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.GrdHistorial);
            this.Controls.Add(this.btnYear);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Historial_Cliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Historial del Cliente";
            this.Load += new System.EventHandler(this.Historial_Cliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrdHistorial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView GrdHistorial;
        private System.Windows.Forms.Button btnYear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.ComboBox BoxFiltro;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtYear;
    }
}