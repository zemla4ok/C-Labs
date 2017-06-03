using Microsoft.Win32;
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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Lab9
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Field.AddHandler(RichTextBox.DragOverEvent, new DragEventHandler(RichTextBox_DragOver), true);
            Field.AddHandler(RichTextBox.DropEvent, new DragEventHandler(RichTextBox_Drop), true);

            PFontFamily.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            PFontSize.ItemsSource = new List<double>() { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };

            List<string> styles = new List<string> { "blue", "pink" };
            Theme.SelectionChanged += ThemeChange;
            Theme.ItemsSource = styles;
            Theme.SelectedItem = "blue";

            Slider.ValueChanged += OnValueChange;
        }

        #region opening/saving/new
        private void OpenFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*";
            if (dlg.ShowDialog() == true)
            {
                FileStream fileStream = new FileStream(dlg.FileName, FileMode.Open);
                TextRange range = new TextRange(Field.Document.ContentStart, Field.Document.ContentEnd);
                range.Load(fileStream, DataFormats.Rtf);
            }
            this.Title = dlg.FileName;
        }

        private void SaveFile(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*";
            if (dlg.ShowDialog() == true)
            {
                FileStream fileStream = new FileStream(dlg.FileName, FileMode.Create);
                TextRange range = new TextRange(Field.Document.ContentStart, Field.Document.ContentEnd);
                range.Save(fileStream, DataFormats.Rtf);
            }
        }

        private void Open(object sender, RoutedEventArgs e)
        {
            this.OpenFile(sender, e);
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            this.SaveFile(sender, e);
        }

        private void NewWind(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
        }
        #endregion
        #region drag'n'drop
        private void RichTextBox_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effects = DragDropEffects.All;
            }
            else
            {
                e.Effects = DragDropEffects.None;
            }
            e.Handled = false;
        }
        private void RichTextBox_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] docPath = (string[])e.Data.GetData(DataFormats.FileDrop);

                var dataFormat = DataFormats.Rtf;

                if (e.KeyStates == DragDropKeyStates.ShiftKey)
                {
                    dataFormat = DataFormats.Text;
                }

                System.Windows.Documents.TextRange range;
                System.IO.FileStream fStream;
                if (System.IO.File.Exists(docPath[0]))
                {
                    try
                    {
                        this.Title = docPath[0];
                        range = new System.Windows.Documents.TextRange(Field.Document.ContentStart, Field.Document.ContentEnd);
                        fStream = new System.IO.FileStream(docPath[0], System.IO.FileMode.OpenOrCreate);
                        range.Load(fStream, dataFormat);
                        fStream.Close();
                    }
                    catch (System.Exception)
                    {
                        MessageBox.Show("File could not be opened. Make sure the file is a text file.");
                    }
                }
            }
        }
        #endregion
        #region languages
        private void SetRussian(object sender, RoutedEventArgs e)
        {
            this.Resources = new ResourceDictionary()
            {
                Source = new
                    Uri("pack://application:,,,/res/langRU.xaml")
            };
        }

        private void SetEnglish(object sender, RoutedEventArgs e)
        {
            this.Resources = new ResourceDictionary()
            {
                Source = new
                    Uri("pack://application:,,,/res/lang.xaml")
            };
        }
        #endregion
        #region FontChanges
        private void FontUpdating(object sender, RoutedEventArgs e)
        {
            object temp = Field.Selection.GetPropertyValue(Inline.FontWeightProperty);
            Bold.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontWeights.Bold));
            temp = Field.Selection.GetPropertyValue(Inline.FontStyleProperty);
            Italic.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontStyles.Italic));
            temp = Field.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            UnderLine.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(TextDecorations.Underline));

            temp = Field.Selection.GetPropertyValue(Inline.FontFamilyProperty);
            PFontFamily.SelectedItem = temp;
            temp = Field.Selection.GetPropertyValue(Inline.FontSizeProperty);
            PFontSize.Text = temp.ToString();
        }
        private void OnChangeFontFamily(object sender, SelectionChangedEventArgs e)
        {
            if (PFontFamily.SelectedItem != null)
                Field.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, PFontFamily.SelectedItem);
        }
        private void OnChangeFontSize(object sender, TextChangedEventArgs e)
        {
            Field.Selection.ApplyPropertyValue(Inline.FontSizeProperty, PFontSize.Text);
        }
        #endregion

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            Log.Text = GetLength(Field);
        }

        private string GetLength(RichTextBox rtb)
        {
            var textRange = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
            return (textRange.Text.Length - 2).ToString();
        }


        //lab10----------------------
        private void ThemeChange(object sender, SelectionChangedEventArgs e)
        {
            string style = Theme.SelectedItem as string;
            var uri = new Uri("res/" + style + ".xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }

        private void OnValueChange(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Field.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
            Field.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            Field.LayoutTransform = new ScaleTransform((Slider.Value / 100), (Slider.Value / 100), 0, 0);
        }


    }
}

///вторник 100-3а лк
///1 число в 11.40 152-4 и 13.50 там же