using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; 

namespace SistemaAlumnos
{
    class Alumno
    {

        public Int16 claveUnica { get; set;}
        public String nombre { get; set; }
        public String sexo { get; set; } 
        public String correo { get; set;} 
        public Int16 semestre { get; set; }
        public int programa { get; set; }

        public Alumno()
        {
        }

        public Alumno(short claveUnica, string correo)
        {
            this.claveUnica = claveUnica;
            this.correo = correo;
        }

        public Alumno(short claveUnica, string nombre, string sexo, string correo, short semestre, int programa)
        {
            this.claveUnica = claveUnica;
            this.nombre = nombre;
            this.sexo = sexo;
            this.correo = correo;
            this.semestre = semestre;
            this.programa = programa;
        }

        //función de agregar un alumno a la tabla Alumno, regresa un entero positivo si lo pudo agregar
        // o un entero negativo si no pudo agregarlo. 

        public int agregar(Alumno a)
        {
            int resultado = 0;
            // abrir la conexión 
            SqlConnection con;
            con = Conexion.conectar();
            // command para ejecutar el query(insert) 
            SqlCommand cmd = new SqlCommand(String.Format("insert into alumno (claveUnica, nombre, sexo, correo, semestre, idPrograma) " +
                 "values ({0},'{1}', '{2}','{3}', {4}, {5})", a.claveUnica, a.nombre, a.sexo, a.correo, a.semestre, a.programa), con);
            resultado = cmd.ExecuteNonQuery();
            con.Close(); 
            return resultado; 
        }

        public int eliminar(int cu)
        {
            int resultado = 0;
            SqlConnection con;
            con = Conexion.conectar();
            SqlCommand cmd = new SqlCommand(String.Format("delete from alumno where claveUnica = {0}", cu), con); 
            resultado = cmd.ExecuteNonQuery();
            con.Close();
            return resultado; 
        }

        public int modificar(Alumno a)
        {
            int resultado = 0;
            SqlConnection con;
            con = Conexion.conectar();
            SqlCommand cmd = new SqlCommand(String.Format("update alumno set correo = '{0}' where claveUnica = {1}",a.correo, a.claveUnica), con);
            resultado = cmd.ExecuteNonQuery();
            con.Close();
            return resultado; 
        }

        public List<Alumno> buscar(string nombre)
        {
            List<Alumno> lista = new List<Alumno>();
            SqlDataReader rd; 
            Alumno a;
            SqlConnection con;
            con = Conexion.conectar();
            SqlCommand cmd = new SqlCommand(String.Format("select * from alumno where nombre like '%{0}%' ", nombre), con);
            rd = cmd.ExecuteReader(); 
            while(rd.Read())
            {
                a = new Alumno();
                a.claveUnica = rd.GetInt16(0);
                a.nombre = rd.GetString(1);
                a.sexo = rd.GetString(2);
                a.correo = rd.GetString(3);
                a.semestre = rd.GetInt16(4);
                a.programa = rd.GetInt16(5);
                lista.Add(a); 
            }
            con.Close();
            return lista; 
        } 
    }
}
