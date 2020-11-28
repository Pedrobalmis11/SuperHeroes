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
using SuperHeroes;

namespace SuperHeroes
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Superheroe superheroe;
        List<Superheroe> listaSuperheroes = Superheroe.GetSamples();
        int cont = 0;

        public MainWindow()
        {

            InitializeComponent();
            heroeRadioButton.IsChecked = true;
           
        }
     
        private void heroeRadioButton_Checked_Unchecked(object sender, RoutedEventArgs e)
        {
            if (heroeRadioButton.IsChecked == true)
            {
                vengadoresCheckBox.IsEnabled = true;
                xmenCheckbox.IsEnabled = true;
            }
            else
            {
                vengadoresCheckBox.IsEnabled = false;
                vengadoresCheckBox.IsChecked = false;
                xmenCheckbox.IsEnabled = false;
                xmenCheckbox.IsChecked = false;
            }
        }

        private void aceptarButton_Click(object sender, RoutedEventArgs e)
        {
            
            superheroe = (Superheroe)this.Resources["superheroe"];
            listaSuperheroes.Add(superheroe);
                      
            MessageBox.Show("Superhéroe insertado con exito", "Superhéroes", MessageBoxButton.OK, MessageBoxImage.Information);
            //Comprobación del objeto
            /*
            for (int i = 0; i < listaSuperheroes.Count; i++)
            {
                MessageBox.Show(listaSuperheroes[i].Nombre + "\n" + listaSuperheroes[i].Imagen + "\n" + listaSuperheroes[i].Heroe + "\n" + listaSuperheroes[i].Villano + "\n" + listaSuperheroes[i].Vengador + "\n" + listaSuperheroes[i].Xmen, "Superhéroes", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            
            MessageBox.Show("Nombre: " + superheroe.Nombre + " Imagen: " + superheroe.Imagen + " ¿Vengador?: " + superheroe.Vengador + " ¿XMEN?: " + superheroe.Xmen + " ¿Heroe?: " + superheroe.Heroe + " ¿Villano?: " + superheroe.Villano);
            */
        }

        private void limpiarButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            nombreTextBox.Text = "";
            linkImagenTextBox.Text = "";
            heroeRadioButton.IsChecked = true;
            vengadoresCheckBox.IsChecked = false;
            xmenCheckbox.IsChecked = false;
        }

        private void MostrarHeroe(int heroe)
        {
            //MessageBox.Show(listaSuperheroes[heroe].Nombre + "\n" + listaSuperheroes[heroe].Imagen + "\n" + listaSuperheroes[heroe].Heroe + "\n" + listaSuperheroes[heroe].Villano + "\n" + listaSuperheroes[heroe].Vengador + "\n" + listaSuperheroes[heroe].Xmen, "Superhéroes", MessageBoxButton.OK, MessageBoxImage.Information);
            //Establecer la paginación con el heroe+1 y el número maximo de heroes de la lista
            paginacionHeroeTextBlock.Text = heroe+1 + "/" + listaSuperheroes.Count;

            //Eliminar los controles dinamicos si los hubiese de los iconos, para que no se acumulen.       
            Image iconoVengador = new Image();
            Image iconoXmen = new Image();
            iconosStackPanel.Children.Clear();

            //Establecer el nombre y la imagen del heroe
            nombreHeroeTextBlock.Text = listaSuperheroes[heroe].Nombre;
            heroeImage.Source = new BitmapImage(new Uri(listaSuperheroes[heroe].Imagen, UriKind.Absolute));
                       
            //Si el heroe es un vengador poner el icono de Avengers
            if (listaSuperheroes[heroe].Vengador == true)
            {
                
                iconoVengador.Width = 40;
                iconoVengador.Source = new BitmapImage(new Uri("avengers.png", UriKind.Relative));
                iconoVengador.Margin = new Thickness(10);
                iconosStackPanel.Children.Add(iconoVengador);

            }
            //Si el heroe es un xmen poner el icono de Xmen
            if (listaSuperheroes[heroe].Xmen == true)
            {
                
                iconoXmen.Width = 50;
                iconoXmen.Source = new BitmapImage(new Uri("xmen.png", UriKind.Relative));
                iconoXmen.Margin = new Thickness(10);
                iconosStackPanel.Children.Add(iconoXmen);
            }

            //Si el heroe es un heroe poner fondo verde
            if (listaSuperheroes[heroe].Heroe == true)
            {
                fondoHeroeVillanoGrid.Background = new SolidColorBrush(Colors.PaleGreen);
            }
            //Si no lo es poner fondo rojo
            else if (listaSuperheroes[heroe].Villano == true)
            {
                fondoHeroeVillanoGrid.Background = new SolidColorBrush(Colors.IndianRed);
            }
            

        }


        private void siguienteImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
            cont++;        
            //Control antidesbordes de la lista si es mayor el contador
            if (cont > listaSuperheroes.Count-1)
            {
                cont = listaSuperheroes.Count-1;
            }
            MostrarHeroe(cont);

        }

        private void anteriorImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
            cont--;
            //Control antidesbordes de la lista si es menor el contador
            if (cont < 0)
            {
                cont = 0;
            }
            MostrarHeroe(cont);
        }



        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Al cambiar de pestaña mostrar el primero, y de paso se actualiza la lista
            MostrarHeroe(0);
            cont = 0;
        }
    }
}
