﻿using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        private List<string> listOfFilesName = new List<string>();
        private ObservableCollection<String> listOfDirectoryNames = new ObservableCollection<String>();
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
            fileReader.GetFilesNamesList(NewPath.Text, _fileList, listOfFilesName,listOfDirectoryNames,listOfDirectories,sender);
            fileReader.ProcessCurrentDirectory(NewPath.Text,_fileList,listOfDirectoryNames,sender,new PropertyChangedEventArgs("listOfFiles"), listOfDirectories);
            DataGridOfFiles.ItemsSource = _fileList;
            SeachBox.ItemsSource = _fileList;
            ListOfDirectory.ItemsSource = listOfDirectoryNames;
            DirectoriesTree.ItemsSource = listOfDirectoryNames;
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
                
                foreach (var element in dir.GetDirectories(value,SearchOption.TopDirectoryOnly))
                {

                    if (element.Name == value)
                    {

                        NewPath.Text = element.FullName;
                        Button_Click(sender,e);
                        //ICollectionView view = CollectionVie
                        //ListViewItem.
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
