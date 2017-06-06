using System;
using System.Collections.Generic;
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

namespace Lab12_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SQLCustomerRepository customerRepository;
        CQLOrderRepository orderRepository;
        public MainWindow()
        {
            InitializeComponent();
            customerRepository = new SQLCustomerRepository();
            orderRepository = new CQLOrderRepository();
        }

        private void AddToDB(object sender, RoutedEventArgs e)
        {
            Customer customer = new Customer();
            customer.Age = Convert.ToInt32(age.Text);
            customer.Name = name.Text;
            customer.Email = email.Text;

            customerRepository.Create(customer);
            customerRepository.Save();
        }

        private void UpdateCustomer(object sender, RoutedEventArgs e)
        {
            Customer customer = new Customer();
            customer.Age = Convert.ToInt32(age.Text);
            customer.Name = name.Text;
            customer.Email = email.Text;
            customer.CustomerId = Convert.ToInt32(custID.Text);

            customerRepository.Update(customer);
            customerRepository.Save();
        }

        private void DeleteCustomer(object sender, RoutedEventArgs e)
        {
            customerRepository.Delete(Convert.ToInt32(custID.Text));
            customerRepository.Save();
        }

        private void GetAllCustomers(object sender, RoutedEventArgs e)
        {
            customers.Items.Clear();
            List<Customer> list = customerRepository.GetList().ToList();
            foreach (Customer c in list)
                customers.Items.Add(c.ToString());
        }

        private void GetCustomerByID(object sender, RoutedEventArgs e)
        {
            custByID.Text= customerRepository.GetItem(Convert.ToInt32(custID.Text)).ToString();
        }

        private void AddOrder(object sender, RoutedEventArgs e)
        {
            Order order = new Order();
            order.ProductName = prName.Text;
            order.Description = descr.Text;
            order.Quantity = Convert.ToInt32(qua.Text);
            order.PurchaseDate = DateTime.Now;
            order.Customer = Convert.ToInt32(cID.Text);

            orderRepository.Create(order);
            orderRepository.Save();
        }

        private void UpdOrder(object sender, RoutedEventArgs e)
        {
            Order order = new Order();
            order.ProductName = prName.Text;
            order.Description = descr.Text;
            order.Quantity = Convert.ToInt32(qua.Text);
            order.PurchaseDate = DateTime.Now;
            order.Customer = Convert.ToInt32(cID.Text);
            order.OrderId = Convert.ToInt32(oID.Text);

            orderRepository.Update(order);
            orderRepository.Save();
        }

        private void DeleteOrder(object sender, RoutedEventArgs e)
        {
            orderRepository.Delete(Convert.ToInt32(oID.Text));
            orderRepository.Save();
        }

        private void GetAllOrders(object sender, RoutedEventArgs e)
        {
            orders.Items.Clear();
            List<Order> list = orderRepository.GetList().ToList();
            foreach (Order o in list)
                orders.Items.Add(o.ToString());
        }

        private void GetOrderById(object sender, RoutedEventArgs e)
        {
            ordById.Text = orderRepository.GetItem(Convert.ToInt32(oID.Text)).ToString();
        }
 
        
    
    }
}
