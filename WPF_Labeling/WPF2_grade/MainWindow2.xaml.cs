using System;
using System.Collections.ObjectModel;
//using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;


namespace WPF2_grade
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        public string path { get; set; }
        public int count;
        public ObservableCollection<string> photoPaths { get; set; }    
        public ObservableCollection<LabelsClass> labels { get; set; }

        public ObservableCollection<RectanglesPerPhoto> rectPerPhoto { get; set; }

        public Point point { get; set; }

        public Rectangle rect { get; set; }
        public SecondWindow()
        {
            InitializeComponent();
            count = 0;
            photoPaths = new ObservableCollection<string>();
            path = Directory.GetCurrentDirectory();

            string baseDir = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string imagesFolder = System.IO.Path.Combine(baseDir, "Images");

            if (Directory.Exists(imagesFolder))
            {
                var imageFiles = Directory.GetFiles(imagesFolder, "*.*", SearchOption.TopDirectoryOnly)
                                          .Where(s => s.EndsWith(".png") || s.EndsWith(".jpg"));

                foreach (var imagePath in imageFiles)
                {
                    photoPaths.Add(imagePath);
                }
            }
            rectPerPhoto = new ObservableCollection<RectanglesPerPhoto>();
            for(int i=0; i<photoPaths.Count(); i++)
            {
                rectPerPhoto.Add(new RectanglesPerPhoto());
            }

            path = System.IO.Path.Combine(path, "road_example_image.jpg");
            labels = new ObservableCollection<LabelsClass>();
            LabelsListView.ItemsSource = labels;
            DataContext = this;
            
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Random random = new Random();
            Color randomColor = Color.FromArgb(255, (byte)random.Next(256), (byte)random.Next(256), (byte)random.Next(256));
            labels.Add(new LabelsClass(new SolidColorBrush(randomColor), LabelInput.Text));
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (sender is MenuItem menuItem && menuItem.DataContext is LabelsClass selectedItem)
            {
                for(int i=0; i<rectPerPhoto.Count;i++)
                {
                    for(int j = rectPerPhoto[i].rectangles.Count()-1; j >= 0; j--)
                    {
                        if (rectPerPhoto[i].rectangles[j].Stroke == selectedItem.itemColor)
                        {
                            
                            Canva.Children.Remove(rectPerPhoto[i].rectangles[j]);
                            rectPerPhoto[i].rectangles.RemoveAt(j);
                        }
                    }
                }
                labels.Remove(selectedItem);
            }
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (rect != null)
            {
                Point pomPoint = e.GetPosition(Canva);
                if(pomPoint.X<point.X)
                {
                    Canvas.SetLeft(rect, pomPoint.X);
                }
                if (pomPoint.Y < point.Y)
                {
                    Canvas.SetTop(rect, pomPoint.Y);
                }
                double currHeight = Math.Abs(point.Y - pomPoint.Y);
                double currWidth = Math.Abs(point.X - pomPoint.X);
                rect.Width = currWidth;
                rect.Height = currHeight;
                
            }
        }

        private void Canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if(rect!=null)
            {
                rectPerPhoto[PicturesListView.SelectedIndex].rectangles.Add(rect);
                Canva.ReleaseMouseCapture();
                rect = null;
            }
        }

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(LabelsListView.SelectedItem==null)
            {
                MessageBox.Show("Choose label to draw rectangles", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            point = e.GetPosition(Canva);
            rect = new Rectangle()
            {
                Width = 0,
                Height = 0,
                Fill = Brushes.Transparent,
                Stroke = (LabelsListView.SelectedItem as LabelsClass).itemColor,
                StrokeThickness = 2.5
            };
            Canvas.SetTop(rect, point.Y);
            Canvas.SetLeft(rect, point.X);
            Canva.Children.Add(rect);
            Canva.CaptureMouse();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

            MenuItem menuItem = sender as MenuItem;
            TextBox textBox = ((menuItem.Parent as ContextMenu).PlacementTarget as Border).Child as TextBox;
            textBox.Focusable = true;
            textBox.IsReadOnly = false;
            textBox.Focus();
        }

        private void LabelTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox textBox = sender as TextBox;
                textBox.Focusable = false;
                textBox.IsReadOnly = true;
                Keyboard.ClearFocus();
            }
        }

        private void LabelsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int indx = PicturesListView.SelectedIndex;
            List<UIElement> copiedChildren = new List<UIElement>();
            foreach (UIElement child in Canva.Children)
            {
                copiedChildren.Add(child);
            }
            foreach (var child in copiedChildren)
            {
                if (child is Rectangle)
                {
                    Canva.Children.Remove(child as Rectangle);
                }
            }

            foreach (var item in rectPerPhoto[indx].rectangles)
            {
                Canva.Children.Add(item);
            }
            if (indx != 0)
            {
                prevButton.IsEnabled = true;
            }
            else
            {
                prevButton.IsEnabled = false;
            }
            if (indx < photoPaths.Count()-1)
            {
                nextButton.IsEnabled = true;
            }
            else
            {
                nextButton.IsEnabled = false;
            }
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            PicturesListView.SelectedItem = photoPaths[PicturesListView.SelectedIndex + 1];
        }

        private void prevButton_Click(object sender, RoutedEventArgs e)
        {
            PicturesListView.SelectedItem = photoPaths[PicturesListView.SelectedIndex - 1];

        }

        private void ChooseFolderButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFolderDialog openFolderDialog = new OpenFolderDialog();
            if (openFolderDialog.ShowDialog() == true)
            {
                string folderName = openFolderDialog.FolderName;
                ChosenFolderName.Text = folderName;
            }
        }





        private void FinishLabelingButton_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<SolidColorBrush, (int, string)> labelsCount = new Dictionary<SolidColorBrush, (int, string)>();
            foreach(var labelItem in labels)
            {
                labelsCount.Add(labelItem.itemColor, (0, labelItem.text));
            }

            foreach(var rectList in rectPerPhoto)
            {
                int indx = rectPerPhoto.IndexOf(rectList);
                string currPhotoPath = photoPaths[indx];  
                
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(currPhotoPath, UriKind.Absolute);
                bitmap.EndInit();
                foreach (var rect in rectList.rectangles)
                {
                    Int32Rect pom = ToInt32Rect(rect);
                    BitmapSource pom2 = bitmap;
                    double Xscaling = bitmap.PixelWidth/ Canva.ActualWidth ;
                    double Yscaling = bitmap.PixelHeight/ Canva.ActualHeight; 
                    pom.Width = (int)(pom.Width * Xscaling);
                    pom.X = (int)(pom.X * Xscaling);
                    pom.Height = (int)(pom.Height * Yscaling);
                    pom.Y = (int)(pom.Y * Yscaling);
                    CroppedBitmap pom1 = new CroppedBitmap(pom2, pom);
                    BitmapEncoder encoder = new JpegBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(pom1));



                    (int count, string labelText)tuplePom = labelsCount[rect.Stroke as SolidColorBrush];
                    string pomName = tuplePom.labelText;
                    if(tuplePom.labelText.Length==0)
                    {
                        pomName = count.ToString();
                        count++;
                    }
                    string newFolderPath = System.IO.Path.Combine(ChosenFolderName.Text, "Label_" + pomName);
                    if(!System.IO.Directory.Exists(newFolderPath))
                        System.IO.Directory.CreateDirectory(newFolderPath);
                    using (System.IO.FileStream stream = new System.IO.FileStream(newFolderPath + "/" + tuplePom.labelText + tuplePom.count.ToString() + ".png", System.IO.FileMode.Create))
                    {
                        encoder.Save(stream);
                    }
                    labelsCount[rect.Stroke as SolidColorBrush] = (++tuplePom.count, tuplePom.labelText);
                }
            }
        }

        public static Int32Rect ToInt32Rect(Rectangle rect)
        {
            double height = rect.Height + 50;
            double width = rect.Width;
            double x = Canvas.GetLeft(rect);
            double y = Canvas.GetTop(rect);

            return new Int32Rect(
                (int)Math.Floor(x),
                (int)Math.Floor(y),
                (int)Math.Ceiling(width),
                (int)Math.Ceiling(height)
            );
        }


    }


    public class LabelsClass
    {
        public SolidColorBrush itemColor { get; set; }
        public string text { get; set; }

        public LabelsClass(SolidColorBrush _itemColor, string _text)
        {
            itemColor = _itemColor;
            text = _text;
        }
    }

    public class RectanglesPerPhoto
    {
        public ObservableCollection<Rectangle> rectangles { get; set; }

        public RectanglesPerPhoto()
        {
            rectangles = new ObservableCollection<Rectangle>();
        }
    }

}