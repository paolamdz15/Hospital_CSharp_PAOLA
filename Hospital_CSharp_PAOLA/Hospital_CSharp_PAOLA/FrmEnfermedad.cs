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
    public partial class FrmEnfermedad : Form
    {
        public FrmEnfermedad()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Conexion.conexionn.Open();
            SqlCommand dx = new SqlCommand("Insert into Enfermedad (NombreE,Tratamiento,Medico_crea,Medico_actualiza) values (@NombreE,@Tratamiento,@Medico_crea,@Medico_actualiza)", Conexion.conexionn);
            dx.Parameters.AddWithValue("@NombreE", txtNombre.Text);
            dx.Parameters.AddWithValue("@Tratamiento", txtTratamiento.Text);
            dx.Parameters.AddWithValue("@Medico_crea", 1);
            dx.Parameters.AddWithValue("@Medico_actualiza", 1);
            dx.ExecuteNonQuery();
            Conexion.conexionn.Close();
            this.enfermedadTableAdapter.Fill(this.hospitalDataSet.Enfermedad);
        }

        private void FrmEnfermedad_Load(object sender, EventArgs e)
        {
            this.enfermedadTableAdapter.Fill(this.hospitalDataSet.Enfermedad);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Conexion.conexionn.Open();
            SqlCommand dx = new SqlCommand("Update Enfermedad set NombreE=@NombreE, Tratamiento=@Tratamiento,Medico_crea=@Medico_crea,Medico_actualiza=@Medico_actualiza where ID_Enfermedad = @ID_Enfermedad", Conexion.conexionn);
            dx.Parameters.AddWithValue("@ID_Enfermedad", Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
            dx.Parameters.AddWithValue("@NombreE", txtNombre.Text);
            dx.Parameters.AddWithValue("@Tratamiento", txtTratamiento.Text);
            dx.Parameters.AddWithValue("@Medico_crea", 1);
            dx.Parameters.AddWithValue("@Medico_actualiza", 1);
            dx.ExecuteNonQuery();
            Conexion.conexionn.Close();
            this.enfermedadTableAdapter.Fill(this.hospitalDataSet.Enfermedad);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Conexion.conexionn.Open();
            SqlCommand dx = new SqlCommand("Update Enfermedad set status=0 where ID_Enfermedad = @ID_Enfermedad", Conexion.conexionn);
            dx.Parameters.AddWithValue("@ID_Enfermedad", Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
            dx.ExecuteNonQuery();
            Conexion.conexionn.Close();
            this.enfermedadTableAdapter.Fill(this.hospitalDataSet.Enfermedad);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmInicio Menu = new FrmInicio();
            Menu.Show();
            this.Hide();
        }
    }
}
