namespace Proyecto_MAD
{
    partial class CalendarioHabitaciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalendarioHabitaciones));
            this.button2 = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.lbNombreHotel = new System.Windows.Forms.Label();
            this.GridHabitaciones = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ComBoxTipoHabitacion = new System.Windows.Forms.ComboBox();
            this.labelPersonas = new System.Windows.Forms.Label();
            this.labelPrecio = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.listCaracteristicas = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GridHabitaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Gainsboro;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Location = new System.Drawing.Point(12, 674);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(114, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.Color.Transparent;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(27, 25);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(51, 17);
            this.label26.TabIndex = 120;
            this.label26.Text = "Hotel:";
            // 
            // button5
            // 
            this.button5.Enabled = false;
            this.button5.Location = new System.Drawing.Point(1299, 63);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(107, 23);
            this.button5.TabIndex = 4;
            this.button5.Text = "Filtrar";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(906, 62);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(183, 24);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(1095, 62);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(183, 24);
            this.comboBox2.TabIndex = 3;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // lbNombreHotel
            // 
            this.lbNombreHotel.AutoSize = true;
            this.lbNombreHotel.BackColor = System.Drawing.Color.Transparent;
            this.lbNombreHotel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNombreHotel.Location = new System.Drawing.Point(86, 25);
            this.lbNombreHotel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbNombreHotel.Name = "lbNombreHotel";
            this.lbNombreHotel.Size = new System.Drawing.Size(134, 17);
            this.lbNombreHotel.TabIndex = 122;
            this.lbNombreHotel.Text = "Nombre del Hotel";
            // 
            // GridHabitaciones
            // 
            this.GridHabitaciones.AllowUserToAddRows = false;
            this.GridHabitaciones.AllowUserToDeleteRows = false;
            this.GridHabitaciones.AllowUserToResizeColumns = false;
            this.GridHabitaciones.AllowUserToResizeRows = false;
            this.GridHabitaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridHabitaciones.Location = new System.Drawing.Point(342, 92);
            this.GridHabitaciones.Name = "GridHabitaciones";
            this.GridHabitaciones.ReadOnly = true;
            this.GridHabitaciones.RowHeadersWidth = 51;
            this.GridHabitaciones.RowTemplate.Height = 24;
            this.GridHabitaciones.Size = new System.Drawing.Size(1092, 530);
            this.GridHabitaciones.TabIndex = 5;
            this.GridHabitaciones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Cyan;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(342, 628);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Reservar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 63);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 17);
            this.label2.TabIndex = 125;
            this.label2.Text = "Habitación:";
            // 
            // ComBoxTipoHabitacion
            // 
            this.ComBoxTipoHabitacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComBoxTipoHabitacion.FormattingEnabled = true;
            this.ComBoxTipoHabitacion.Location = new System.Drawing.Point(124, 56);
            this.ComBoxTipoHabitacion.Name = "ComBoxTipoHabitacion";
            this.ComBoxTipoHabitacion.Size = new System.Drawing.Size(183, 24);
            this.ComBoxTipoHabitacion.TabIndex = 1;
            this.ComBoxTipoHabitacion.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // labelPersonas
            // 
            this.labelPersonas.AutoSize = true;
            this.labelPersonas.BackColor = System.Drawing.Color.Transparent;
            this.labelPersonas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPersonas.Location = new System.Drawing.Point(27, 143);
            this.labelPersonas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPersonas.Name = "labelPersonas";
            this.labelPersonas.Size = new System.Drawing.Size(147, 17);
            this.labelPersonas.TabIndex = 128;
            this.labelPersonas.Text = "Capacidad máxima:";
            // 
            // labelPrecio
            // 
            this.labelPrecio.AutoSize = true;
            this.labelPrecio.BackColor = System.Drawing.Color.Transparent;
            this.labelPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrecio.Location = new System.Drawing.Point(27, 103);
            this.labelPrecio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPrecio.Name = "labelPrecio";
            this.labelPrecio.Size = new System.Drawing.Size(137, 17);
            this.labelPrecio.TabIndex = 127;
            this.labelPrecio.Text = "Precio por noche:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1363, 628);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(32, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "<";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1401, 628);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(32, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = ">";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // listCaracteristicas
            // 
            this.listCaracteristicas.FormattingEnabled = true;
            this.listCaracteristicas.ItemHeight = 16;
            this.listCaracteristicas.Location = new System.Drawing.Point(30, 214);
            this.listCaracteristicas.Name = "listCaracteristicas";
            this.listCaracteristicas.Size = new System.Drawing.Size(277, 308);
            this.listCaracteristicas.TabIndex = 129;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 182);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 17);
            this.label1.TabIndex = 130;
            this.label1.Text = "Caracteristicas:";
            // 
            // CalendarioHabitaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1482, 709);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listCaracteristicas);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.labelPersonas);
            this.Controls.Add(this.labelPrecio);
            this.Controls.Add(this.ComBoxTipoHabitacion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.GridHabitaciones);
            this.Controls.Add(this.lbNombreHotel);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CalendarioHabitaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Habitaciones";
            this.Load += new System.EventHandler(this.CalendarioHabitaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridHabitaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label lbNombreHotel;
        private System.Windows.Forms.DataGridView GridHabitaciones;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ComBoxTipoHabitacion;
        private System.Windows.Forms.Label labelPersonas;
        private System.Windows.Forms.Label labelPrecio;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ListBox listCaracteristicas;
        private System.Windows.Forms.Label label1;
    }
}