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
        private void AcceptUnZipFile(object sender, EventArgs e)
        {
                try
                {
                
                    using (ZipFile zip = ZipFile.Read(destinyPath.Text+"\\" + fileName.Text + ".Zip"))
                    {
                        zip.SaveProgress += SaveProgress;
                        // Add the file to the Zip archive's root folder.
                        zip.ExtractAll("\\",ExtractExistingFileAction.DoNotOverwrite);
                        // Save the Zip file.
                        zip.Save();
                    }
                        System.Windows.MessageBox.Show(fileName.Text + " has been unzipped.");
                        acceptButton.Visibility = Visibility.Hidden;
                        chooseFolder.Visibility = Visibility.Hidden;
                        CancelUnZip(sender,(RoutedEventArgs)e);
                }
                catch (Exception ex)
                {
                        System.Windows.MessageBox.Show("Error extract file from archive .\n" +
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
