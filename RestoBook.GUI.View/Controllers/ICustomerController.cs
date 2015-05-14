using RestoBook.Common.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoBook.GUI.View.Controllers
{
    public interface ICustomerController
    {
        /// <summary>
        /// Gets a list of all customers.
        /// </summary>
        /// <returns></returns>
        List<Customer> GetAllCustomer();

    }
}
