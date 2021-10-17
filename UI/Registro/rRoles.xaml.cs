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
    /// Interaction logic for rRoles.xaml
    /// </summary>
    public partial class rRoles : Window
    {
        private Roles rol = new Roles();
        public rRoles()
        {
            InitializeComponent();
            this.DataContext = rol;
        }       

        private void Limpiar()
        {
            this.rol = new Roles();
            this.DataContext = rol;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var roles = RolesBLL.Buscar(Utilidades.ToInt(RolesIdTextBox.Text));
            if (roles != null)
                this.DataContext = rol;
            else
            {
                this.rol = new Roles();
                MessageBox.Show("No se ha encontrado", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            this.DataContext = this.rol;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (RolesBLL.DescripcionExiste(DescripcionTextBox.Text))
            {
                MessageBox.Show("El rol ya existe. Crea un rol nurvo", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            var paso = RolesBLL.Guardar(this.rol);
            if (paso)
            {
                Limpiar();
                MessageBox.Show("Transaccion exitosa!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Transaccion Fallida", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (RolesBLL.Eliminar(Utilidades.ToInt(RolesIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro Eliminado", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("El regisitro no pudo ser eliminado", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
