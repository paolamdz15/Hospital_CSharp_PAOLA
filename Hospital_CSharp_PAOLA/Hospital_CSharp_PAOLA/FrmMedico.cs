using System;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Hospital_C_
{
    public partial class FrmMedico : Form
    {
      
        public FrmMedico()
        {
            InitializeComponent();
           
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Conexion.conexionn.Open();
            SqlCommand xd = new SqlCommand(@"Insert into Medico(Nombre,Ap_Paterno,Ap_Materno,Especialidad,Telefono,Usuario,Contrasena,Medico_crea,Medico_actualiza)
            values(@Nombre,@Ap_Paterno,@Ap_Materno,@Especialidad,@Telefono,@Usuario,@Contrasena,@Medico_crea,@Medico_actualiza)", Conexion.conexionn);
            xd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
            xd.Parameters.AddWithValue("@Ap_Paterno", txtAP.Text);
            xd.Parameters.AddWithValue("@Ap_Materno", txtAM.Text);
            xd.Parameters.AddWithValue("@Especialidad", txtEspecialidad.Text);
            xd.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
            xd.Parameters.AddWithValue("@Usuario", txtUsuario.Text);
            xd.Parameters.AddWithValue("@Contrasena", Funciones.Encriptar(txtContra.Text));
            xd.Parameters.AddWithValue("@Medico_crea", 1);
            xd.Parameters.AddWithValue("@Medico_actualiza", 1);
            xd.ExecuteNonQuery();
            Conexion.conexionn.Close();
            this.medicoTableAdapter1.Fill(this.hospitalDataSet.Medico);
        }

        private void FrmMedico_Load(object sender, EventArgs e)
        {
           
            this.medicoTableAdapter1.Fill(this.hospitalDataSet.Medico);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Conexion.conexionn.Open();
            SqlCommand xd = new SqlCommand(@"Update Medico set Nombre=@Nombre,Ap_Paterno=@Ap_Paterno,Ap_Materno=@Ap_Materno,Especialidad=@Especialidad,Telefono=@Telefono,Usuario=@Usuario,
            Contrasena=@Contrasena,Medico_crea=@Medico_crea,Medico_actualiza=@Medico_actualiza where ID_Medico = @ID_Medico", Conexion.conexionn);
            xd.Parameters.AddWithValue("@ID_Medico", Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
            xd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
            xd.Parameters.AddWithValue("@Ap_Paterno", txtAP.Text);
            xd.Parameters.AddWithValue("@Ap_Materno", txtAM.Text);
            xd.Parameters.AddWithValue("@Especialidad", txtEspecialidad.Text);
            xd.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
            xd.Parameters.AddWithValue("@Usuario", txtUsuario.Text);
            xd.Parameters.AddWithValue("@Contrasena",Funciones.Encriptar( txtContra.Text));
            xd.Parameters.AddWithValue("@Medico_crea", 1);
            xd.Parameters.AddWithValue("@Medico_actualiza", 1);
            xd.ExecuteNonQuery();
            Conexion.conexionn.Close();
            this.medicoTableAdapter1.Fill(this.hospitalDataSet.Medico);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Conexion.conexionn.Open();
            SqlCommand xd = new SqlCommand("Update Medico set status=0 where ID_Medico = @ID_Medico", Conexion.conexionn);
            xd.Parameters.AddWithValue("@ID_Medico", Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
            xd.ExecuteNonQuery();
            Conexion.conexionn.Close();
            this.medicoTableAdapter1.Fill(this.hospitalDataSet.Medico);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmInicio Menu = new FrmInicio();
            Menu.Show();
            this.Hide();
        }
    }
}
