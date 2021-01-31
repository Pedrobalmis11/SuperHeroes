using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SuperHeroes
{
    class CustomCommands
    {


        public static readonly RoutedUICommand Añadir = new RoutedUICommand(
            "Añadir", "Añadir",
            typeof(CustomCommands),
            new InputGestureCollection
            { new KeyGesture(Key.A,ModifierKeys.Control)}
            );

        public static readonly RoutedUICommand Limpiar = new RoutedUICommand(
            "Limpiar", "Limpiar",
            typeof(CustomCommands),
            new InputGestureCollection
            { new KeyGesture(Key.L,ModifierKeys.Control)}
            );

        public static readonly RoutedUICommand Siguiente = new RoutedUICommand(
            "Siguiente", "Siguiente",
            typeof(CustomCommands),
            new InputGestureCollection
            { new KeyGesture(Key.Right)}
            );

        public static readonly RoutedUICommand Anterior = new RoutedUICommand(
            "Anterior", "Anterior",
            typeof(CustomCommands),
            new InputGestureCollection
            { new KeyGesture(Key.Left)}
            );
    }
}
