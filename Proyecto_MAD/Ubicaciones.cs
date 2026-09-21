using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1;
using static Proyecto_MAD.GestionUsuarios;

namespace Proyecto_MAD
{
    public partial class Ubicaciones : Form
    {
        private static bool PaisSeleccionado {  get; set; }
        private static bool EstadoSeleccionado { get; set; }
        private static bool CiudadSeleccionado { get; set; }
        private static int IDPAIS {  get; set; }
        private static int IDESTADO { get; set; }
        private static int IDCIUDAD { get; set; }
        public Ubicaciones()
        {
            InitializeComponent();
        }

        public void CargarPaises()
        {
            var obj = new EnlaceDB();
            var table = new DataTable();
            table = obj.Get_Paises();
            GrdPais.DataSource = table;
            GrdPais.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            GrdPais.Columns["PaisID"].Visible = false;

        }

        public void CargarEstados(int ID)
        {
            var obj = new EnlaceDB();
            var table = new DataTable();
            table = obj.Get_EstadosPorPais(ID);
            GrdEstado.DataSource = table;
            GrdEstado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            GrdEstado.Columns["EstadoID"].Visible = false;

        }

        public void CargarCiudades(int ID)
        {
            var obj = new EnlaceDB();
            var table = new DataTable();
            table = obj.Get_CiudadesPorEstado(ID);
            GrdCiudad.DataSource = table;
            GrdCiudad.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            GrdCiudad.Columns["CiudadID"].Visible = false;

        }

        private void Ubicaciones_Load(object sender, EventArgs e)
        {
            CargarPaises();
            CargarEstados(0);
            CargarCiudades(0);
            GrdPais.SelectionChanged += GrdPaises_SelectionChanged;
            GrdEstado.SelectionChanged += GrdEstados_SelectionChanged;
            GrdCiudad.SelectionChanged += GrdCiudades_SelectionChanged;
        }

        private void GrdPaises_SelectionChanged(object sender, EventArgs e)
        {
            if (GrdPais.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = GrdPais.SelectedRows[0];
                txtEstado.Enabled = true;
                btnAgreEstado.Enabled = true;
                GrdEstado.Enabled = true;
                btnElimPais.Visible = true;
                btnCancelPais.Visible = true;
                btnAgrePais.Text = "Modificar";
                IDPAIS = int.Parse(selectedRow.Cells["PaisID"].Value.ToString());
                txtPais.Text = selectedRow.Cells["Nombre"].Value.ToString();
                CargarEstados(IDPAIS);
                PaisSeleccionado = true;

                EstadoSeleccionado = false;
                CiudadSeleccionado = false;
                btnCancelCiudad.Visible = false;
                btnCancelEstado.Visible = false;
                btnElimEstado.Visible = false;
                btnElimCiudad.Visible = false;
                txtEstado.Clear();
                txtCiudad.Clear();
                btnAgreEstado.Text = "Agregar";
                btnAgreCiudad.Text = "Agregar";
                btnAgreCiudad.Enabled = false;
                GrdCiudad.Enabled = false;
                CargarCiudades(0);
            }
        }
        private void btnAgrePais_Click(object sender, EventArgs e)
        {
            string Pais = txtPais.Text;
            var db = new EnlaceDB();
            if (PaisSeleccionado)
            {
                db.ModificarPais(IDPAIS, Pais);
                PaisSeleccionado = false;
                EstadoSeleccionado = false;
                CiudadSeleccionado = false;
                btnCancelPais.Visible = false;
                btnCancelCiudad.Visible = false;
                btnCancelEstado.Visible = false;
                btnElimPais.Visible = false;
                btnElimEstado.Visible = false;
                btnElimCiudad.Visible = false;
                txtEstado.Clear();
                txtCiudad.Clear();
                btnAgrePais.Text = "Agregar";
                btnAgreEstado.Text = "Agregar";
                btnAgreCiudad.Text = "Agregar";
                btnAgreEstado.Enabled = false;
                btnAgreCiudad.Enabled = false;
                GrdEstado.Enabled = false;
                GrdCiudad.Enabled = false;
                CargarEstados(0);
                CargarCiudades(0);
            }
            else
            {
                db.CrearPais(Pais);
            }
            CargarPaises();
            txtPais.Clear();
        }

        private void btnCancelPais_Click(object sender, EventArgs e)
        {
            CargarPaises();
            PaisSeleccionado = false;
            EstadoSeleccionado = false;
            CiudadSeleccionado = false;
            btnCancelPais.Visible = false;
            btnCancelCiudad.Visible = false;
            btnCancelEstado.Visible = false;
            btnElimPais.Visible=false;
            btnElimEstado.Visible=false;
            btnElimCiudad.Visible=false;
            txtPais.Clear();
            txtEstado.Clear();
            txtCiudad.Clear();
            btnAgrePais.Text = "Agregar";
            btnAgreEstado.Text = "Agregar";
            btnAgreCiudad.Text = "Agregar";
            btnAgreEstado.Enabled = false;
            btnAgreCiudad.Enabled = false;
            GrdEstado.Enabled = false;
            GrdCiudad.Enabled = false;
            CargarEstados(0);
            CargarCiudades(0);
        }

