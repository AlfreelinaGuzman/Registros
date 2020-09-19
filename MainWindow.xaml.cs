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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Registros.BLL;
using Registros.Entidades;


namespace Registros
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Personas Personas { get; private set; }
        public object Utilidades { get; private set; }
        public object IdTextBox { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
        }

///------------------LIMPIAR-------------------------------
private void Limpiar()
        {
           this.Personas = new Personas();
           this.DataContext = Personas;
            
        }

//-----------------------BOTON NUEVO------------------------------
        private void ButtonNuevo_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

//-----------------------BOTON GUARDAR------------------------------
        private void ButtonGuardar_Click(object sender, RoutedEventArgs e)
        {
            //Personas personas;
            bool Paso = false;

            if (!Validar())
               return;

            bool v = PersonasBLL.Guardar(Personas);
            var Paso = v;

            if (Paso)
            {
                Limpiar();
                MessageBox.Show("Se guardo correctamente!");
            }
            else
            {
                MessageBox.Show("Error al momento del guardado");
            }
        }
//-----------------------VALIDAR-----------------------------
        private bool Validar()
        {
            bool esValido = true;

            if (NombreTextBox.Text == 0)
            {
                esValido = false;
                MessageBox.Show("Transicion fallida","Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            return esValido;
        }

//-----------------------BOTON BUSCAR------------------------------
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var persona = PersonasBLL.Buscar(PersonasBLL.ToInt(IdTextBox.Text));

            if(Personas!= null)
            {
               this.Personas = Personas;
            }
            else
            {
              this.Personas = new Personas();
            }
            this.DataContext = this.Personas;
        }

//-----------------------BOTON ELIMINAR------------------------------
        private void ButtonEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (PersonasBLL.Eliminar(Convert.ToInt32()))
            {
                Limpiar();
                MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No fue posible eliminar", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}