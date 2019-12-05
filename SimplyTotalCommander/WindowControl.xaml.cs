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
        ObservableCollection<FileDataObject> _fileList = new ObservableCollection<FileDataObject>();
        List<FileDataObject> listOfFiles = new List<FileDataObject>();
        List<FileDataObject> secondWindowListOfFiles = new List<FileDataObject>();
        private List<string> listOfFilesName = new List<string>();
        private List<string> secondWindowListOfFilesName = new List<string>();
        FileReader fileReader = new FileReader();
        public WindowControl()
        {
            InitializeComponent();
        }
        // Update datagrid with desktop path at window load
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            NewPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Button_Click(sender, e);
            NewPath.Clear();
        }
        // Refresh button on click is updating dataGrid of current directory and comboBox of files to choose
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            fileReader.GetFilesNamesList(NewPath.Text, _fileList, listOfFilesName,sender);
            dataGridOfFiles.ItemsSource = _fileList;
            SelectedFile.ItemsSource = listOfFilesName;
            fileReader.ProcessCurrentDirectory(NewPath.Text, _fileList, sender, new PropertyChangedEventArgs("listOfFiles"));
            fileReader.GetFilesNamesList(NewPath.Text, _fileList, listOfFilesName, sender);

        }
        private void DataGridOfFiles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

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
