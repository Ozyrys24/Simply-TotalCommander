using System.Windows.Input;

namespace SimplyTotalCommander
{
    //route through the element hierarchy
    public static class CustomCommands
    {
        public static RoutedUICommand zipIt = new RoutedUICommand("Zip to...", "ZipIt", typeof(CustomCommands));
        public static RoutedUICommand ZipIt => zipIt;

        public static RoutedUICommand unZipIt = new RoutedUICommand("UnZip to...", "UnZipIt", typeof(CustomCommands));
        public static RoutedUICommand UnZipIt => unZipIt;
        
        public static RoutedUICommand newFile = new RoutedUICommand("New File Txt", "newFileTxt", typeof(CustomCommands));
        public static RoutedUICommand NewFile => newFile;
    }
}
