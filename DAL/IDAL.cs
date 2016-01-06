using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
namespace DAL
{
    public interface IDAL
    {
        #region dish functions
        //DISH
        void addDish(Dish x);
        void deleteDish(Dish x);
        void updateDish(Dish x);
        Dish getDish(int dishID);
        #endregion

        #region order function
        //ORDER
        void addOrder(Order x);
        void deleteOrder(Order x);
        void updateOrder(Order x);
        Order getOrder(int orderID);
        #endregion

        #region ordered-dish function
        //Ordered-Dish
        void addOrdDish(Ordered_Dish x);
        void updateOrdDish(Ordered_Dish x);
        void deleteOrdDish(Ordered_Dish x);
        Ordered_Dish getOrdDish(int OrdDishID, int OrdDishNum);
        #endregion

        #region branch function
        //BRANCH
        void addBranch(Branch x);
        void deleteBranch(Branch x);
        void updateBranch(Branch x);
        Branch getBranch(int branchID);
        #endregion

        #region sum functions
        IEnumerable<Order> sumOrder();
        IEnumerable<Dish> sumDish();
        IEnumerable<Branch> sumBranch();
        #endregion
    }
}
