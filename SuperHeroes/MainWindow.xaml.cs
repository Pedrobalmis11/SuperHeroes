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

        MainWindowVM _vm;

        public MainWindow()
        {
            _vm = new MainWindowVM();
            InitializeComponent();
            this.DataContext = _vm;
        }

        private void Añadir_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            _vm.AñadirSuperHeroe();
            MessageBox.Show("SuperHeroe añadido con éxito", "PersonaMVVM", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Limpiar_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            _vm.VaciarSuperHeroe();
        }

        private void Siguiente_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            _vm.Siguiente();
        }

        private void Anterior_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            _vm.Anterior();
        }

    }
}
