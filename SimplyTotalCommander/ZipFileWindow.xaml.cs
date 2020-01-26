using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for the class ZipFileWindow.xaml
    /// </summary>
    public partial class ZipFileWindow : Window
    {
        public ZipFileWindow()
        {
            InitializeComponent();
        }

        private void CancelZip(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ChooseDestinyZipPath(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderPathDialog = new FolderBrowserDialog();
            folderPathDialog.Description = "Choose path : ";
            folderPathDialog.ShowDialog();
            if (folderPathDialog.SelectedPath != "")
            {
                destinyPath.Text = folderPathDialog.SelectedPath;
            }
        }
        private void AcceptZipFile(object sender, RoutedEventArgs e)
        {
            acceptButton.Visibility = Visibility.Hidden;
            cancelButton.Visibility = Visibility.Hidden;
            string fullname = destinyPath.Text + "\\" + fileName.Text + fileExtension.Text;
            string path = destinyPath.Text;
            string extension = fileExtension.Text;
            string name = fileName.Text;

            try
            {
                var thread = new Thread(t =>
                {
                    using (ZipFile zip = new ZipFile())
                    {
                        zip.SaveProgress += new EventHandler<SaveProgressEventArgs>(SaveProgress);
                        // Add the file to the Zip archive's root folder.
                        zip.AddFile(fullname,"\\");
                        // Save the Zip file.
                        zip.Save($"{path}\\{name}.Zip");
                    }
                    System.Windows.MessageBox.Show($"{name} has been zipped.");
                    this.Dispatcher.Invoke(() => { CancelZip(sender, e); });
                })
                { IsBackground = true };
                thread.Start();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error extract file from archive .\n" + ex.Message);
            }
        }
        /// <summary>
        /// updates the zip progress bar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveProgress(object sender, SaveProgressEventArgs e)
        {
            if (e.EntriesTotal > 0)
            {
                progressBar.Dispatcher.Invoke(() =>
                {
                    progressBar.Visibility = Visibility.Visible;
                    progressBar.Maximum = e.EntriesTotal;
                    progressBar.Value = e.EntriesSaved;
                });
            }

        }
    }
}