        private void btnElimPais_Click(object sender, EventArgs e)
        {
            var bd = new EnlaceDB();
            bd.BorrarPais(IDPAIS);
            CargarPaises();
            PaisSeleccionado = false;
            EstadoSeleccionado = false;
            CiudadSeleccionado = false;
            btnCancelPais.Visible = false;
            btnCancelCiudad.Visible = false;
            btnCancelEstado.Visible = false;
            btnElimPais.Visible = false;
            btnElimEstado.Visible = false;
            btnElimCiudad.Visible = false;
            txtPais.Clear();
            txtEstado.Clear();
            txtCiudad.Clear();
            btnAgrePais.Text = "Agregar";
            btnAgreEstado.Text = "Agregar";
            btnAgreCiudad.Text = "Agregar";
            btnAgreEstado.Enabled = false;
            btnAgreCiudad.Enabled = false;
            GrdEstado.Enabled = false;
            GrdCiudad.Enabled = false;
            CargarEstados(0);
            CargarCiudades(0);
        }

        private void GrdEstados_SelectionChanged(object sender, EventArgs e)
        {
            if (GrdEstado.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = GrdEstado.SelectedRows[0];
                txtCiudad.Enabled = true;
                btnAgreCiudad.Enabled = true;
                GrdCiudad.Enabled = true;
                btnElimEstado.Visible = true;
                btnCancelEstado.Visible = true;
                btnAgreEstado.Text = "Modificar";
                IDESTADO = int.Parse(selectedRow.Cells["EstadoID"].Value.ToString());
                txtEstado.Text = selectedRow.Cells["Nombre"].Value.ToString();
                CargarCiudades(IDESTADO);
                EstadoSeleccionado = true;

                CiudadSeleccionado = false;
                btnCancelCiudad.Visible = false;
                btnElimCiudad.Visible = false;
                txtCiudad.Clear();
                btnAgreCiudad.Text = "Agregar";
            }
        }
        private void btnAgreEstado_Click(object sender, EventArgs e)
        {
            string Estado = txtEstado.Text;
            var db = new EnlaceDB();
            if (EstadoSeleccionado)
            {
                db.ModificarEstado(IDESTADO, Estado);
                EstadoSeleccionado = false;
                CiudadSeleccionado = false;
                btnCancelCiudad.Visible = false;
                btnCancelEstado.Visible = false;
                btnElimEstado.Visible = false;
                btnElimCiudad.Visible = false;
                txtCiudad.Clear();
                btnAgreEstado.Text = "Agregar";
                btnAgreCiudad.Text = "Agregar";
                btnAgreCiudad.Enabled = false;
                GrdCiudad.Enabled = false;
                CargarCiudades(0);
            }
            else
            {
                db.CrearEstado(IDPAIS,Estado);
            }
            CargarEstados(IDPAIS);
            txtEstado.Clear();
        }

        private void btnCancelEstado_Click(object sender, EventArgs e)
        {
            CargarEstados(IDPAIS);
            EstadoSeleccionado = false;
            CiudadSeleccionado = false;
            btnCancelCiudad.Visible = false;
            btnCancelEstado.Visible = false;
            btnElimEstado.Visible = false;
            btnElimCiudad.Visible = false;
            txtEstado.Clear();
            txtCiudad.Clear();
            btnAgreEstado.Text = "Agregar";
            btnAgreCiudad.Text = "Agregar";
            btnAgreCiudad.Enabled = false;
            GrdCiudad.Enabled = false;
            CargarCiudades(0);
        }

        private void btnElimEstado_Click(object sender, EventArgs e)
        {
            var bd = new EnlaceDB();
            bd.BorrarEstado(IDESTADO);
            CargarEstados(IDPAIS);
            EstadoSeleccionado = false;
            CiudadSeleccionado = false;
            btnCancelCiudad.Visible = false;
            btnCancelEstado.Visible = false;
            btnElimEstado.Visible = false;
            btnElimCiudad.Visible = false;
            txtEstado.Clear();
            txtCiudad.Clear();
            btnAgreEstado.Text = "Agregar";
            btnAgreCiudad.Text = "Agregar";
            btnAgreCiudad.Enabled = false;
            GrdCiudad.Enabled = false;
            CargarCiudades(0);
        }

        private void GrdCiudades_SelectionChanged(object sender, EventArgs e)
        {
            if (GrdCiudad.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = GrdCiudad.SelectedRows[0];
                btnElimCiudad.Visible = true;
                btnCancelCiudad.Visible = true;
                btnAgreCiudad.Text = "Modificar";
                IDCIUDAD = int.Parse(selectedRow.Cells["CiudadID"].Value.ToString());
                txtCiudad.Text = selectedRow.Cells["Nombre"].Value.ToString();
                CiudadSeleccionado = true;
            }
        }
        private void btnAgreCiudad_Click(object sender, EventArgs e)
        {
            string Ciudad = txtCiudad.Text;
            var db = new EnlaceDB();
            if (CiudadSeleccionado)
            {
                db.ModificarCiudad(IDCIUDAD, Ciudad);
                CiudadSeleccionado = false;
                btnCancelCiudad.Visible = false;
                btnElimCiudad.Visible = false;
                btnAgreCiudad.Text = "Agregar";
            }
            else
            {
                db.CrearCiudad(IDESTADO, Ciudad);
            }
            CargarCiudades(IDESTADO);
            txtCiudad.Clear();
        }

        private void btnCancelCiudad_Click(object sender, EventArgs e)
        {
            CargarCiudades(IDESTADO);
            CiudadSeleccionado = false;
            btnCancelCiudad.Visible = false;
            btnElimCiudad.Visible = false;
            txtCiudad.Clear();
            btnAgreCiudad.Text = "Agregar";
        }

        private void btnElimCiudad_Click(object sender, EventArgs e)
        {
            var bd = new EnlaceDB();
            bd.BorrarCiudad(IDCIUDAD);
            CargarCiudades(IDESTADO);
            CiudadSeleccionado = false;
            btnCancelCiudad.Visible = false;
            btnElimCiudad.Visible = false;
            txtCiudad.Clear();
            btnAgreCiudad.Text = "Agregar";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
