using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace WPF2_grade
{
    /// <summary>
    /// Interaction logic for MyWindowMain.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string arrowPath { get; set; }
        public string deletePath { get; set; }
        public string noPreviewPath { get; set; }
        public string imagesPath { get; set; }
        public BitmapImage noPreviewImageBitmap;
        public ObservableCollection<string> chosenPaths { get; set; }

        public ObservableCollection<string> filesInFolder { get; set; }
        public MainWindow()
        {
            
            InitializeComponent();
            string folderPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "MainWindowImages");
            noPreviewPath = System.IO.Path.Combine(folderPath, "no_preview_image.png");
            arrowPath = System.IO.Path.Combine(folderPath, "arrow_icon.png");
            deletePath = System.IO.Path.Combine(folderPath, "delete_icon.png");
            noPreviewImageBitmap = new BitmapImage();
            noPreviewImageBitmap.BeginInit();
            noPreviewImageBitmap.UriSource = new Uri(noPreviewPath, UriKind.Absolute);
            noPreviewImageBitmap.EndInit();
            Image img = new Image();
            img.Source = noPreviewImageBitmap;
            imageStackPanel.Children.Add(img);
            chosenPaths = new ObservableCollection<string>();
            filesInFolder = new ObservableCollection<string>();
            pomList.ItemsSource = filesInFolder;
            imagesPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Images");
            string[] files = Directory.GetFiles(imagesPath);
            foreach (string file in files)
            {
                File.Delete(file);
            }
            DataContext = this;

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFolderDialog openFolderDialog = new OpenFolderDialog();

            if (openFolderDialog.ShowDialog() == true)
            {
                string selectedFolderPath = openFolderDialog.FolderName;
                string[] pngAndImgFiles = Directory.GetFiles(selectedFolderPath, "*.jpg")
                                   .Concat(Directory.GetFiles(selectedFolderPath, "*.png"))
                                   .ToArray();
                foreach (var pom in pngAndImgFiles)
                {
                    filesInFolder.Add(pom);
                }

            }

        }

        private void arrowButton_Click(object sender, RoutedEventArgs e)
        {
            if (!chosenPaths.Contains(pomList.SelectedItem))
            {
                chosenPaths.Add(pomList.SelectedItem as string);
                string destinationFilePath = System.IO.Path.Combine(imagesPath, System.IO.Path.GetFileName(pomList.SelectedItem as string));
                File.Copy(pomList.SelectedItem as string, destinationFilePath);
            }

            if (chosenPaths.Count() > 0)
            {
                startLabelingButton.IsEnabled = true;
            }
            else
            {
                startLabelingButton.IsEnabled = false;
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
           
            if (pathsList.SelectedItem != null)
            {
                string destinationFilePath = System.IO.Path.Combine(imagesPath, System.IO.Path.GetFileName(pathsList.SelectedItem as string));
                File.Delete(destinationFilePath);
                chosenPaths.Remove(pathsList.SelectedItem as string);
            }
            if (chosenPaths.Count() > 0)
            {
                startLabelingButton.IsEnabled = true;
            }
            else
            {
                startLabelingButton.IsEnabled = false;
            }
        }

        private void SelectionChangedEvenet(object sender, SelectionChangedEventArgs e)
        {
      
            if (pathsList.SelectedItem == null)
            {
                imageStackPanel.Children.Clear();
                Image img = new Image();
                img.Source = noPreviewImageBitmap;
                imageStackPanel.Children.Add(img);
            }
            else
            {
                imageStackPanel.Children.Clear();
                BitmapImage imgBitmap = new();
                imgBitmap.BeginInit();
                imgBitmap.UriSource = new Uri(pathsList.SelectedItem as string, UriKind.Absolute);
                imgBitmap.EndInit();
                Image img = new();
                img.Source= imgBitmap;
                imageStackPanel.Children.Add(img);
            }
        }

        private void startLabelingButtonClick(object sender, RoutedEventArgs e)
        {
            SecondWindow secondWindow = new SecondWindow();
            secondWindow.Show();
        }
    }

    public class CaptionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return System.IO.Path.GetFileName(value as string);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
