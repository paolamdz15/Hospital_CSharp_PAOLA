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
    public partial class FrmPaciente : Form
    {
        public FrmPaciente()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Conexion.conexionn.Open();
            SqlCommand cm = new SqlCommand(@"Insert into Paciente(NombreP,Ap_PaternoP,Ap_MaternoP,Edad,Peso,Medico_crea,Medico_actualiza)
            values(@NombreP,@Ap_PaternoP,@Ap_MaternoP,@Edad,@Peso,@Medico_crea,@Medico_actualiza)", Conexion.conexionn);
            cm.Parameters.AddWithValue("@NombreP", txtNombre.Text);
            cm.Parameters.AddWithValue("@Ap_PaternoP", ttAP.Text);
            cm.Parameters.AddWithValue("@Ap_MaternoP", ttAM.Text);
            cm.Parameters.AddWithValue("@Edad", txtEdad.Text);
            cm.Parameters.AddWithValue("@Peso", txtPeso.Text);
            cm.Parameters.AddWithValue("@Medico_crea", 1);
            cm.Parameters.AddWithValue("@Medico_actualiza", 1);
            cm.ExecuteNonQuery();
            Conexion.conexionn.Close();
            this.pacienteTableAdapter.Fill(this.hospitalDataSet.Paciente);
        }

        private void FrmPaciente_Load(object sender, EventArgs e)
        {
            this.pacienteTableAdapter.Fill(this.hospitalDataSet.Paciente);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Conexion.conexionn.Open();
            int edad;
            if (int.TryParse(txtEdad.Text, out edad))
            {
                decimal peso;
                if (decimal.TryParse(txtPeso.Text, out peso))
                {
                    SqlCommand cm = new SqlCommand("Update Paciente set NombreP=@NombreP,Ap_PaternoP=@Ap_PaternoP,Ap_MaternoP=@Ap_MaternoP,Edad=@Edad,Peso=@Peso,Medico_crea=@Medico_crea,Medico_actualiza=@Medico_actualiza where ID_Paciente = @ID_Paciente", Conexion.conexionn);
                    cm.Parameters.AddWithValue("@ID_Paciente", Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
                    cm.Parameters.AddWithValue("@NombreP", txtNombre.Text);
                    cm.Parameters.AddWithValue("@Ap_PaternoP", ttAP.Text);
                    cm.Parameters.AddWithValue("@Ap_MaternoP", ttAM.Text);
                    cm.Parameters.AddWithValue("@Edad", txtEdad.Text);
                    cm.Parameters.AddWithValue("@Peso", txtPeso.Text);
                    cm.Parameters.AddWithValue("@Medico_crea", 1);
                    cm.Parameters.AddWithValue("@Medico_actualiza", 1);
                    cm.ExecuteNonQuery();
                }
            }
            Conexion.conexionn.Close();
            this.pacienteTableAdapter.Fill(this.hospitalDataSet.Paciente);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Conexion.conexionn.Open();
            SqlCommand cm = new SqlCommand("Update Paciente set status=0 where ID_Paciente = @ID_Paciente", Conexion.conexionn);
            cm.Parameters.AddWithValue("@ID_Paciente", Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
            cm.ExecuteNonQuery();
            Conexion.conexionn.Close();
            this.pacienteTableAdapter.Fill(this.hospitalDataSet.Paciente);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmInicio Menu = new FrmInicio();
            Menu.Show();
            this.Hide();
        }
    }
}
