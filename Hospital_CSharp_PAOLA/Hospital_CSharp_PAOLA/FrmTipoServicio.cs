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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Hospital_C_
{
    public partial class FrmTipoServicio : Form
    {
        public FrmTipoServicio()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Conexion.conexionn.Open();
            SqlCommand xd = new SqlCommand(@"Insert into Tipo_Servicio (Costo,AreaRelacionada,ID_Atencion,ID_Servicio,ID_DFactura,Medico_crea,Medico_actualiza)
            values(@Costo,@AreaRelacionada,@ID_Atencion,@ID_Servicio,@ID_DFactura,@Medico_crea,@Medico_actualiza)", Conexion.conexionn);
            xd.Parameters.AddWithValue("@Costo", textBox1.Text);
            xd.Parameters.AddWithValue("@AreaRelacionada", textBox2.Text);
            xd.Parameters.AddWithValue("@ID_Atencion", comboBox1.SelectedValue);
            xd.Parameters.AddWithValue("@ID_Servicio", comboBox2.SelectedValue);
            xd.Parameters.AddWithValue("@ID_DFactura", comboBox2.SelectedValue);
            xd.Parameters.AddWithValue("@Medico_crea", 1);
            xd.Parameters.AddWithValue("@Medico_actualiza", 1);
            xd.ExecuteNonQuery();
            Conexion.conexionn.Close();
            this.tipo_ServicioTableAdapter.Fill(this.hospitalDataSet.Tipo_Servicio);
        }

        private void FrmTipoServicio_Load(object sender, EventArgs e)
        {
            this.detalle_FacturaTableAdapter.Fill(this.hospitalDataSet.Detalle_Factura);
            this.servicioTableAdapter.Fill(this.hospitalDataSet.Servicio);
            this.atencionTableAdapter.Fill(this.hospitalDataSet.Atencion);
            this.tipo_ServicioTableAdapter.Fill(this.hospitalDataSet.Tipo_Servicio);

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Conexion.conexionn.Open();
            SqlCommand xd = new SqlCommand("Update Tipo_Servicio set  Costo=@Costo,AreaRelacionada=@AreaRelacionada,ID_Atencion=@ID_Atencion,ID_Servicio=@ID_Servicio,ID_DFactura=@ID_DFactura,Medico_crea=@Medico_crea,Medico_actualiza=@Medico_actualiza where ID_TServicio  = @ID_TServicio ", Conexion.conexionn);
            xd.Parameters.AddWithValue("@ID_TServicio", Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
            xd.Parameters.AddWithValue("@Costo", textBox1.Text);
            xd.Parameters.AddWithValue("@AreaRelacionada", textBox2.Text);
            xd.Parameters.AddWithValue("@ID_Atencion", comboBox1.SelectedValue);
            xd.Parameters.AddWithValue("@ID_Servicio", comboBox2.SelectedValue);
            xd.Parameters.AddWithValue("@ID_DFactura", comboBox2.SelectedValue);
            xd.Parameters.AddWithValue("@Medico_crea", 1);
            xd.Parameters.AddWithValue("@Medico_actualiza", 1);
            xd.ExecuteNonQuery();
            Conexion.conexionn.Close();
            this.tipo_ServicioTableAdapter.Fill(this.hospitalDataSet.Tipo_Servicio);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Conexion.conexionn.Open();
            SqlCommand xd = new SqlCommand("Update Diagnostico set status=0 where ID_TServicio = @ID_TServicio", Conexion.conexionn);
            xd.Parameters.AddWithValue("@ID_TServicio", Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
            xd.ExecuteNonQuery();
            Conexion.conexionn.Close();
            this.tipo_ServicioTableAdapter.Fill(this.hospitalDataSet.Tipo_Servicio);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmInicio Menu = new FrmInicio();
            Menu.Show();
            this.Hide();
        }
    }
}
