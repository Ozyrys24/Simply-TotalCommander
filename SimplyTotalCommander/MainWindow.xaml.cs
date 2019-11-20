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
        List<FileInfo> listOfFiles = new List<FileInfo>();
        string testPath = "C:\\Users\\wojta\\Desktop\\Nowy folder (2)";
        string testPath1 = "C:\\Users\\wojta\\Desktop\\Nowy folder (2)\\zostaje";
        public MainWindow()
        {
            InitializeComponent();

            FileReader.FileReader.ProcessCurrentDirectory(testPath1, listOfFiles);
            dataGridOfFiles.ItemsSource = listOfFiles;


        }
    }
}
