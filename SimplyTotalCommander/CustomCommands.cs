using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimplyTotalCommander
{
    public static class CustomCommands
    {
        public static RoutedUICommand zipIt
= new RoutedUICommand("Zip to...",
          "ZipIt",
          typeof(CustomCommands));

        public static RoutedUICommand ZipIt { get { return zipIt; } }
    }
}
