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
    public partial class FrmAtencion : Form
    {
        public FrmAtencion()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Conexion.conexionn.Open();
            SqlCommand xd = new SqlCommand(@"Insert into Atencion(FechaA,Hora_Inicio,Hora_Fin,ID_Medico,ID_Paciente,Medico_crea,Medico_actualiza)
            values(@FechaA,@Hora_Inicio,@Hora_Fin,@ID_Medico,@ID_Paciente,@Medico_crea,@Medico_actualiza)", Conexion.conexionn);
            xd.Parameters.AddWithValue("@FechaA", SqlDbType.Date).Value = Convert.ToDateTime(txtFecha.Text);
            xd.Parameters.AddWithValue("@Hora_Inicio", SqlDbType.Time).Value = Convert.ToDateTime(txtHora1.Text);
            xd.Parameters.AddWithValue("@Hora_Fin", SqlDbType.Time).Value = Convert.ToDateTime(TxtHora2.Text);
            xd.Parameters.AddWithValue("@ID_Medico", CBMedico.SelectedValue);
            xd.Parameters.AddWithValue("@ID_Paciente", CBPaciente.SelectedValue);
            xd.Parameters.AddWithValue("@Medico_crea", 1);
            xd.Parameters.AddWithValue("@Medico_actualiza", 1);
            xd.ExecuteNonQuery();
            Conexion.conexionn.Close();
            this.atencionTableAdapter.Fill(this.hospitalDataSet.Atencion);
        }

        private void FrmAtencion_Load(object sender, EventArgs e)
        {
            this.pacienteTableAdapter.Fill(this.hospitalDataSet.Paciente);
            this.medicoTableAdapter.Fill(this.hospitalDataSet.Medico);
            this.atencionTableAdapter.Fill(this.hospitalDataSet.Atencion);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Conexion.conexionn.Open();
            SqlCommand xd = new SqlCommand("Update Atencion set FechaA=@FechaA,Hora_Inicio=@Hora_Inicio,Hora_Fin=@Hora_Fin,ID_Medico=@ID_Medico,ID_Paciente=@ID_Paciente,Medico_crea=@Medico_crea,Medico_actualiza=@Medico_actualiza where ID_Medico = @ID_Medico", Conexion.conexionn);
            xd.Parameters.AddWithValue("@ID_Atencion", Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
            xd.Parameters.AddWithValue("@FechaA", SqlDbType.Date).Value = Convert.ToDateTime(txtFecha.Text);
            xd.Parameters.AddWithValue("@Hora_Inicio", SqlDbType.Time).Value = Convert.ToDateTime(txtHora1.Text);
            xd.Parameters.AddWithValue("@Hora_Fin", SqlDbType.Time).Value = Convert.ToDateTime(TxtHora2.Text);
            xd.Parameters.AddWithValue("@ID_Medico", CBMedico.SelectedValue);
            xd.Parameters.AddWithValue("@ID_Paciente", CBPaciente.SelectedValue);
            xd.Parameters.AddWithValue("@Medico_crea", 1);
            xd.Parameters.AddWithValue("@Medico_actualiza", 1);
            xd.ExecuteNonQuery();
            Conexion.conexionn.Close();
            this.atencionTableAdapter.Fill(this.hospitalDataSet.Atencion);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Conexion.conexionn.Open();
            SqlCommand xd = new SqlCommand("Update Atencion set status=0 where ID_Atencion = @ID_Atencion", Conexion.conexionn);
            xd.Parameters.AddWithValue("@ID_Atencion", Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
            xd.ExecuteNonQuery();
            Conexion.conexionn.Close();
            this.atencionTableAdapter.Fill(this.hospitalDataSet.Atencion);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmInicio Menu = new FrmInicio();
            Menu.Show();
            this.Hide();
        }
    }
}
