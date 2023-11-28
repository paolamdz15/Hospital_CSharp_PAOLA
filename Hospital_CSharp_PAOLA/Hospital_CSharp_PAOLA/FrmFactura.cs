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
    public partial class FrmFactura : Form
    {
        public FrmFactura()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Conexion.conexionn.Open();
            SqlCommand xd = new SqlCommand(@"Insert into Factura(Fecha_Emision,Total,ID_Cliente,ID_DFactura,Medico_crea,Medico_actualiza)
            values(@Fecha_Emision,@Total,@ID_Cliente,@ID_DFactura,@Medico_crea,@Medico_actualiza)", Conexion.conexionn);
            xd.Parameters.AddWithValue("@Fecha_Emision", textBox1.Text);
            xd.Parameters.AddWithValue("@Total", textBox2.Text);
            xd.Parameters.AddWithValue("@ID_Cliente", ((DataRowView)comboBox1.SelectedItem)["ID_Cliente"]);
            xd.Parameters.AddWithValue("@ID_DFactura", ((DataRowView)comboBox2.SelectedItem)["ID_DFactura"]);
            xd.Parameters.AddWithValue("@Medico_crea", 1);
            xd.Parameters.AddWithValue("@Medico_actualiza", 1);
            xd.ExecuteNonQuery();
            Conexion.conexionn.Close();
            this.facturaTableAdapter.Fill(this.hospitalDataSet.Factura);
        }

        private void FrmFactura_Load(object sender, EventArgs e)
        {
            this.detalle_FacturaTableAdapter.Fill(this.hospitalDataSet.Detalle_Factura);
            this.clienteTableAdapter.Fill(this.hospitalDataSet.Cliente);
            this.facturaTableAdapter.Fill(this.hospitalDataSet.Factura);

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Conexion.conexionn.Open();
            SqlCommand xd = new SqlCommand("Update Factura set Fecha_Emision=@Fecha_Emision,Total=@Total,ID_Cliente=@ID_Cliente,ID_DFactura=@ID_DFactura,Medico_crea=@Medico_crea,Medico_actualiza=@Medico_actualiza where ID_Factura = @ID_Factura", Conexion.conexionn);
            xd.Parameters.AddWithValue("@ID_Factura", Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
            xd.Parameters.AddWithValue("@Fecha_Emision", textBox1.Text);
            xd.Parameters.AddWithValue("@Total", textBox2.Text);
            xd.Parameters.AddWithValue("@ID_Cliente", ((DataRowView)comboBox1.SelectedItem)["ID_Cliente"]);
            xd.Parameters.AddWithValue("@ID_DFactura", ((DataRowView)comboBox2.SelectedItem)["ID_DFactura"]);
            xd.Parameters.AddWithValue("@Medico_crea", 1);
            xd.Parameters.AddWithValue("@Medico_actualiza", 1);
            xd.ExecuteNonQuery();
            Conexion.conexionn.Close();
            this.facturaTableAdapter.Fill(this.hospitalDataSet.Factura);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Conexion.conexionn.Open();
            SqlCommand xd = new SqlCommand("Update Factura set status=0 where ID_Factura = @ID_Factura", Conexion.conexionn);
            xd.Parameters.AddWithValue("@ID_Factura", Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
            xd.ExecuteNonQuery();
            Conexion.conexionn.Close();
            this.facturaTableAdapter.Fill(this.hospitalDataSet.Factura);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmInicio Menu = new FrmInicio();
            Menu.Show();
            this.Hide();
        }
    }
}
