﻿using System;
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
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;
using Entidades;

namespace Vista
{
    /// <summary>
    /// Lógica de interacción para Menu.xaml
    /// </summary>
    public partial class MaquetaMenu : MetroWindow
    {
        public MaquetaMenu(Empleado emp)
        {
            InitializeComponent();
            //tile.Title = emp.Nombre;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string targetView = ((Button)sender).Tag.ToString();
            //_TheFrame.Source = new Uri(targetView, UriKind.Relative);
        }
    }
}
