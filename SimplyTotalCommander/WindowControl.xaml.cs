using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SimplyTotalCommander
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class WindowControl : UserControl
    {
        // Main argument into FileReaders methods.
        // Collections
        // Instances
        FileReader fileReader = new FileReader();
        static List<FileDataObject> CopyFiles = new List<FileDataObject>();


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
        }
        // Refresh button on click is updating dataGrid of current directory and comboBox of files to choose
        // >>> Update lists<string> and ObservableCollection<FileDataObject> and send date into Xaml  
        // >> Xaml x:name VariableName > ItemsSource
        // ?  FileReader requiers : new PropertyChangedEventArg(string String)
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            fileReader.Refresh(NewPath.Text);
            DataGridOfFiles.ItemsSource = fileReader.ListOfFiles;
            SeachBox.ItemsSource = fileReader.ListOfFiles;
            ListOfDirectory.ItemsSource = fileReader.ListOfDirectoriesName;
        }
        private void DataGridOfFiles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void DataGridOfDirectories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
 
        private void DirectoryButton(object sender, RoutedEventArgs e)
        {

        }
        //Dodane przez hutnika
        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            
            DirectoryInfo dir = fileReader.ListOfDirectories; //new DirectoryInfo(NewPath.Text != ""?NewPath.Text:Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            //var list = listOfDirectories;
            var item = sender as ListViewItem;
            
            if (item != null && item.IsSelected)
            {
                string value = item.Content.ToString();
                if (value == "..")
                {

                    if (dir.Parent?.FullName != null)
                    {
                        NewPath.Text = dir.Parent.FullName;
                    }
                        Button_Click(sender, e);
                }
                else
                {
                    foreach (var element in dir.GetDirectories(value, SearchOption.TopDirectoryOnly))
                    {
                        if (element.Name == value)
                        {
                            NewPath.Text = element.FullName;
                            Button_Click(sender, e);
                            break;
                        }
                    }
                }
            }
        }

        private ICollectionView CollectionViewSource()
        {
            throw new NotImplementedException();
        }

        private void Copy_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Copy_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            CopyFiles.Clear();
            var selectedList = DataGridOfFiles.SelectedItems;
            foreach (var item in selectedList)
            {
                FileDataObject file = (FileDataObject)item;
                CopyFiles.Add(file);
            }
        }

        private void MenuItem_Paste_Click(object sender, RoutedEventArgs e)
        {
            foreach (var file in CopyFiles)
            {
                if (file.path != null)
                {
                    if (!File.Exists(string.Format($"{fileReader.ListOfDirectories.FullName}\\{file.fileName}{file.extension}")))
                        File.Copy(file.path, string.Format($"{fileReader.ListOfDirectories.FullName}\\{file.fileName}{file.extension}"));
                }
            }
                Button_Click(sender,e);
        }

        private void MenuItem_Delete_Click(object sender, RoutedEventArgs e)
        {
            var selectedList = DataGridOfFiles.SelectedItems;

            foreach(var file in selectedList)
                File.Delete(((FileDataObject)file).path);
            
            Button_Click(sender, e);
        }

        //Dodane przez hutnika
    }
}
