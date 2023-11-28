using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Hospital_C_
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Conexion.conexionn.Open();
            if (Conexion.existeUsuario(txtUsuario.Text) == true)
            {
                if (txtContrasena.Text.Equals(Funciones.Desencriptar(Conexion.obtenerContrasena(txtUsuario.Text))))
                {
                    FrmInicio frmInicio = new FrmInicio();
                    this.Hide();
                    frmInicio.Show();
                }
                else
                    MessageBox.Show("La contraseña es invalida");
            }
            else
                MessageBox.Show("El usuario introducido no existe");

            Conexion.conexionn.Close();
        }

          
        }
    }


