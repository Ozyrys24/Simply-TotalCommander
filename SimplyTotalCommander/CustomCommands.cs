using System.Windows.Input;

namespace SimplyTotalCommander
{
    public static class CustomCommands
    {
        public static RoutedUICommand zipIt = new RoutedUICommand("Zip to...", "ZipIt", typeof(CustomCommands));
        public static RoutedUICommand ZipIt => zipIt;

        public static RoutedUICommand unZipIt = new RoutedUICommand("UnZip to...", "UnZipIt", typeof(CustomCommands));
        public static RoutedUICommand UnZipIt => unZipIt;
    }
}
