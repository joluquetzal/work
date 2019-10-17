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
                cnn = new SqlConnection("Data Source=CC102-P\\SA;Initial Catalog=baseSistemaAlumno;User ID=sa;Password=adminadmin");
                cnn.Open();
                MessageBox.Show("si se pudo hacer la conexión");
            } catch (Exception ex) {
                cnn = null;
                MessageBox.Show("no se pudo hacer la conexión" + ex);
            }
            return cnn;
        }

        public static String comprabarPwd(String usuario, String contra) {
            String res = "error";
            SqlDataReader rd;
            SqlConnection con;
            try {
                con = Conexion.conectar();
                SqlCommand cmd = new SqlCommand(String.Format("select contra from usuarios where nombreUsuario= '{0}'", usuario), con);
                rd = cmd.ExecuteReader();
                if (rd.Read()) {
                    if (rd.GetString(0).Equals(contra))
                        res = "contraseña correcta";
                    else
                        res= "contraseña INcorrecta";
                }
                else
                {
                    res = "usuario incorrecto";
                }
                con.Close();
                rd.Close();

            } catch (Exception ex) {
                res = "error" + ex;
            }
            return res;

        }

        public void llenarComboAlta(ComboBox cb) {
            try {
                SqlConnection con;
                con = Conexion.conectar();
                cmd = new SqlCommand("select nombre from programa",con);
                rd = cmd.ExecuteReader();
                while (rd.Read()) {
                    cb.Items.Add(rd["nombre"].ToString());
                }
                cb.SelectedIndex=0;
                rd.Close();
                con.Close();
            } catch (Exception ex) {
                MessageBox.Show("no se pudo llenar el combo" + ex);
            }
        }

    }
}
