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
    public partial class FrmDetalleFactura : Form
    {
        public FrmDetalleFactura()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Conexion.conexionn.Open();
            SqlCommand ax = new SqlCommand("Insert into Detalle_Factura(Cantidad,Precio_Unitario,TotalD,Medico_crea,Medico_actualiza ) values (@Cantidad,@Precio_Unitario,@TotalD,@Medico_crea,@Medico_actualiza)", Conexion.conexionn);
            ax.Parameters.AddWithValue("@Cantidad", txtCantidad.Text);
            ax.Parameters.AddWithValue("@Precio_Unitario", txtPrecioU.Text);
            ax.Parameters.AddWithValue("@TotalD", txtTotalD.Text);
            ax.Parameters.AddWithValue("@Medico_crea", 1);
            ax.Parameters.AddWithValue("@Medico_actualiza", 1);
            ax.ExecuteNonQuery();
            Conexion.conexionn.Close();
            this.detalle_FacturaTableAdapter.Fill(this.hospitalDataSet.Detalle_Factura);
        }

        private void FrmDetalleFactura_Load(object sender, EventArgs e)
        {
            this.detalle_FacturaTableAdapter.Fill(this.hospitalDataSet.Detalle_Factura);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Conexion.conexionn.Open();
            SqlCommand ax = new SqlCommand("Update Detalle_Factura set Cantidad=@Cantidad,Precio_Unitario=@Precio_Unitario,TotalD=@TotalD,Medico_crea=@Medico_crea,Medico_actualiza=@Medico_actualiza where ID_DFactura = @ID_DFactura", Conexion.conexionn);
            ax.Parameters.AddWithValue("@ID_DFactura", Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
            ax.Parameters.AddWithValue("@Cantidad", txtCantidad.Text);
            ax.Parameters.AddWithValue("@Precio_Unitario", txtPrecioU.Text);
            ax.Parameters.AddWithValue("@TotalD", txtTotalD.Text);
            ax.Parameters.AddWithValue("@Medico_crea", 1);
            ax.Parameters.AddWithValue("@Medico_actualiza", 1);
            ax.ExecuteNonQuery();
            Conexion.conexionn.Close();
            this.detalle_FacturaTableAdapter.Fill(this.hospitalDataSet.Detalle_Factura);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Conexion.conexionn.Open();
            SqlCommand ax = new SqlCommand("Update Detalle_Factura set status=0 where ID_DFactura = @ID_DFactura", Conexion.conexionn);
            ax.Parameters.AddWithValue("@ID_DFactura", Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
            ax.ExecuteNonQuery();
            Conexion.conexionn.Close();
            this.detalle_FacturaTableAdapter.Fill(this.hospitalDataSet.Detalle_Factura);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmInicio Menu = new FrmInicio();
            Menu.Show();
            this.Hide();
        }
    }
}
