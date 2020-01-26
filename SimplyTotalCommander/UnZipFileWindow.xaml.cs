using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Logika interakcji dla klasy ZipFileWindow.xaml
    /// </summary>
    public partial class UnZipFileWindow : Window
    {
        public UnZipFileWindow()
        {
            InitializeComponent();
        }

        private void CancelUnZip(object sender, RoutedEventArgs e)
        {
            App.Current.Windows[1].Close();
        }

        private void ChooseDestinyUnZipPath(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderPathDialog = new FolderBrowserDialog();
            folderPathDialog.Description = "Choose path : ";
            folderPathDialog.ShowDialog();
            if (folderPathDialog.SelectedPath != "")
            {
                destinyPath.Text = folderPathDialog.SelectedPath;
            }
        }
        private void OnUnzip(object sender, RoutedEventArgs e)
        {
            AcceptUnZipFile(sender, e);
        }
        private void AcceptUnZipFile(object sender, RoutedEventArgs e)
        {
            acceptButton.Visibility = Visibility.Hidden;
            cancelButton.Visibility = Visibility.Hidden;
            string path = destinyPath.Text + "\\" + fileName.Text + fileExtension.Text;
            string destPath = destinyPath.Text;
            string filename = fileName.Text;

            
            try
            {
                var thread = new Thread(t =>
               {
                   using (ZipFile zip = ZipFile.Read(path))
                   {
                       zip.ExtractProgress += new EventHandler<ExtractProgressEventArgs>(ExtractProgress);

                       zip.ExtractExistingFile = ExtractExistingFileAction.OverwriteSilently;
                       zip.ExtractAll($"{destPath}\\{filename}");
                       System.Windows.MessageBox.Show($"{filename} has been unzipped.");
                       this.Dispatcher.Invoke(() => { CancelUnZip(sender, e); });
                   }
               })
                { IsBackground = true };
                thread.Start();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error extract file from archive .\n" +
                ex.Message);
            }
        }
        private void ExtractProgress(object sender, ExtractProgressEventArgs e)
        {
            if (e.EntriesTotal > 0)
            {
                progressBar.Dispatcher.Invoke(() =>
                {
                    progressBar.Visibility = Visibility.Visible;
                    progressBar.Maximum = e.EntriesTotal;
                    progressBar.Value = e.EntriesExtracted;
                });
            }
        }
    }
}
