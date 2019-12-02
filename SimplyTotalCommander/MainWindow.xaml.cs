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
using ClassLibrary1;

namespace SimplyTotalCommander
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // main argument into FileReaders methods.
        List<FileInfo> listOfFiles = new List<FileInfo>();
        private List<string> listOfFilesName = new List<string>();


        public MainWindow()
        {
            InitializeComponent();
        }

        // Refresh button on click is updating dataGrid of current directory and comboBox of files to choose
        private void Button_Click(object sender, RoutedEventArgs e)
        {           
            FileReader.ProcessCurrentDirectory(NewPath.Text, listOfFiles);
            dataGridOfFiles.ItemsSource = listOfFiles;
            FileReader.GetFilesNamesList(NewPath.Text, listOfFilesName);
            SelectedFile.ItemsSource = listOfFilesName;
        }

        private void DataGridOfFiles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
