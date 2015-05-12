using RestoBook.Common.Model;
using RestoBook.Common.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoBook.Common.Business.Managers
{
    public class CustomerManager
    {
        #region PROPERTIES
        private DataProvider dp;
        #endregion PROPERTIES


        #region CONSTRUCTOR
        public CustomerManager()
        {
            this.dp = new DataProvider();
            this.dp.PrepareCustomerDP();

        }
        #endregion CONSTRUCTOR


        #region PUBLIC METHODS
        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Customer GetCustomerByMail(string email)
        {
            this.RefreshDataSet();
            RestoBook.Common.Model.DataSetRestoBook.CUSTOMERRow customerRow = this.dp.ds.CUSTOMER.Where(c => c.MAIL.ToLower() == email.ToLower()).FirstOrDefault();

            Customer returnedCustomer = null;

            if (customerRow != null)
            {
                returnedCustomer = new Customer()
                {
                    Id = customerRow.CUSTOMERID,
                    IsEnable = customerRow.ENABLE,
                    Mail = customerRow.MAIL,
                    Phone = customerRow.PHONE
                };
            }
            return returnedCustomer;
        }

        /// <summary>
        /// Creates a new Customer.
        /// </summary>
        /// <returns>True in case of successful update, false in case of failure.</returns>
        public bool CreateCustomer(Customer customer)
        {
            int nbrRowsCreated = -1;
            using (RestoBook.Common.Model.DataSetRestoBookTableAdapters.CUSTOMERTableAdapter daCustomer = new Model.DataSetRestoBookTableAdapters.CUSTOMERTableAdapter())
            {
                nbrRowsCreated = daCustomer.Insert(customer.Mail, customer.Phone, true);
            }
            return nbrRowsCreated > 0;
        }

        #endregion PUBLIC METHODS


        #region PRIVATE METHODS
        /// <summary>
        /// Refreshes the dataset, so that the new data from database becomes available.
        /// </summary>
        private void RefreshDataSet()
        {
            // refresh the dataset
            this.dp.ds.Reset();
            this.dp.PrepareCustomerDP();
        }
        #endregion PRIVATE METHODS


    }
}
