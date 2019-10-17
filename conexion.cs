using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace SistemaAlumnos
{
    class Conexion
    {
        SqlCommand cmd;
        SqlDataReader rd; 

        public static SqlConnection conectar() {
            SqlConnection cnn;
            try {
                cnn = new SqlConnection("Data Source=CC102-29\\SA;Initial Catalog=baseSistemaAlumno;User ID=sa;Password=adminadmin");
                cnn.Open();
                
            } catch (Exception ex) {
                cnn = null;
                MessageBox.Show("No se pudo hacer la conexión" + ex);
            }
            return cnn; 
        }

        public static String comprobarPassword(String usuario, String contra)
        {
            String resultado = "Error";
            SqlDataReader rd;
            SqlConnection con;
            try {
                con = Conexion.conectar();
                SqlCommand cmd = new SqlCommand(String.Format("select contra from usuarios where nombreUsuario = '{0}'", usuario), con);
                rd = cmd.ExecuteReader();
                if (rd.Read()) {
                    if (rd.GetString(0).Equals(contra))
                        resultado = "Contraseña correcta";
                    else
                        resultado = "Contraseña incorrecta"; 
                } 
                else
                {
                    resultado = "Usuario incorrecto"; 
                }

            } catch (Exception ex) {
                resultado = resultado + ex; 
            }
            return resultado;
        }

        public void llenarComboAlta(ComboBox cb)
        {
            try
            {
                SqlConnection con;
                con = Conexion.conectar();
                cmd = new SqlCommand("select nombre from programa", con);
                rd = cmd.ExecuteReader(); 
                while (rd.Read())
                {
                    cb.Items.Add(rd["nombre"].ToString());
                }
                cb.SelectedIndex = 0;
                rd.Close();
                con.Close(); 

            } catch (Exception ex)
            {
                MessageBox.Show("No se pudo llenar el combo" + ex);
            }

        }
    }
}
