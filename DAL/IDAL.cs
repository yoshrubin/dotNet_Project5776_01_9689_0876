﻿using System;
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
        void deleteOrder(Order x);
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
        List<Dish> sumDish();
        List<Branch> sumBranch();
=======
        IEnumerable<Order> sumOrder();
        IEnumerable<Dish> sumDish();
        IEnumerable<Branch> sumBranch();
>>>>>>> origin/master
        #endregion
    }
}
