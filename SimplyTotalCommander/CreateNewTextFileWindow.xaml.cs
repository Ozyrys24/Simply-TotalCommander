using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Forms;

namespace SimplyTotalCommander
{
    /// <summary>
    /// Interaction logic for the class CreateNewTextFileWindow.xaml
    /// </summary>
    public partial class CreateNewTextFileWindow : Window
    {
        public CreateNewTextFileWindow()
        {
            InitializeComponent();
        }


        private void CreateFileButton(object sender, RoutedEventArgs e)
        {
            string filePathWithName = destinyPath.Text + "//" + newFileName.Text;
            try
            {
                // Create the file, or overwrite if the file exists.
                FileStream fs = File.Create(filePathWithName);
            }

            catch (Exception ex)
            {
                errorMessage.Visibility = Visibility.Visible;
            }
        }

        private void chooseFolder_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderPathDialog = new FolderBrowserDialog();
            folderPathDialog.Description = "Choose path : ";
            folderPathDialog.ShowDialog();
            if (folderPathDialog.SelectedPath != "")
            {
                destinyPath.Text = folderPathDialog.SelectedPath;
            }
        }
    }
}
