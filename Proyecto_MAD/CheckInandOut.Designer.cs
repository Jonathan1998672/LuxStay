namespace Proyecto_MAD
{
    partial class CheckInandOut
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckInandOut));
            this.btnBuscarOut = new System.Windows.Forms.Button();
            this.btnBuscarIn = new System.Windows.Forms.Button();
            this.GrdReservacionesIn = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.txtCodigoOut = new System.Windows.Forms.TextBox();
            this.txtCodigoIn = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnFactura = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.GrdReservacionesOut = new System.Windows.Forms.DataGridView();
            this.lbHabitacion = new System.Windows.Forms.Label();
            this.lbPais = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbCodigo = new System.Windows.Forms.Label();
            this.lbCliente = new System.Windows.Forms.Label();
            this.lbTipoHabitacion = new System.Windows.Forms.Label();
            this.lbNombreHotel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GrdReservacionesIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdReservacionesOut)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBuscarOut
            // 
            this.btnBuscarOut.Location = new System.Drawing.Point(398, 451);
            this.btnBuscarOut.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscarOut.Name = "btnBuscarOut";
            this.btnBuscarOut.Size = new System.Drawing.Size(100, 28);
            this.btnBuscarOut.TabIndex = 6;
            this.btnBuscarOut.Text = "Buscar";
            this.btnBuscarOut.UseVisualStyleBackColor = true;
            this.btnBuscarOut.Click += new System.EventHandler(this.btnBuscarOut_Click);
            // 
            // btnBuscarIn
            // 
            this.btnBuscarIn.Location = new System.Drawing.Point(413, 46);
            this.btnBuscarIn.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscarIn.Name = "btnBuscarIn";
            this.btnBuscarIn.Size = new System.Drawing.Size(100, 28);
            this.btnBuscarIn.TabIndex = 2;
            this.btnBuscarIn.Text = "Buscar";
            this.btnBuscarIn.UseVisualStyleBackColor = true;
            this.btnBuscarIn.Click += new System.EventHandler(this.btnBuscarIn_Click);
            // 
            // GrdReservacionesIn
            // 
            this.GrdReservacionesIn.AllowUserToAddRows = false;
            this.GrdReservacionesIn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdReservacionesIn.Location = new System.Drawing.Point(23, 84);
            this.GrdReservacionesIn.Margin = new System.Windows.Forms.Padding(4);
            this.GrdReservacionesIn.MultiSelect = false;
            this.GrdReservacionesIn.Name = "GrdReservacionesIn";
            this.GrdReservacionesIn.ReadOnly = true;
            this.GrdReservacionesIn.RowHeadersWidth = 51;
            this.GrdReservacionesIn.Size = new System.Drawing.Size(1042, 276);
            this.GrdReservacionesIn.StandardTab = true;
            this.GrdReservacionesIn.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(184, 414);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 37);
            this.label2.TabIndex = 40;
            this.label2.Text = "Check-Out";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(196, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 37);
            this.label1.TabIndex = 39;
            this.label1.Text = "Check-In";
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.Enabled = false;
            this.btnCheckIn.Location = new System.Drawing.Point(23, 368);
            this.btnCheckIn.Margin = new System.Windows.Forms.Padding(4);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(100, 28);
            this.btnCheckIn.TabIndex = 4;
            this.btnCheckIn.Text = "Check";
            this.btnCheckIn.UseVisualStyleBackColor = true;
            this.btnCheckIn.Click += new System.EventHandler(this.btnCheckIn_Click);
            // 
            // txtCodigoOut
            // 
            this.txtCodigoOut.Location = new System.Drawing.Point(94, 453);
            this.txtCodigoOut.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigoOut.Name = "txtCodigoOut";
            this.txtCodigoOut.Size = new System.Drawing.Size(295, 22);
            this.txtCodigoOut.TabIndex = 5;
            // 
            // txtCodigoIn
            // 
            this.txtCodigoIn.Location = new System.Drawing.Point(93, 48);
            this.txtCodigoIn.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigoIn.Name = "txtCodigoIn";
            this.txtCodigoIn.Size = new System.Drawing.Size(311, 22);
            this.txtCodigoIn.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(19, 453);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 21);
            this.label4.TabIndex = 34;
            this.label4.Text = "Codigo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 48);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 21);
            this.label3.TabIndex = 33;
            this.label3.Text = "Codigo:";
            // 
            // btnFactura
            // 
            this.btnFactura.Enabled = false;
            this.btnFactura.Location = new System.Drawing.Point(23, 771);
            this.btnFactura.Margin = new System.Windows.Forms.Padding(4);
            this.btnFactura.Name = "btnFactura";
            this.btnFactura.Size = new System.Drawing.Size(202, 28);
            this.btnFactura.TabIndex = 8;
            this.btnFactura.Text = "Check y Generar Factura";
            this.btnFactura.UseVisualStyleBackColor = true;
            this.btnFactura.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Gainsboro;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Location = new System.Drawing.Point(1335, 793);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(114, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Regresar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // GrdReservacionesOut
            // 
            this.GrdReservacionesOut.AllowUserToAddRows = false;
            this.GrdReservacionesOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdReservacionesOut.Location = new System.Drawing.Point(23, 487);
            this.GrdReservacionesOut.Margin = new System.Windows.Forms.Padding(4);
            this.GrdReservacionesOut.MultiSelect = false;
            this.GrdReservacionesOut.Name = "GrdReservacionesOut";
            this.GrdReservacionesOut.ReadOnly = true;
            this.GrdReservacionesOut.RowHeadersWidth = 51;
            this.GrdReservacionesOut.Size = new System.Drawing.Size(1042, 276);
            this.GrdReservacionesOut.StandardTab = true;
            this.GrdReservacionesOut.TabIndex = 7;
            // 
            // lbHabitacion
            // 
            this.lbHabitacion.AutoSize = true;
            this.lbHabitacion.BackColor = System.Drawing.Color.Transparent;
            this.lbHabitacion.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHabitacion.Location = new System.Drawing.Point(1102, 366);
            this.lbHabitacion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbHabitacion.Name = "lbHabitacion";
            this.lbHabitacion.Size = new System.Drawing.Size(99, 25);
            this.lbHabitacion.TabIndex = 125;
            this.lbHabitacion.Text = "Habitacion";
            this.lbHabitacion.Visible = false;
            // 
            // lbPais
            // 
            this.lbPais.AutoSize = true;
            this.lbPais.BackColor = System.Drawing.Color.Transparent;
            this.lbPais.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPais.Location = new System.Drawing.Point(1103, 407);
            this.lbPais.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPais.Name = "lbPais";
            this.lbPais.Size = new System.Drawing.Size(68, 25);
            this.lbPais.TabIndex = 126;
            this.lbPais.Text = "Ciudad";
            this.lbPais.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(1103, 432);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(366, 25);
            this.label7.TabIndex = 127;
            this.label7.Text = "-----------------------------------------------------------";
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.BackColor = System.Drawing.Color.Transparent;
            this.lbCodigo.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCodigo.Location = new System.Drawing.Point(1103, 475);
            this.lbCodigo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCodigo.Name = "lbCodigo";
            this.lbCodigo.Size = new System.Drawing.Size(193, 25);
            this.lbCodigo.TabIndex = 128;
            this.lbCodigo.Text = "Código de reservacion";
            this.lbCodigo.Visible = false;
            // 
            // lbCliente
            // 
            this.lbCliente.AutoSize = true;
            this.lbCliente.BackColor = System.Drawing.Color.Transparent;
            this.lbCliente.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCliente.Location = new System.Drawing.Point(1103, 523);
            this.lbCliente.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCliente.Name = "lbCliente";
            this.lbCliente.Size = new System.Drawing.Size(293, 25);
            this.lbCliente.TabIndex = 129;
            this.lbCliente.Text = "Nombre del cliente de Reservacion";
            this.lbCliente.Visible = false;
            // 
            // lbTipoHabitacion
            // 
            this.lbTipoHabitacion.AutoSize = true;
            this.lbTipoHabitacion.BackColor = System.Drawing.Color.Transparent;
            this.lbTipoHabitacion.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTipoHabitacion.Location = new System.Drawing.Point(1103, 326);
            this.lbTipoHabitacion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTipoHabitacion.Name = "lbTipoHabitacion";
            this.lbTipoHabitacion.Size = new System.Drawing.Size(161, 25);
            this.lbTipoHabitacion.TabIndex = 130;
            this.lbTipoHabitacion.Text = "Tipo de Habitacion";
            this.lbTipoHabitacion.Visible = false;
            // 
            // lbNombreHotel
            // 
            this.lbNombreHotel.AutoSize = true;
            this.lbNombreHotel.BackColor = System.Drawing.Color.Transparent;
            this.lbNombreHotel.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNombreHotel.Location = new System.Drawing.Point(1102, 289);
            this.lbNombreHotel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbNombreHotel.Name = "lbNombreHotel";
            this.lbNombreHotel.Size = new System.Drawing.Size(279, 25);
            this.lbNombreHotel.TabIndex = 131;
            this.lbNombreHotel.Text = "Nombre del Hotel de Reservacion";
            this.lbNombreHotel.Visible = false;
            // 
            // CheckInandOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1475, 839);
            this.Controls.Add(this.lbNombreHotel);
            this.Controls.Add(this.lbTipoHabitacion);
            this.Controls.Add(this.lbCliente);
            this.Controls.Add(this.lbCodigo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbPais);
            this.Controls.Add(this.lbHabitacion);
            this.Controls.Add(this.GrdReservacionesOut);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnBuscarOut);
            this.Controls.Add(this.btnBuscarIn);
            this.Controls.Add(this.GrdReservacionesIn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFactura);
            this.Controls.Add(this.btnCheckIn);
            this.Controls.Add(this.txtCodigoOut);
            this.Controls.Add(this.txtCodigoIn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CheckInandOut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CheckInandOut";
            this.Load += new System.EventHandler(this.CheckInandOut_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrdReservacionesIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdReservacionesOut)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuscarOut;
        private System.Windows.Forms.Button btnBuscarIn;
        private System.Windows.Forms.DataGridView GrdReservacionesIn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCheckIn;
        private System.Windows.Forms.TextBox txtCodigoOut;
        private System.Windows.Forms.TextBox txtCodigoIn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnFactura;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView GrdReservacionesOut;
        private System.Windows.Forms.Label lbHabitacion;
        private System.Windows.Forms.Label lbPais;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbCodigo;
        private System.Windows.Forms.Label lbCliente;
        private System.Windows.Forms.Label lbTipoHabitacion;
        private System.Windows.Forms.Label lbNombreHotel;
    }
}