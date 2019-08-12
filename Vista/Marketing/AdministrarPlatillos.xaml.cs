using Controlador;
using Entidades;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
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

namespace Vista
{
    /// <summary>
    /// Lógica de interacción para AdministrarPlatillos.xaml
    /// </summary>
    public partial class AdministrarPlatillos : MetroWindow
    {
        private Empleado guardado;
        private string rutaArchivo, mensaje;
        public AdministrarPlatillos()
        {
            InitializeComponent();
        }
        public AdministrarPlatillos(MenuMarketing menuMarketing, Empleado sesionEmpleado)
        {
            InitializeComponent();
            DataContext = new PlatilloController();
            guardado = sesionEmpleado;
        }

        private void AgregarImagen(object sender, RoutedEventArgs e)
        {
            PlatilloController plc = new PlatilloController();

            // Create OpenFileDialog
            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension  
            openFileDlg.DefaultExt = ".jpg";
            openFileDlg.Filter = "Text documents (.jpg)|*.jpg";

            // Launch OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = openFileDlg.ShowDialog();
            // Get the selected file name and display in a TextBox.
            // Load content of file in a TextBlock
            if (result == true)
            {
                txtSrc.Text = openFileDlg.SafeFileName;
                //TextBlock1.Text = System.IO.File.ReadAllText(openFileDlg.FileName);
                rutaArchivo = openFileDlg.FileName;

            }
        }

        private void VolverMenuPrincipal(object sender, RoutedEventArgs e)
        {
            MenuMarketing menuMarketing = new MenuMarketing(this, guardado);
            menuMarketing.Show();
            this.Close();
        }

        private async void AgregarPlatillo(object sender, RoutedEventArgs e)
        {
            PlatilloController plc = new PlatilloController();
            int res = plc.AgregarPlatillo(Convert.ToInt32(txtValor.Text), Convert.ToInt32(txtTiempoPreparacion.Text),
                txtDescripcion.Text, txtSrc.Text, txtNombre.Text);
            switch (res)
            {
                case 1:
                    mensaje = "Platillo Agregado";
                    await (plc.UploadFileAsync(rutaArchivo, txtSrc.Text));
                    break;
                case 2:
                    mensaje = "El tiempo de preparación supera las 2 horas";
                    break;
                case 3:
                    mensaje = "El valor del platillo supera los $10.000";
                    break;
                case 4:
                    mensaje = "El platillo ya existe";
                    break;
            }

            await this.ShowMessageAsync("Platillos", mensaje);



        }
    }
}
