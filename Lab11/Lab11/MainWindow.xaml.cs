using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace Lab11
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection cn;
        public MainWindow()
        {
            InitializeComponent();
            cn = new SqlConnection(path);
            cn.Open();
        }

        private bool flag = false;
        const string path = @"Data Source=DESKTOP-M13O155;Initial Catalog=books;Integrated Security=True";
        private byte[] buffer = null;
        private void Open(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "All files (*.*)|*.*";
            if (dlg.ShowDialog() == true)
            {
                flag = true;
                cond.Content = "OK";
                FileStream fileStream = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read);
                buffer = new byte[fileStream.Length];
                fileStream.Read(buffer, 0, (int)fileStream.Length);
                fileStream.Close();
            }
        }
        private void AddBook(object sender, RoutedEventArgs e)
        {
            if (bookName.Text == "" || AuthId.Text == "" || Pages.Text == "")
                MessageBox.Show("Введены не все даные для добавления элемента");
            else
            {
                try
                {
                    string insert = string.Format("INSERT INTO Books" + "(Id, Name, Pages, AuthorId) VALUES(@Id, @Name, @Pages, @AuthorId)");
                    SqlCommand cmd = new SqlCommand(insert, cn);

                    cmd.Parameters.AddWithValue("@Id", BookID.Text);
                    cmd.Parameters.AddWithValue("@Name", bookName.Text);
                    cmd.Parameters.AddWithValue("@Pages", Convert.ToInt32(Pages.Text));
                    cmd.Parameters.AddWithValue("@AuthorId", AuthId.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Добавлена новая книга");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
        private void AddAuth(object sender, RoutedEventArgs e)
        {
            if (authName.Text == "" || flag == false)
                MessageBox.Show("Введены не все даные для добавления элемента");
            else
            {
                try
                {
                    string insert = string.Format("INSERT INTO Authors" + "(Id, Name, Photo) VALUES(@Id, @Name, @Photo)");
                    SqlCommand cmd = new SqlCommand(insert, cn);
                    cmd.Parameters.AddWithValue("@Id", AuthId.Text);
                    cmd.Parameters.AddWithValue("@Name", authName.Text);
                    cmd.Parameters.AddWithValue("Photo", buffer);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Добавлен новый автор");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
       
        private void Refresh(object sender, RoutedEventArgs e)
        {
            table.Items.Clear();
            string select = "SELECT Books.Name, Authors.Name, Books.Pages, Authors.Photo, Authors.Id, Books.Id FROM Books INNER JOIN Authors on Books.AuthorId = Authors.Id";
            SqlCommand cmd = new SqlCommand(select, cn);
            SqlDataReader data = cmd.ExecuteReader();
            while (data.Read())
            {
                var a = data[3];
                MemoryStream ms = new MemoryStream((Byte[])a);
                var img = new BitmapImage();
                img.BeginInit();
                img.StreamSource = ms;
                img.EndInit();

                BookInfo bi = new BookInfo(
                    data[0].ToString(),
                    data[1].ToString(),
                    Convert.ToInt32(data[2].ToString()),
                    img,
                    Convert.ToInt32(data[4].ToString()),
                    Convert.ToInt32(data[5].ToString()));
                table.Items.Add(bi);
            }
        }

        private void DelAuth(object sender, RoutedEventArgs e)
        {
            string delete = string.Format("Delete Authors WHERE Id = '{0}'", AuthId.Text);
            SqlCommand cmd = new SqlCommand(delete, cn);
            cmd.ExecuteNonQuery();
        }
        private void DelBook(object sender, RoutedEventArgs e)
        {
            string delete = string.Format("Delete Books WHERE Id = '{0}'", BookID.Text);
            SqlCommand cmd = new SqlCommand(delete, cn);
            cmd.ExecuteNonQuery();
        }

        private void UpdBook(object sender, RoutedEventArgs e)
        {
            if (AuthId.Text == "" || BookID.Text == "" || Pages.Text == ""
                || bookName.Text == "")
                MessageBox.Show("Не вся инфа");
            else
            {
                string upd = string.Format("UPDATE Books SET Name = '{0}', Pages = '{1}', AuthorId = '{2}' WHERE Id = '{3}'", bookName.Text, Pages.Text, AuthId.Text, BookID.Text);
                SqlCommand cmd = new SqlCommand(upd, cn);
                cmd.ExecuteNonQuery();
            }
        }
        private void UpdAuth(object sender, RoutedEventArgs e)
        {
            if (AuthId.Text == "" || authName.Text == "" ||
                flag == false)
                MessageBox.Show("Не вся инфа");
            else
            {
                string upd = string.Format("UPDATE Authors SET Name = '{0}' WHERE Id = '{1}'", authName.Text, AuthId.Text);
                SqlCommand cmd = new SqlCommand(upd, cn);
                cmd.ExecuteNonQuery();
            }
        }
    }
}