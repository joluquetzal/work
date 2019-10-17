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
    /// Interaction logic for Modificar.xaml
    /// </summary>
    public partial class Modificar : Window
    {
        public Modificar()
        {
            InitializeComponent();
        }

        private void tbModificar_Click(object sender, RoutedEventArgs e)
        {
            short cu = short.Parse(tbFolio.Text);
            String correo = tbCorreo.Text; 
            Alumno a = new Alumno(cu, correo);
            int resultado = a.modificar(a);
            if (resultado > 0)
                MessageBox.Show("Se modificó correctamente.");
            else
                MessageBox.Show("No se pudo modificar.");
        }

        private void tbRegresar_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Alta w = new Alta();
            w.Show();
        }
    }
}
