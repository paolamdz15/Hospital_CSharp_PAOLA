using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_C_
{
    public partial class FrmCliente : Form
    {
        public FrmCliente()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Conexion.conexionn.Open();
            SqlCommand xd = new SqlCommand(@"Insert into Cliente(NombreC,ApPaternoC,ApMaternoC,DireccionC,TelefonoC,Medico_crea,Medico_actualiza)
            values(@NombreC,@ApPaternoC,@ApMaternoC,@DireccionC,@TelefonoC,@Medico_crea,@Medico_actualiza)", Conexion.conexionn);
            xd.Parameters.AddWithValue("@NombreC", txtNombre.Text);
            xd.Parameters.AddWithValue("@ApPaternoC", txtAP.Text);
            xd.Parameters.AddWithValue("@ApMaternoC", ttAM.Text);
            xd.Parameters.AddWithValue("@DireccionC", txtDireccion.Text);
            xd.Parameters.AddWithValue("@TelefonoC", txtTelefono.Text);
            xd.Parameters.AddWithValue("@Medico_crea", 1);
            xd.Parameters.AddWithValue("@Medico_actualiza", 1);
            xd.ExecuteNonQuery();
            Conexion.conexionn.Close();
            this.clienteTableAdapter.Fill(this.hospitalDataSet.Cliente);
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            this.clienteTableAdapter.Fill(this.hospitalDataSet.Cliente);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Conexion.conexionn.Open();
            SqlCommand xd = new SqlCommand("Update Cliente set  NombreC=@NombreC,ApPaternoC=@ApPaternoC,ApMaternoC=@ApMaternoC,DireccionC=@DireccionC,TelefonoC=@TelefonoC,Medico_crea=@Medico_crea,Medico_actualiza=@Medico_actualiza where ID_Cliente = @ID_Cliente", Conexion.conexionn);
            xd.Parameters.AddWithValue("@ID_Cliente", Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
            xd.Parameters.AddWithValue("@NombreC", txtNombre.Text);
            xd.Parameters.AddWithValue("@ApPaternoC", txtAP.Text);
            xd.Parameters.AddWithValue("@ApMaternoC", ttAM.Text);
            xd.Parameters.AddWithValue("@DireccionC", txtDireccion.Text);
            xd.Parameters.AddWithValue("@TelefonoC", txtTelefono.Text);
            xd.Parameters.AddWithValue("@Medico_crea", 1);
            xd.Parameters.AddWithValue("@Medico_actualiza", 1);
            xd.ExecuteNonQuery();
            Conexion.conexionn.Close();
            this.clienteTableAdapter.Fill(this.hospitalDataSet.Cliente);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Conexion.conexionn.Open();
            SqlCommand xd = new SqlCommand("Update Cliente set status=0 where ID_Cliente = @ID_Cliente", Conexion.conexionn);
            xd.Parameters.AddWithValue("@ID_Cliente", Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
            xd.ExecuteNonQuery();
            Conexion.conexionn.Close();
            this.clienteTableAdapter.Fill(this.hospitalDataSet.Cliente);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmInicio Menu = new FrmInicio();
            Menu.Show();
            this.Hide();
        }
    }
}
