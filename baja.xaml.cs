using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SistemaAlumnos
{
    /// <summary>
    /// Interaction logic for Baja.xaml
    /// </summary>
    public partial class Baja : Window
    {
        public Baja()
        {
            InitializeComponent();
        }

        private void btBaja_Click(object sender, RoutedEventArgs e)
        {
            int cu = Int16.Parse(tbFolio.Text);
            Alumno a = new Alumno();
            int resultado = a.eliminar(cu);
            if (resultado > 0)
                MessageBox.Show("Se eliminó correctamente al alumno.");
            else
                MessageBox.Show("No se pudo eliminar al alumno."); 
        }

        private void btRegresar_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Alta w = new Alta();
            w.Show(); 
        }
    }
}
