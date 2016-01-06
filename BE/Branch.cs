using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public enum branchHechser { rabbanut, mehadrin, lubavitch };
    public class Branch
    {
        //ctor
<<<<<<< HEAD
=======
        public Branch()
        {
            accessGranted = true;
            branchManagerPassword = "saveTheQueen770";
        }
>>>>>>> origin/master
        public Branch(string branchName, string branchAddress, long branchPhoneNum, string branchManager, int branchEmployee, int branchDeliveryFree, branchHechser branchHechserBranch, int branchID = 0)
        {
            this.branchID = branchID;
            this.branchName = branchName;
            this.branchAddress = branchAddress;
            this.branchPhoneNum = branchPhoneNum;
            this.branchManager = branchManager;
            this.branchEmployee = branchEmployee;
            this.branchDeliveryFree = branchDeliveryFree;
            this.branchHechserBranch = branchHechserBranch;
<<<<<<< HEAD
        }
        //properties
        public int branchID
        {
            get
            {
                return branchID;
            }
            private set
            {
                if (value > 999 && value <= 0) //limit of the number of branches  
                    throw new Exception("branchID isn't within range of usable numbers.");
                else
                    branchID = value;
            }
        }
        public string branchName { get; private set; }
        public string branchAddress { get; private set; }
        public long branchPhoneNum { get; private set; }
        public string branchManager { get; private set; }
        public int branchEmployee { get; private set; }
        public int branchDeliveryFree { get; private set; }
        public branchHechser branchHechserBranch { get; private set; }
        public List<Dish> listDishforBranch { get; private set; }
        public List<Order> listOrderforBranch { get; private set; }
        //functions
=======
            accessGranted = true;
            branchManagerPassword = "saveTheQueen770";
        }
        //Properties.
        public int branchID { get; set; }
        public string branchName { get; set; }
        public string branchAddress { get; set; }
        public long branchPhoneNum { get; set; }
        public string branchManager { get; set; }
        public int branchEmployee { get; set; }
        public int branchDeliveryFree { get; set; }
        public branchHechser branchHechserBranch { get; set; }
        static private string branchManagerPassword;
        static private bool accessGranted;
        //Functions.
>>>>>>> origin/master
        public override string ToString()
        {
            string temp = null;
            temp += branchID.ToString() + " Name:" + branchName + " Address:" + branchAddress + " branch manager:" + branchManager + " branch Phone Number:" + branchPhoneNum.ToString();
            if (branchDeliveryisFree())
                temp += " the amount of delivery boys available are: " + branchDeliveryFree.ToString();
            else
                temp += " There are no delivery boys available at this time.";
            return temp;
        }
        private bool branchDeliveryisFree()
        {
            if (branchDeliveryFree != 0)
                return true;
            else
                return false;
        }
        public void randBranchNum()
        {
            Random r = new Random();
            branchID = r.Next(1, 999);
        }
<<<<<<< HEAD
=======
        //Functions for the password.
        public bool passwordCorrect(string passwordAttempt)
        {
            if (passwordAttempt.CompareTo(branchManagerPassword) == 0)
                return true;
            else
                return false;
        }
        public bool insertNewPassword(string oldPassword, string newPassword)
        {
            if (passwordCorrect(oldPassword))
            {
                branchManagerPassword = newPassword;
                return true;
            }
            else
                return false;

        }
        public void grantAccess()
        {
            accessGranted = true;
        }
        public void denyAccess()
        {
            accessGranted = false;
        }
        public bool getAccess()
        {
            return accessGranted;
        }

>>>>>>> origin/master
    }
}
