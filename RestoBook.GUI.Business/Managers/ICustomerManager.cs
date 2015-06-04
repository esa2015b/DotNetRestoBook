using RestoBook.Common.Model.Models;
using System.Collections.Generic;

namespace RestoBook.Common.Business.Managers
{
    interface ICustomerManager
    {
        bool CreateCustomer(Customer customer);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Customer GetCustomerByMail(string email);
        
        /// <summary>
        /// Gets a List containing all customers
        /// </summary>
        /// <returns></returns>
        List<Customer> GetAllCustomers();

        /// <summary>
        /// Gets a dictionary of all customers
        /// </summary>
        Dictionary<int, string> GetAllCustomerDictionary();

    }
}
