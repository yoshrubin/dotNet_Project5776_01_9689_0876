using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BL
{
    public interface IBL
    {
<<<<<<< HEAD
        #region similar to IDAL
=======
        #region Core Functions (Similar to IDAL)
>>>>>>> origin/master

        #region dish functions
        //DISH
        void addDish(Dish x);
<<<<<<< HEAD
        void deleteDish(int x);
=======
        void deleteDish(Dish x);
>>>>>>> origin/master
        void updateDish(Dish x);
        Dish getDish(int dishID);
        #endregion

        #region order function
        //ORDER
        void addOrder(Order x);
<<<<<<< HEAD
        void deleteOrder(int x);
=======
        void deleteOrder(Dish x);
>>>>>>> origin/master
        void updateOrder(Order x);
        Order getOrder(int orderID);
        #endregion

        #region ordered-dish function
        //Ordered-Dish
        void addOrdDish(Ordered_Dish x);
        void updateOrdDish(Ordered_Dish x);
<<<<<<< HEAD
        void deleteOrdDish(int x, int y);
=======
        void deleteOrdDish(Ordered_Dish x);
>>>>>>> origin/master
        Ordered_Dish getOrdDish(int OrdDishID, int OrdDishNum);
        #endregion

        #region branch function
        //BRANCH
        void addBranch(Branch x);
<<<<<<< HEAD
        void deleteBranch(int x);
=======
        void deleteBranch(Branch x);
>>>>>>> origin/master
        void updateBranch(Branch x);
        Branch getBranch(int branchID);
        #endregion

        #region sum functions
<<<<<<< HEAD
        List<Order> sumOrder();
=======
        IEnumerable<Order> sumOrder();
>>>>>>> origin/master
        List<Dish> sumDish();
        List<Branch> sumBranch();
        #endregion


        #endregion

<<<<<<< HEAD
        //EXTRA
        double SumMoneyDishes();
=======
        double SumMoneyDishesBranch(Branch x);
>>>>>>> origin/master
        Dish mostOrderedDish();
        bool tooLittleMoniesDelivery(double x);
        List<Dish> holierThanThou();
        bool tooMuchMonies(double x);
        bool tooLittleHoly(orderHechser x, dishHechser y);
<<<<<<< HEAD
        List<Order> chooseOrder(Func<Order, bool> predicate = null);
        double moniesTime();
        double moniesPlace();
        bool tooYoung(Order x); // Need to get age.
=======
        bool tooLittleHoly(Order x);
        List<Order> chooseOrder(Func<Order, bool> predicate = null);
        double moniesTime();
        double moniesPlace();
        bool tooYoung(int x); // Need to get age.
>>>>>>> origin/master
        List<Dish> americanMenu();
        string managerOfTheMonth();
        Branch branchSuccessMonth();
        List<Branch> rankBranchPerMonth();
    }
}
