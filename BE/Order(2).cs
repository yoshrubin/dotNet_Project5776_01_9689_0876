using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{

    public enum orderHechser { rabbanut, mehadrin, lubavitch }; // Check if it has to be in Class?
    public class Order
    {
        //ctor
        public Order()
        {
            orderID = 0;
        }
        public Order(int orderID, DateTime orderTime, int orderBranch, orderHechser orderHechserOrder, int orderStaff, string orderCustomer, string orderCustAddress, string orderCustLocation, int orderCustCC, int orderAge)
        {
            this.orderID = orderID;
            this.orderTime = orderTime;
            this.orderBranch = orderBranch;
            this.orderHechserOrder = orderHechserOrder;
            this.orderStaff = orderStaff;
            this.orderCustAddress = orderCustAddress;
            this.orderCustLocation = orderCustLocation;
            this.orderCustCC = orderCustCC;
            this.orderAge = orderAge;
        }
        //properties
        public int orderID { get; set; }
        // The exception will be checked when try to add it to the orderList.
        public int orderBranch { get;  set; } // The branch that the Order is being placed in.
        public DateTime orderTime { get;  set; }
        public orderHechser orderHechserOrder { get;  set; }
        public int orderStaff { get;  set; }
        public string orderCustomer { get;  set; }
        public string orderCustAddress { get;  set; } //Where he is from
        public string orderCustLocation { get; set; } // Where he wants to be sent to
        public int orderCustCC { get; set; }
        public int orderAge { get; set; }
        //func
        public override string ToString()
        {
            string temp = null;
            temp += orderID.ToString() + " order time: " + orderTime.ToString() + " order branch: " + orderBranch.ToString() + " order customer: " + orderCustomer + " order customer's current location: " + orderCustLocation;
            return temp;
        }
        public void randOrderNum()
        {
            Random r = new Random();
            orderID = r.Next(1, 10000);
        }
    }
}
