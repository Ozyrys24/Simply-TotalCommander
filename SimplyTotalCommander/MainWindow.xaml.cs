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
using System.Collections.ObjectModel;
using System.IO;

namespace SimplyTotalCommander
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // main argument into FileReaders methods.
        List<FileInfo> listOfFiles = new List<FileInfo>();
        // just testing strings
        string testPath = "C:\\Users\\wojta\\Desktop\\Nowy folder (2)\\12.jpg";
        string testPath1 = "C:\\Users\\wojta\\Desktop\\Nowy folder (2)\\zostaje";
        public MainWindow()
        {
            InitializeComponent();

            // Add files into list in specific directory path
            FileReader.FileReader.ProcessCurrentDirectory(testPath1, listOfFiles);

            // add list of files into data grid
            dataGridOfFiles.ItemsSource = listOfFiles;
        }
    }
}
