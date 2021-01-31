using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroes
{
    class MainWindowVM : INotifyPropertyChanged
    {
        public Superheroe NuevoSuperHeroe { get; set; }
        public ObservableCollection<Superheroe> ListaSuperheroes { get; set; }

        public int SuperHeroeActual { get; set; }
        public int NumeroSuperHeroes{ get; set; }
        private ServicioSuperheroe _servicio;

        public Superheroe Actual => ListaSuperheroes[SuperHeroeActual - 1];


        public MainWindowVM()
        {
            SuperHeroeActual = 1;
            _servicio = new ServicioSuperheroe();
            NuevoSuperHeroe = new Superheroe();
            ListaSuperheroes = _servicio.ObtenerSuperHeroes();
            NumeroSuperHeroes = ListaSuperheroes.Count;
            
        }

        public void AñadirSuperHeroe()
        {
            ListaSuperheroes.Add(NuevoSuperHeroe);
            NumeroSuperHeroes++;
            NuevoSuperHeroe = new Superheroe(); //Heroe = true
        }
     

        public void VaciarSuperHeroe()
        {
            NuevoSuperHeroe = new Superheroe(); //Heroe = true
        }

        public void Siguiente()
        {
            if (SuperHeroeActual < NumeroSuperHeroes)
                SuperHeroeActual++;
        }

        public void Anterior()
        {
            if (SuperHeroeActual > 1)
                SuperHeroeActual--;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
