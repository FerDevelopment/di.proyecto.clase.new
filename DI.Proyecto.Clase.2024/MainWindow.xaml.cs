﻿
using DI.Proyecto.Clase._2024.Backend.Modelo;
using DI.Proyecto.Clase._2024.Frontend.ControlUsuario;
using DI.Proyecto.Clase._2024.Frontend.Dialogos;
using DI.Proyecto.Clase._2024.MVVM;
using MahApps.Metro.Controls;
using MaterialDesignThemes.Wpf;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DI.Proyecto.Clase._2024
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private DiinventarioexamenContext contexto;
        private Usuario usuarioLogin;
        private MVModeloArticulo mvModeloArticulo;
        private MVArticulo mvCrearArticulo;
        private MVUsuario mvCrearUsuario;
   

        public MainWindow(DiinventarioexamenContext context, Usuario usu)
        {
            InitializeComponent();
            contexto = context;
            usuarioLogin = usu;
            nameOnTop.Text=usu.ToString();
            _ = IniciarMVs();
           
        }

        


        public async Task IniciarMVs()
        {
            mvModeloArticulo = new MVModeloArticulo(contexto);
            await mvModeloArticulo.Inicializa();
            mvCrearUsuario = new MVUsuario(contexto);
            await mvCrearUsuario.Inicializa();
            mvCrearArticulo = new MVArticulo(contexto);
            await mvCrearArticulo.Inicializa();

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void btnCrearArticulo_Click(object sender, RoutedEventArgs e)
        {
            ArticuloCrear ac = new ArticuloCrear(mvCrearArticulo, false);
            ac.ShowDialog();
        }

        private void btnCrearModelo_Click(object sender, RoutedEventArgs e)
        {
            DialogoModeloArticuloMVVM pantallaMVC = new DialogoModeloArticuloMVVM(mvModeloArticulo);
            pantallaMVC.ShowDialog();
        }

        private void crearUser_Click(object sender, RoutedEventArgs e)
        {
            UsuarioCrear pantallaCrearUser = new UsuarioCrear(mvCrearUsuario);
            pantallaCrearUser.ShowDialog();
        }


        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            panelPrincipal.Children.Clear();
        }
        private void btnListarModelos_Click(object sender, RoutedEventArgs e)
        {
            UCModeloArticulo uc =new UCModeloArticulo(mvModeloArticulo);
            panelPrincipal.Children.Clear();
            panelPrincipal.Children.Add(uc);
        }

        private void btnListarArticulos_Click(object sender, RoutedEventArgs e)
        {
            UCArticulo uc = new UCArticulo(mvCrearArticulo);
            panelPrincipal.Children.Clear();
            panelPrincipal.Children.Add(uc);
        }

        private void btnListarUsuarios_Click(object sender, RoutedEventArgs e)
        {
            UCUsuario uc = new UCUsuario(mvCrearUsuario);

            panelPrincipal.Children.Clear();
            panelPrincipal.Children.Add(uc);
        }

        private void btnListaAlumnos_Click(object sender, RoutedEventArgs e)
        {
            UCAlumnoTree uc = new UCAlumnoTree(mvCrearUsuario);
            panelPrincipal.Children.Clear();
            panelPrincipal.Children.Add(uc);
        }

        private void btnListaTipoArticulos_Click(object sender, RoutedEventArgs e)
        {
            UCTipoArticulo uc = new UCTipoArticulo(mvModeloArticulo, mvCrearArticulo);
            panelPrincipal.Children.Clear();
            panelPrincipal.Children.Add(uc);
        }
    }
}