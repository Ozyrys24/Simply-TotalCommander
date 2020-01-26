using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
        private FileReader fileReader = new FileReader();
        private static List<FileDataObject> CopyFiles = new List<FileDataObject>();
        private static bool ToDelete = false;
        private static List<WindowControl> WindowsList = new List<WindowControl>();




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
            fileReader.mainPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            WindowsList.Add(this);
            Button_Click(sender, e);
        }

        // Refresh button on click is updating dataGrid of current directory and comboBox of files to choose
        // >>> Update lists<string> and ObservableCollection<FileDataObject> and send date into Xaml  
        // >> Xaml x:name VariableName > ItemsSource
        // ?  FileReader requiers : new PropertyChangedEventArg(string String)
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var window in WindowsList)
            {
            window.fileReader.Refresh(window.fileReader.mainPath);
            window.DataGridOfFiles.ItemsSource = window.fileReader.ListOfFiles;
            window.SeachBox.ItemsSource = window.fileReader.ListOfFiles;
            window.ListOfDirectory.ItemsSource = window.fileReader.ListOfDirectoriesName;
            }
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
        
        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //new DirectoryInfo(NewPath.Text != ""?NewPath.Text:Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            DirectoryInfo dir = fileReader.ListOfDirectories; 
            
            //var list = listOfDirectories;
            var item = sender as ListViewItem;
            
            if (item != null && item.IsSelected)
            {
                string value = item.Content.ToString();
                if (value == "..")
                {
                    if (dir.Parent?.FullName != null)
                    {
                        fileReader.mainPath = dir.Parent.FullName;
                    }
                        Button_Click(sender, e);
                }
                else
                {
                    foreach (var element in dir.GetDirectories(value, SearchOption.TopDirectoryOnly))
                    {
                        if (element.Name == value)
                        {
                            fileReader.mainPath = element.FullName;
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

        private void Copy_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var selectedList = DataGridOfFiles.SelectedItems;
            foreach (var item in selectedList)
            {
                FileDataObject file = (FileDataObject)item;
                CopyFiles.Add(file);
            }
            ToDelete = false;
        }

        private void Paste_CanExecuted(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void NewFile_Executed(object sender, EventArgs e)
        {
            CreateNewTextFileWindow window = new CreateNewTextFileWindow();
            window.DataContext = fileReader.mainPath;
            window.ShowDialog();
            Button_Click(sender, (RoutedEventArgs)e);
        }
        
        private void openProperties_Executed(object sender, EventArgs e) 
        {
            PropertiesWindow window = new PropertiesWindow();
            window.DataContext = (FileDataObject)DataGridOfFiles.SelectedItem;
            window.ShowDialog();
        }

        private void zipFile_Executed(object sender, EventArgs e)
        {
            ZipFileWindow window = new ZipFileWindow();
            window.DataContext = (FileDataObject)DataGridOfFiles.SelectedItem ;
            window.ShowDialog();
            Button_Click(sender, (RoutedEventArgs)e);
        }

        private void unZipFile_Executed(object sender, EventArgs e)
        {
            var dataGrid = sender as DataGrid;
            var file = (FileDataObject)dataGrid.SelectedItem;
            var extention = file.extension;
            if (extention.ToLower() != ".zip") return;

            UnZipFileWindow window = new UnZipFileWindow();
            window.DataContext = (FileDataObject)DataGridOfFiles.SelectedItem;
            window.ShowDialog();
            Button_Click(sender, (RoutedEventArgs)e);
        }

        private void Paste_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            foreach (var file in CopyFiles)
            {
                if (file.path != null)
                {
                    //MessageBox.Show(string.Format($"{fileReader.ListOfDirectories.FullName}\\{file.fileName}{file.extension}"));
                    if (!File.Exists(string.Format($"{fileReader.ListOfDirectories.FullName}\\{file.fileName}{file.extension}")))
                    {
                        File.Copy(file.path, string.Format($"{fileReader.ListOfDirectories.FullName}\\{file.fileName}{file.extension}"));
                        if (ToDelete) File.Delete(file.path);
                    }
                }
            }

            ToDelete = false;

            Button_Click(sender,e);
        }

        private void Delete_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var selectedList = DataGridOfFiles.SelectedItems;

            foreach(var file in selectedList)
                File.Delete(((FileDataObject)file).path);

            ToDelete = false;
            Button_Click(sender, e);
        }
        
        private void Open_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var selectedElement = sender as DataGrid;
            var file = (FileDataObject) selectedElement.SelectedItem;
            Process openFile = new Process();
            openFile.StartInfo.FileName = "explorer";
            openFile.StartInfo.Arguments = "\"" + file.path + "\"";
            openFile.Start();
        }

        private void Cut_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            CopyFiles.Clear();
            var selectedElement = sender as DataGrid;
            var selectedList = selectedElement.SelectedItems;
            var selected = sender as DataGridRow;
           // selectedElement..Opacity = .5;

            foreach (var item in selectedList)
            {
                FileDataObject file = (FileDataObject)item;
                CopyFiles.Add(file);
            }

            ToDelete = true;
        }

        private void DataGridOfFiles_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var datagrid = sender as DataGrid;
            datagrid.Focus();
        }

        private void DataGridOfFiles_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            CopyFiles.Clear(); 
            var selectedElement = sender as DataGrid;
            var file = (FileDataObject)selectedElement.SelectedItem;
            Process openFile = new Process();
            openFile.StartInfo.FileName = "explorer";
            openFile.StartInfo.Arguments = "\"" + file.path + "\"";
            openFile.Start();
        }

    }
}
