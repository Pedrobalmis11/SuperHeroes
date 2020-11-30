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
        //private bool disposed = false;
        Superheroe superheroe;
        List<Superheroe> listaSuperheroes = Superheroe.GetSamples();
        int cont = 0;

        public MainWindow()
        {
            InitializeComponent();
        }
     

        private void aceptarButton_Click(object sender, RoutedEventArgs e)
        {
            
            superheroe = (Superheroe)this.Resources["superheroe"];

            listaSuperheroes.Add(superheroe);
            this.Resources.Remove("superheroe");
            this.Resources.Add("superheroe", new Superheroe { Heroe=true} );

            MessageBox.Show("Superhéroe insertado con exito", "Superhéroes", MessageBoxButton.OK, MessageBoxImage.Information);
            
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

            fondoHeroeVillanoGrid.DataContext = listaSuperheroes[heroe];
                      
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
