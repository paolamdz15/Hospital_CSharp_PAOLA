using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_C_
{
    public partial class FrmInicio : Form
    {
        public FrmInicio()
        {
            InitializeComponent();
        }

        private void btnMedicos_Click(object sender, EventArgs e)
        {
            FrmMedico ListadoMedicos= new FrmMedico();
            ListadoMedicos.Show();
            this.Hide();
        }

        private void btnMedicamentos_Click(object sender, EventArgs e)
        {
            FrmMedicamento ListadoMedicamento = new FrmMedicamento();
            ListadoMedicamento.Show();
            this.Hide();
        }

        private void btnAtencion_Click(object sender, EventArgs e)
        {
            FrmAtencion Atenciones = new FrmAtencion();
            Atenciones.Show();
            this.Hide();
        }

        private void btnServicios_Click(object sender, EventArgs e)
        {
            FrmServicio Servicios = new FrmServicio();
            Servicios.Show();
            this.Hide();
        }

        private void btnTServicios_Click(object sender, EventArgs e)
        {
            FrmTipoServicio TServicios = new FrmTipoServicio();
            TServicios.Show();
            this.Hide();
        }

        private void btnPacientes_Click(object sender, EventArgs e)
        {
            FrmPaciente Pacientes = new FrmPaciente();
            Pacientes.Show();
            this.Hide();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            FrmCliente Clientes = new FrmCliente();
            Clientes.Show();
            this.Hide();
        }

        private void btnRecetas_Click(object sender, EventArgs e)
        {
            FrmReceta Recetas = new FrmReceta();
            Recetas.Show();
            this.Hide();
        }

        private void btnDiagnostico_Click(object sender, EventArgs e)
        {
            FrmDiagnostico Diagnosticos = new FrmDiagnostico();
            Diagnosticos.Show();
            this.Hide();
        }

        private void btnEnfermedad_Click(object sender, EventArgs e)
        {
            FrmEnfermedad Enfermedades = new FrmEnfermedad();
            Enfermedades.Show();
            this.Hide();
        }

        private void btnDFactura_Click(object sender, EventArgs e)
        {
            FrmDetalleFactura DFacturas = new FrmDetalleFactura();
            DFacturas.Show();
            this.Hide();
        }

        private void btnFactura_Click(object sender, EventArgs e)
        {
            FrmFactura Facturas = new FrmFactura();
            Facturas.Show();
            this.Hide();
        }

        private void FrmInicio_Load(object sender, EventArgs e)
        {

        }
    }
}
