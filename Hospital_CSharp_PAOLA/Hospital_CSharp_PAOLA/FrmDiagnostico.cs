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
    public partial class FrmDiagnostico : Form
    {
        public FrmDiagnostico()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Conexion.conexionn.Open();
            SqlCommand xd = new SqlCommand(@"Insert into Diagnostico(Fecha,Descripcion,Resultado,ID_Medico,ID_Paciente ,ID_Enfermedad ,Medico_crea,Medico_actualiza)
            values(@Fecha,@Descripcion,@Resultado,@ID_Medico,@ID_Paciente ,@ID_Enfermedad,@Medico_crea,@Medico_actualiza)", Conexion.conexionn);
            xd.Parameters.AddWithValue("@Fecha", txtFecha.Text);
            xd.Parameters.AddWithValue("@Descripcion", txtDescripcion.Text);
            xd.Parameters.AddWithValue("@Resultado", txtResultado.Text);
            xd.Parameters.AddWithValue("@ID_Medico", CBMedico.SelectedValue);
            xd.Parameters.AddWithValue("@ID_Paciente", CBPaciente.SelectedValue);
            xd.Parameters.AddWithValue("@ID_Enfermedad", CBEnfermedad.SelectedValue);
            xd.Parameters.AddWithValue("@Medico_crea", 1);
            xd.Parameters.AddWithValue("@Medico_actualiza", 1);
            xd.ExecuteNonQuery();
            Conexion.conexionn.Close();
            this.diagnosticoTableAdapter.Fill(this.hospitalDataSet.Diagnostico);
        }

        private void FrmDiagnostico_Load(object sender, EventArgs e)
        {
            this.enfermedadTableAdapter.Fill(this.hospitalDataSet.Enfermedad);
            this.pacienteTableAdapter.Fill(this.hospitalDataSet.Paciente);
            this.medicoTableAdapter.Fill(this.hospitalDataSet.Medico);
            this.diagnosticoTableAdapter.Fill(this.hospitalDataSet.Diagnostico);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Conexion.conexionn.Open();
            SqlCommand xd = new SqlCommand("Update Diagnostico set  Fecha=@Fecha,Descripcion=@Descripcion,Resultado=@Resultado,ID_Medico=@ID_Medico,ID_Paciente=@ID_Paciente,ID_Enfermedad=@ID_Enfermedad ,Medico_crea=@Medico_crea,Medico_actualiza=@Medico_actualiza where ID_Diagnostico = @ID_Diagnostico", Conexion.conexionn);
            xd.Parameters.AddWithValue("@ID_Diagnostico", Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
            xd.Parameters.AddWithValue("@Fecha", txtFecha.Text);
            xd.Parameters.AddWithValue("@Descripcion", txtDescripcion.Text);
            xd.Parameters.AddWithValue("@Resultado", txtResultado.Text);
            xd.Parameters.AddWithValue("@ID_Medico", CBMedico.SelectedValue);
            xd.Parameters.AddWithValue("@ID_Paciente", CBPaciente.SelectedValue);
            xd.Parameters.AddWithValue("@ID_Enfermedad", CBEnfermedad.SelectedValue);
            xd.Parameters.AddWithValue("@Medico_crea", 1);
            xd.Parameters.AddWithValue("@Medico_actualiza", 1);
            xd.ExecuteNonQuery();
            Conexion.conexionn.Close();
            this.diagnosticoTableAdapter.Fill(this.hospitalDataSet.Diagnostico);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Conexion.conexionn.Open();
            SqlCommand xd = new SqlCommand("Update Diagnostico set status=0 where ID_Diagnostico = @ID_Diagnostico", Conexion.conexionn);
            xd.Parameters.AddWithValue("@ID_Diagnostico", Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
            xd.ExecuteNonQuery();
            Conexion.conexionn.Close();
            this.diagnosticoTableAdapter.Fill(this.hospitalDataSet.Diagnostico);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmInicio Menu = new FrmInicio();
            Menu.Show();
            this.Hide();
        }
    }
}
