
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroes
{
    class Superheroe : INotifyPropertyChanged
    {

        public string Nombre { get; set; }

        public string Imagen { get; set; }

        public bool Vengador { get; set; }

        public bool Xmen { get; set; }

        public bool Heroe { get; set; }

       public bool Villano { get; set; }
        public void OnVillanoChanged()
        {
            if (Villano)
            {
                Vengador = false;
                Xmen = false;
            }
        }


        public Superheroe()
        {
        }

        public Superheroe(string nombre, string imagen, bool vengador, bool xmen, bool heroe, bool villano)
        {
            Nombre = nombre;
            Imagen = imagen;
            Vengador = vengador;
            Xmen = xmen;
            Heroe = heroe;
            Villano = villano;
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
