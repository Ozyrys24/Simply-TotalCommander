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
using FileReader;

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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {           
            FileReader.FileReader.ProcessCurrentDirectory(newPath.Text, listOfFiles);
            dataGridOfFiles.ItemsSource = listOfFiles;
        }

        private void DataGridOfFiles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FileReader.FileReader.ProcessCurrentDirectory(newPath.Text, listOfFiles);
        }
    }
}
