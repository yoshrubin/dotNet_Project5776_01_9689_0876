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
using System.Windows.Shapes;
using BE;

namespace PLForm
{
    /// <summary>
    /// Interaction logic for orderWindow.xaml
    /// </summary>
    public partial class orderWindow : Window
    {
        BL.IBL bl;
        public orderWindow()
        {
            InitializeComponent();
            bl = BL.FactoryBL.getIBL();
            BranchBoxItems();
            comboBoxHechser.ItemsSource = Enum.GetValues(typeof(orderHechser));
        }
        //Selects the branchName of all Branches
        void BranchBoxItems(string ToAdd = null)
        {
            if (ToAdd == null)
            {
                ComboBoxItem temp;
                foreach (Branch item in bl.sumBranch())
                {
                    temp = new ComboBoxItem();
                    temp.Content = item.branchName;
                    temp.Tag = item.branchID;
                    comboBoxBranch.Items.Add(temp);
                }
            }
            else
            {
                comboBoxBranch.Items.Add(ToAdd);
            }
        }

        //Add an Order
        private void buttonAddOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id;
                if (textBoxID.Text != "")
                    id = int.Parse(textBoxID.Text);
                else
                    id = 0;

                DateTime currentTime;
                currentTime = DateTime.Now;

                int branchId;
                if ((int)comboBoxBranch.SelectedItem > 0)
                    branchId = (int)comboBoxBranch.SelectedItem;
                else
                    throw new Exception("Lacking Branch Id");

                int staff;
                if (textBoxStaff.Text == "")
                    throw new Exception("Lacking number of Staff.");
                if (int.Parse(textBoxStaff.Text) < 0)
                    throw new Exception("Number of staff is inaccurate.");
                staff = int.Parse(textBoxStaff.Text);

                string customer;
                if (textBoxCustomer.Text == "")
                    throw new Exception("Lacking the name of the Customer.");
                customer = textBoxCustomer.Text;

                string address;
                if (textBoxCustAddress.Text == "")
                    throw new Exception("Lacking address of the Customer.");
                address = textBoxCustAddress.Text;

                string location;
                if (textBoxCustLocation.Text == "")
                    throw new Exception("Lacking the location for the Order.");
                location = textBoxCustLocation.Text;

                int cc;
                if (passwordBoxCC.Password == "")
                    throw new Exception("Lacking the creditcard info.");
                if (passwordBoxCC.Password.Length != 12)
                    throw new Exception("Inaccurate cc info.");
                cc = int.Parse(passwordBoxCC.Password);

                int age;
                if (textBoxAge.Text == "")
                    throw new Exception("Lacking Customer's age.");
                age = int.Parse(textBoxAge.Text);

                orderHechser hechser = (orderHechser)comboBoxHechser.SelectedItem;
                if ((int)hechser < 0)
                    throw new Exception("Lacking Hechser.");

                Order ordertemp = new Order(id, currentTime, branchId, hechser, staff, customer, address, location, cc, age);
                if (bl.tooLittleHoly(ordertemp)) // checks if the hechser is good enough.
                    throw new Exception("Order isn't a high enough hechser for the branch.");
                else
                {
                    bl.addOrder(ordertemp);
                    MessageBox.Show("You have added an Order with the ID: " + ordertemp.orderID + ".");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Update an Order
        private void buttonUpdateOrder_Click(object sender, RoutedEventArgs e)
        {
            Order temporder = new Order();
            temporder = bl.getOrder(int.Parse(textBoxID.Text));

            try
            {
                if (temporder == null)// id not found
                    throw new Exception("Order with given id not found.");
                else
                {
                    if ((int)comboBoxBranch.SelectedItem >= 0)
                        temporder.orderBranch = (int)comboBoxBranch.SelectedItem;

                    temporder.orderTime = DateTime.Now;

                    if (textBoxStaff.Text != "")
                    {
                        if (int.Parse(textBoxStaff.Text) < 0)
                            throw new Exception("Number of staff is inaccurate.");
                        else
                            temporder.orderStaff = int.Parse(textBoxStaff.Text);
                    }

                    if (textBoxCustomer.Text != "")
                        temporder.orderCustomer = textBoxCustomer.Text;

                    if (textBoxCustAddress.Text != "")
                        temporder.orderCustAddress = textBoxCustAddress.Text;

                    if (textBoxCustLocation.Text != "")
                        temporder.orderCustLocation = textBoxCustLocation.Text;

                    if (textBoxAge.Text != "")
                    {
                        if (bl.tooYoung(int.Parse(textBoxAge.Text)))
                            throw new Exception("Customer is too young to order.");
                        else
                            temporder.orderAge = int.Parse(textBoxAge.Text);
                    }

                    if (passwordBoxCC.Password != "")
                    {
                        if (passwordBoxCC.Password.Length != 12)
                            throw new Exception("Credit Card information incorrect.");
                        else
                            temporder.orderCustCC = int.Parse(passwordBoxCC.Password);
                    }

                    if ((int)comboBoxHechser.SelectedItem >= 0)
                        temporder.orderHechserOrder = (orderHechser)comboBoxHechser.SelectedItem;

                    bl.updateOrder(temporder);
                    MessageBox.Show("Order: " + temporder.orderID.ToString() + " has been updated.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Delete an Order
        private void buttonDeleteOrder_Click(object sender, RoutedEventArgs e)
        {
            BE.Order tempOrder = bl.getOrder(int.Parse(textBoxID.Text));
            try
            {
                if (tempOrder == null)
                    throw new Exception("Order not found.");
                bl.deleteOrder(tempOrder.orderID);
                throw new Exception("Order with id: " + tempOrder.orderID + " has been deleted.");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
