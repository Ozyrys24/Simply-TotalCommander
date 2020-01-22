using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SimplyTotalCommander
{
    /// <summary>
    /// Logika interakcji dla klasy ZipFileWindow.xaml
    /// </summary>
    public partial class ZipFileWindow : Window
    {
        public ZipFileWindow()
        {
            InitializeComponent();
        }

        private void CancleZip(object sender, RoutedEventArgs e)
        {
            App.Current.Windows[1].Close();
        }

        private void ChooseDestinyZipPath(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderPathDialog = new FolderBrowserDialog();
            folderPathDialog.Description = "Choose path : ";
            folderPathDialog.ShowDialog();
            if (folderPathDialog.SelectedPath != null)
            {
                destinyPath.Text = folderPathDialog.SelectedPath;
            }
        }
        private void AcceptZipFile(object sender, EventArgs e)
        {
                try
                {
                    using (ZipFile zip = new ZipFile(destinyPath.Text+"\\" + fileName.Text + ".Zip"))
                    {
                    zip.SaveProgress += SaveProgress;
                        // Add the file to the Zip archive's root folder.
                        zip.AddFile(destinyPath.Text + "\\" + fileName.Text + fileExtension.Text);
                        // Save the Zip file.
                        zip.Save();
                    }
                        System.Windows.MessageBox.Show(fileName.Text + " has been zipped.");
                        acceptButton.Visibility = Visibility.Hidden;
                        chooseFolder.Visibility = Visibility.Hidden;
                }
                catch (Exception ex)
                {
                        System.Windows.MessageBox.Show("Error adding file to archive.\n" +
                        ex.Message);
                }            
        }
        private void SaveProgress(object sender, SaveProgressEventArgs e)
        {
            if( e.EventType == ZipProgressEventType.Saving_BeforeWriteEntry)
            {
                progressBar.Visibility = Visibility.Visible;
                progressBar.Dispatcher.Invoke(new MethodInvoker(delegate
                {
                    progressBar.Maximum = e.EntriesTotal;
                    progressBar.Value = e.EntriesSaved + 1;
                }
                ));
            }
        }
    }
}
