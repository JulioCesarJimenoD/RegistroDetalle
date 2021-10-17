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
using RegistroDetalles.BLL;
using RegistroDetalles.Entidades;

namespace RegistroDetalles.UI.Registro
{
    /// <summary>
    /// Interaction logic for rUsuarios.xaml
    /// </summary>
    public partial class rUsuarios : Window
    {
        private Usuarios usuarios = new Usuarios();
        public rUsuarios()
        {
            InitializeComponent();
            this.DataContext = usuarios;
        }

        private bool Validar()
        {
            bool Valido = true;
            if (PermisoIdTextBox.Text.Length == 0)
            {
                Valido = false;
                MessageBox.Show("Campos vacios, Ingresa el Alias", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if(NombreTextBox.Text.Length == 0)
            {
                Valido = false;
                MessageBox.Show("Campo vacios, Ingresa el nombre completo", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            return Valido;
        }



        private void Limpiar()
        {
            this.usuarios = new Usuarios();
            this.DataContext = usuarios;
        }

       

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var usuarios = UsuariosBLL.Buscar(Utilidades.ToInt(IdTextBox.Text));
            if(usuarios != null)
                this.usuarios = usuarios;
                else
                {
                    this.usuarios = new Usuarios();
                    MessageBox.Show("No se ha encontrado", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                this.DataContext = this.usuarios;
      
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (Validar())
                return;
            var paso = UsuariosBLL.Guardar(usuarios);
            if (paso)
            {
                Limpiar();
                MessageBox.Show("Transaccion exitosa!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Transaccion Fallida", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Information);
        }



        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (UsuariosBLL.Eliminar(Utilidades.ToInt(IdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro eliminado", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Registro no eliminado", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }
        
        public class DateFormat : System.Windows.Data.IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (value == null) return null;
                return ((DateTime)value).ToString("dd/MM/yyyy");
            }
            public object ConvertBack(object valie, Type targeType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
}
