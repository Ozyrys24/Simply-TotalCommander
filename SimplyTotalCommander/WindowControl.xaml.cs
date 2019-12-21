using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.IO;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimplyTotalCommander
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class WindowControl : UserControl
    {
        // main argument into FileReaders methods.
        // \/\/\/ Collections
        ObservableCollection<FileDataObject> _fileList = new ObservableCollection<FileDataObject>();
        List<FileDataObject> listOfFiles = new List<FileDataObject>();
        private List<string> listOfFilesName = new List<string>();
        private List<string> listOfDirectoryNames = new List<string>();
        // \/\/\/ Instances
        FileReader fileReader = new FileReader();
        public WindowControl()
        {
            InitializeComponent();
        }
        public void UpdateSourceEvent()
        {

        }
        // \/\/\/ Update datagrid with desktop path at window load
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            NewPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Button_Click(sender, e);
            NewPath.Clear();
        }
        // Refresh button on click is updating dataGrid of current directory and comboBox of files to choose
        // >>> Update lists<string> and ObservableCollection<FileDataObject> and send date into Xaml  
        // >> Xaml x:name VariableName > ItemsSource
        // ?  FileReader requiers : new PropertyChangedEventArg(string String)
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            fileReader.GetFilesNamesList(NewPath.Text, _fileList, listOfFilesName,listOfDirectoryNames,sender);
            fileReader.ProcessCurrentDirectory(NewPath.Text,_fileList,listOfDirectoryNames,sender,new PropertyChangedEventArgs("listOfFiles"));
            DataGridOfFiles.ItemsSource = _fileList;
            SeachBox.ItemsSource = _fileList;
            DataGridOfDirectory.ItemsSource = listOfDirectoryNames;
        }
        private void DataGridOfFiles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void DataGridOfDirectories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
        //    fileReader.ProcessSubDirectories(NewPath.Text, listOfDirectoriesName, sender, new PropertyChangedEventArgs("listOfFiles"));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {

        }
    }
}
