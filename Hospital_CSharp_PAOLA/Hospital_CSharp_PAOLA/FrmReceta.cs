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
    public partial class FrmReceta : Form
    {
        public FrmReceta()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Conexion.conexionn.Open();
            SqlCommand xd = new SqlCommand(@"Insert into Receta(FechaR,Indicaciones,ID_Medico,ID_Paciente,ID_Medicamento ,Medico_crea,Medico_actualiza)
        values(@FechaR,@Indicaciones,@ID_Medico,@ID_Paciente,@ID_Medicamento,@Medico_crea,@Medico_actualiza)", Conexion.conexionn);
            xd.Parameters.AddWithValue("@FechaR", txtFecha.Text);
            xd.Parameters.AddWithValue("@Indicaciones", txtIndicaciones.Text);
            xd.Parameters.AddWithValue("@ID_Medico", CBMedico.SelectedValue);
            xd.Parameters.AddWithValue("@ID_Paciente", CBPaciente.SelectedValue);
            xd.Parameters.AddWithValue("@ID_Medicamento", CBMedicamento.SelectedValue);
            xd.Parameters.AddWithValue("@Medico_crea", 1);
            xd.Parameters.AddWithValue("@Medico_actualiza", 1);
            xd.ExecuteNonQuery();
            Conexion.conexionn.Close();
            this.recetaTableAdapter.Fill(this.hospitalDataSet.Receta);
        }

        private void FrmReceta_Load(object sender, EventArgs e)
        {
            this.medicamentoTableAdapter.Fill(this.hospitalDataSet.Medicamento);
            this.pacienteTableAdapter.Fill(this.hospitalDataSet.Paciente);
            this.medicoTableAdapter.Fill(this.hospitalDataSet.Medico);
            this.recetaTableAdapter.Fill(this.hospitalDataSet.Receta);

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Conexion.conexionn.Open();
            SqlCommand xd = new SqlCommand("Update Receta set FechaR=@FechaR,Indicaciones=@Indicaciones,ID_Medico=@ID_Medico,ID_Paciente=@ID_Paciente,ID_Medicamento=@ID_Medicamento ,Medico_crea=@Medico_crea,Medico_actualiza=@Medico_actualiza where ID_Receta = @ID_Receta", Conexion.conexionn);
            xd.Parameters.AddWithValue("@ID_Receta", Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
            xd.Parameters.AddWithValue("@FechaR", txtFecha.Text);
            xd.Parameters.AddWithValue("@Indicaciones", txtIndicaciones.Text);
            xd.Parameters.AddWithValue("@ID_Medico", CBMedico.SelectedValue);
            xd.Parameters.AddWithValue("@ID_Paciente", CBPaciente.SelectedValue);
            xd.Parameters.AddWithValue("@ID_Medicamento", CBMedicamento.SelectedValue);
            xd.Parameters.AddWithValue("@Medico_crea", 1);
            xd.Parameters.AddWithValue("@Medico_actualiza", 1);
            xd.ExecuteNonQuery();
            Conexion.conexionn.Close();
            this.recetaTableAdapter.Fill(this.hospitalDataSet.Receta);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Conexion.conexionn.Open();
            SqlCommand xd = new SqlCommand("Update Receta set status=0 where ID_Receta = @ID_Receta", Conexion.conexionn);
            xd.Parameters.AddWithValue("@ID_Receta", Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
            xd.ExecuteNonQuery();
            Conexion.conexionn.Close();
            this.recetaTableAdapter.Fill(this.hospitalDataSet.Receta); ;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmInicio Menu = new FrmInicio();
            Menu.Show();
            this.Hide();
        }
    }
}
