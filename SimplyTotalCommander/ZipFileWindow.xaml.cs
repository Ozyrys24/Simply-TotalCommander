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

        private void AcceptZipFile(object sender, RoutedEventArgs e)
        {

        }

        // Add the file to the archive.
        private void AcceptZipFile(object sender, EventArgs e)
        {
                try
                {
                    using (ZipFile zip = new ZipFile())
                    {
                        // Add the file to the Zip archive's root folder.
                        zip.AddFile(destinyPath.Text);
                        zip.Encryption = EncryptionAlgorithm.WinZipAes256;
                        // Save the Zip file.
                        zip.Save(fileName.Text+".zip");
                    }
                        System.Windows.MessageBox.Show("Done");
                }
                catch (Exception ex)
                {
                        System.Windows.MessageBox.Show("Error adding file to archive.\n" +
                        ex.Message);
                }            
        }
    }
}
