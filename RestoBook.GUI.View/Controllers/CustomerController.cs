using RestoBook.Common.Business.Managers;
using RestoBook.Common.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoBook.GUI.View.Controllers
{
    public class CustomerController : ICustomerController
    {
        #region PROPERTIES
        private CustomerManager customerManager;
        #endregion PROPERTIES

        #region CONSTRUCTOR
        public CustomerController()
        {
            this.customerManager = new CustomerManager();
        }
        #endregion CONSTRUCTOR

        #region METHODS
        /// <summary>
        /// Gets a list of all customers.
        /// </summary>
        /// <returns></returns>
        public List<Customer> GetAllCustomer()
        {
            return this.customerManager.GetAllCustomers();
        }
        #endregion METHODS
    }
}
