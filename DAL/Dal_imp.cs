using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;

namespace DAL
{
    class Dal_imp : IDAL
    {
        #region // Add Functions
        // Checks if the branch exists by the branchID, if it doesn't, it is add it to the branchlist.
        public void addBranch(Branch y)
        {
            if (DataSource.branchList.FirstOrDefault(x => x.branchID == y.branchID) == null)
                DataSource.branchList.Add(y);
            else
                throw new Exception("DAL Error: Branch ID already exists.");
        }

        // Checks if the dish exists by the dishID, if it doesn't, it is added to the dishlist.
        public void addDish(Dish y)
        {
            if (DataSource.dishList.FirstOrDefault(x => x.dishID == y.dishID) == null)
                DataSource.dishList.Add(y);
            else
                throw new Exception("DAL Error: Dish ID already exists.");
        }

        // Checks if the order exists by the OrderID, if it doesn't, it is added to the orderlist.
        public void addOrder(Order y)
        {
            if (DataSource.orderList.FirstOrDefault(x => x.orderID == y.orderID) == null)
                DataSource.orderList.Add(y);
            else
                throw new Exception("DAL Error: Order ID already exists.");
        }

        // Checks it the ordDish exists by the ordDishID, if it doesn't, it is added to the ordDishList. 
        public void addOrdDish(Ordered_Dish y)
        {
            // the item needs to come from the same order and the same dish.
            if (DataSource.ordDishList.FirstOrDefault(x => (x.ordDishID == y.ordDishID) && (x.ordDishNum == y.ordDishNum)) == null)
                DataSource.ordDishList.Add(y);
            else
                throw new Exception("DAL Error: Ordered dish already exixsts.");
        }
        #endregion

        #region // Delete Functions
        //Searches by id, and if found - deletes.
        public void deleteBranch(Branch y)
        {
            if (DataSource.branchList.FirstOrDefault(x => x.branchID == y.branchID) == null)
                throw new Exception("DAL Error: Branch ID not found.");
            else
                DataSource.branchList.Remove(y);      
        }

        public void deleteDish(Dish y)
        {
            if (DataSource.dishList.FirstOrDefault(x => x.dishID == y.dishID) == null)
                throw new Exception("DAL Error: Dish ID not found.");
            else
                DataSource.dishList.Remove(y);
        }

        //Searches by the id and name. (Order and Dish).
        public void deleteOrdDish(Ordered_Dish y)
        {
            if (DataSource.ordDishList.FirstOrDefault(x => (x.ordDishID == y.ordDishID) && (x.ordDishNum == y.ordDishNum)) == null)
                throw new Exception("DAL Error: Specific Ordered Dish not found.");
            else
                DataSource.ordDishList.Remove(y);
        }

        public void deleteOrder(Order y)
        {
            if (DataSource.orderList.FirstOrDefault(x => x.orderID == y.orderID) == null)
                throw new Exception("DAL Error: Order ID not found.");
            else
                DataSource.orderList.Remove(y);
        }
        #endregion

        #region // Update Functions
        // Searches for item by ID, if found - updates.
        public void updateBranch(Branch y)
        {
            Branch tempBranch = DataSource.branchList.FirstOrDefault(x => x.branchID == y.branchID);
            if (tempBranch != null)
            {
                DataSource.branchList.Remove(tempBranch);
                DataSource.branchList.Add(y);
            }
            else
                throw new Exception("DAL Error: Branch ID not found.");
        }

        public void updateDish(Dish y)
        {
            Dish tempDish = DataSource.dishList.FirstOrDefault(x => x.dishID == y.dishID);
            if (tempDish != null)
            {
                DataSource.dishList.Remove(tempDish);
                DataSource.dishList.Add(y);
            }
            else
                throw new Exception("DAL Error: Dish ID not found.");
        }

        public void updateOrdDish(Ordered_Dish y)
        {
            // the item needs to come from the same order and the same dish.
            if (DataSource.ordDishList.FirstOrDefault(x => (x.ordDishID == y.ordDishID) && (x.ordDishNum == y.ordDishNum)) == null)
                throw new Exception("DAL Error: Ordered Dish not found.");
            else
            {
                //If the ordDish exists, but I just was to increase it's order
                Ordered_Dish orderdishtemp = DataSource.ordDishList.FirstOrDefault(x => (x.ordDishID == y.ordDishID) && (x.ordDishNum == y.ordDishNum));
                DataSource.ordDishList.Remove(orderdishtemp); // remove from the ordDishList
                orderdishtemp.ordDishAmount += y.ordDishAmount; // added the amount of new ordDish
                DataSource.ordDishList.Add(orderdishtemp); // put back into the ordDishList
            }
        }

        public void updateOrder(Order y)
        {
            Order tempOrder = DataSource.orderList.FirstOrDefault(x => x.orderID == y.orderID);
            if (tempOrder != null)
            {
                DataSource.orderList.Remove(tempOrder);
                DataSource.orderList.Add(y);
            }
            else
                throw new Exception("DAL Error: Order ID not found.");
        }
        #endregion
 
        #region //Sum functions
        //Returns the entire list.
        public IEnumerable<Branch> sumBranch()
        {
            return DataSource.branchList;
        }

        public IEnumerable<Dish> sumDish()
        {
            return DataSource.dishList;
        }

        public IEnumerable<Order> sumOrder()
        {
            return DataSource.orderList;
        }
        #endregion

        #region // Get functions
        //Search engines to find the item in it's respective list.
        public Dish getDish(int dishID)
        {
            return DataSource.dishList.FirstOrDefault(x => x.dishID == dishID);
        }

        public Order getOrder(int orderID)
        {
            return DataSource.orderList.FirstOrDefault(x => x.orderID == orderID);
        }

        public Ordered_Dish getOrdDish(int OrdDishID, int OrdDishNum)
        {
            return DataSource.ordDishList.FirstOrDefault(x => (x.ordDishID == OrdDishID ) && (x.ordDishNum == OrdDishNum ));
        }

        public Branch getBranch(int branchID)
        {
            return DataSource.branchList.FirstOrDefault(x => x.branchID == branchID);
        }
        #endregion
    }
}
