using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital_C_;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Hospital_C_
{
    public static class Conexion
    {
        public static SqlCommand cmd;
        public static SqlDataReader dr;

        public static SqlConnection conexionn = new SqlConnection("data source=DESKTOP-REBAD4R\\SQLEXPRESS; initial catalog=Hospital; integrated security=SSPI; persist security info=false; trusted_connection=yes;");

        public static bool existeUsuario(string Usuario)
        {
            bool resultado = false;
            try
            {
                cmd = new SqlCommand("select * from Medico where Usuario = '" + Usuario + "'", conexionn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                    resultado = true;
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la funcion existeUsuario: " + ex.ToString());
            }
            return resultado;
        }

        public static string obtenerContrasena(string Usuario)
        {
            string contra = "";
            try
            {
                cmd = new SqlCommand("Select Contrasena from Medico where Usuario='" + Usuario + "'", conexionn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                    contra = dr["Contrasena"].ToString();
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la funcion obtenerContrasena debido a: " + ex.ToString());
            }
            return contra;
        }
    }

}
        
            
        
        
     