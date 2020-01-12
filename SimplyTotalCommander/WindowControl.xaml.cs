using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;


namespace SimplyTotalCommander
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class WindowControl : UserControl
    {
        // Main argument into FileReaders methods.
        // Collections
        ObservableCollection<FileDataObject> _fileList = new ObservableCollection<FileDataObject>();
        private ObservableCollection<string> listOfFilesName = new ObservableCollection<string>();
        private ObservableCollection<string> listOfDirectoryNames = new ObservableCollection<string>();
        private DirectoryInfo listOfDirectories;
        // Instances
        FileReader fileReader = new FileReader();
        public WindowControl()
        {
            InitializeComponent();
        }
        public void UpdateSourceEvent()
        {

        }
        // Update datagrid with desktop path at window load
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
            listOfDirectories = new DirectoryInfo(NewPath.Text);
            fileReader.Refresh(NewPath.Text);

            DataGridOfFiles.ItemsSource = fileReader.ListOfFiles;
            SeachBox.ItemsSource = fileReader.ListOfFiles;
            ListOfDirectory.ItemsSource = fileReader.ListOfDirectoriesName;
            DirectoriesTree.ItemsSource = fileReader.ListOfDirectoriesName;
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
        private void DirectoryButton(object sender, RoutedEventArgs e)
        {
           // hiddenButton.Visiblity = Visibility.Collapsed; 
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
        //Dodane przez hutnika
        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            
            DirectoryInfo dir = new DirectoryInfo(NewPath.Text != ""?NewPath.Text:Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            //var list = listOfDirectories;
            var item = sender as ListViewItem;
            
            if (item != null && item.IsSelected)
            {
                string value = item.Content.ToString();

                if (value == "..")
                {
                    try
                    {
                        NewPath.Text = dir.Parent.FullName;
                        Button_Click(sender, e);
                    }
                    catch { }
                }
                else
                {
                    foreach (var element in dir.GetDirectories(value, SearchOption.TopDirectoryOnly))
                    {
                        NewPath.Text = element.FullName;
                        Button_Click(sender, e);
                        break;
                    }
                }
            }
        }

        private ICollectionView CollectionViewSource()
        {
            throw new NotImplementedException();
        }

        //Dodane przez hutnika
    }
}
