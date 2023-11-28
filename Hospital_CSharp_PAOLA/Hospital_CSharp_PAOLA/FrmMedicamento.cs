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
    public partial class FrmMedicamento : Form
    {
        public FrmMedicamento()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Conexion.conexionn.Open();
            SqlCommand mc = new SqlCommand("Insert into Medicamento (NombreM,Fecha_Caducidad,Medico_crea,Medico_actualiza) values (@NombreM,@Fecha_Caducidad,@Medico_crea,@Medico_actualiza)", Conexion.conexionn);
            mc.Parameters.AddWithValue("@NombreM", textBox1.Text);
            mc.Parameters.AddWithValue("@Fecha_Caducidad", textBox2.Text);
            mc.Parameters.AddWithValue("@Medico_crea", 1);
            mc.Parameters.AddWithValue("@Medico_actualiza", 1);
            mc.ExecuteNonQuery();
            Conexion.conexionn.Close();
            this.medicamentoTableAdapter.Fill(this.hospitalDataSet.Medicamento);
        }

        private void FrmMedicamento_Load(object sender, EventArgs e)
        {
            this.medicamentoTableAdapter.Fill(this.hospitalDataSet.Medicamento);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Conexion.conexionn.Open();
            SqlCommand mc = new SqlCommand("Update Medicamento set NombreM=@NombreM, Fecha_Caducidad=@Fecha_Caducidad,Medico_crea=@Medico_crea,Medico_actualiza=@Medico_actualiza where ID_Medicamento = @ID_Medicamento", Conexion.conexionn);
            mc.Parameters.AddWithValue("@ID_Medicamento", Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
            mc.Parameters.AddWithValue("@NombreM", textBox1.Text);
            mc.Parameters.AddWithValue("@Fecha_Caducidad", textBox2.Text);
            mc.Parameters.AddWithValue("@Medico_crea", 1);
            mc.Parameters.AddWithValue("@Medico_actualiza", 1);
            mc.ExecuteNonQuery();
            Conexion.conexionn.Close();
            this.medicamentoTableAdapter.Fill(this.hospitalDataSet.Medicamento);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Conexion.conexionn.Open();
            SqlCommand mc = new SqlCommand("Update Medicamento set status=0 where ID_Medicamento = @ID_Medicamento", Conexion.conexionn);
            mc.Parameters.AddWithValue("@ID_Medicamento", Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
            mc.ExecuteNonQuery();
            Conexion.conexionn.Close();
            this.medicamentoTableAdapter.Fill(this.hospitalDataSet.Medicamento);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmInicio Menu = new FrmInicio();
            Menu.Show();
            this.Hide();
        }
    }
}
