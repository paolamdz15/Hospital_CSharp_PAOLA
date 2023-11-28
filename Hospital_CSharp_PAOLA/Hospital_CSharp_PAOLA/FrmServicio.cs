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
    public partial class FrmServicio : Form
    {
        public FrmServicio()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Conexion.conexionn.Open();
            SqlCommand xd = new SqlCommand(@"Insert into Servicio(NombreS,Descripcion,Duracion,ID_Atencion,Medico_crea,Medico_actualiza)
            values(@NombreS,@Descripcion,@Duracion,@ID_Atencion,@Medico_crea,@Medico_actualiza)", Conexion.conexionn);
            xd.Parameters.AddWithValue("@NombreS", txtNombre.Text);
            xd.Parameters.AddWithValue("@Descripcion", txtDescripcion.Text);
            xd.Parameters.AddWithValue("@Duracion", txtDuracion.Text);
            xd.Parameters.AddWithValue("@ID_Atencion", CBFechaA.SelectedValue);
            xd.Parameters.AddWithValue("@Medico_crea", 1);
            xd.Parameters.AddWithValue("@Medico_actualiza", 1);
            xd.ExecuteNonQuery();
            Conexion.conexionn.Close();
            this.servicioTableAdapter.Fill(this.hospitalDataSet.Servicio);
        }

        private void FrmServicio_Load(object sender, EventArgs e)
        {
            this.atencionTableAdapter.Fill(this.hospitalDataSet.Atencion);
            this.servicioTableAdapter.Fill(this.hospitalDataSet.Servicio);

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Conexion.conexionn.Open();
            SqlCommand xd = new SqlCommand("Update Servicio set  NombreS=@NombreS,Descripcion=@Descripcion,Duracion=@Duracion,ID_Atencion=@ID_Atencion,Medico_crea=@Medico_crea,Medico_actualiza=@Medico_actualiza where ID_Servicio  = @ID_Servicio ", Conexion.conexionn);
            xd.Parameters.AddWithValue("@ID_Servicio", Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
            xd.Parameters.AddWithValue("@NombreS", txtNombre.Text);
            xd.Parameters.AddWithValue("@Descripcion", txtDescripcion.Text);
            xd.Parameters.AddWithValue("@Duracion", txtDuracion.Text);
            xd.Parameters.AddWithValue("@ID_Atencion", CBFechaA.SelectedValue);
            xd.Parameters.AddWithValue("@Medico_crea", 1);
            xd.Parameters.AddWithValue("@Medico_actualiza", 1);
            xd.ExecuteNonQuery();
            Conexion.conexionn.Close();
            this.servicioTableAdapter.Fill(this.hospitalDataSet.Servicio);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Conexion.conexionn.Open();
            SqlCommand xd = new SqlCommand("Update Servicio set status=0 where ID_Servicio = @ID_Servicio", Conexion.conexionn);
            xd.Parameters.AddWithValue("@ID_Servicio", Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
            xd.ExecuteNonQuery();
            Conexion.conexionn.Close();
            this.servicioTableAdapter.Fill(this.hospitalDataSet.Servicio);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmInicio Menu = new FrmInicio();
            Menu.Show();
            this.Hide();
        }
    }
}
