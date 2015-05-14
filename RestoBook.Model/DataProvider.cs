using RestoBook.Common.Model;
using RestoBook.Common.Model.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace RestoBook.Common.Model
{
    /// <summary>
    /// The dataprovider class, helps returning
    /// the data from the datasetrestobook.
    /// </summary>
    public class DataProvider
    {
        #region PROPERTIES
        public DataSetRestoBook ds;
        #endregion PROPERTIES


        #region CONSTRUCTOR
        public DataProvider()
        {
            this.ds = new DataSetRestoBook();
        }
        #endregion CONSTRUCTOR


        #region PREPARE DATAPROVIDER METHODS
        /// <summary>
        /// Prepares the restaurant dataprovider.
        /// </summary>
        public void PrepareRestaurantDP()
        {
            using (RestoBook.Common.Model.DataSetRestoBookTableAdapters.RESTAURANTTableAdapter daRestaurant = new RestoBook.Common.Model.DataSetRestoBookTableAdapters.RESTAURANTTableAdapter())
            {
                daRestaurant.Fill(ds.RESTAURANT);
            }
        }
        
        /// <summary>
        /// Prepares the foodtype dataprovider.
        /// </summary>
        public void PrepareFoodTypeDP()
        {
            using (RestoBook.Common.Model.DataSetRestoBookTableAdapters.FOODTYPETableAdapter daFoodType = new RestoBook.Common.Model.DataSetRestoBookTableAdapters.FOODTYPETableAdapter())
            {
                daFoodType.Fill(ds.FOODTYPE);
            }
        }

        /// <summary>
        /// Prepares the service dataprovider.
        /// </summary>
        public void PrepareServiceDP()
        {
            using (RestoBook.Common.Model.DataSetRestoBookTableAdapters.SERVICETableAdapter daService = new RestoBook.Common.Model.DataSetRestoBookTableAdapters.SERVICETableAdapter())
            {
                daService.Fill(ds.SERVICE);
            }
        }

        /// <summary>
        /// Prepares the Owner dataprovider.
        /// </summary>
        public void PrepareOwnerDP()
        {
            using (RestoBook.Common.Model.DataSetRestoBookTableAdapters.OWNERTableAdapter daOwner = new RestoBook.Common.Model.DataSetRestoBookTableAdapters.OWNERTableAdapter())
            {
                daOwner.Fill(ds.OWNER);
            }
        }

        /// <summary>
        /// Prepares the employee dataprovider.
        /// </summary>
        public void PrepareEmployeeDP()
        {
            using (RestoBook.Common.Model.DataSetRestoBookTableAdapters.EMPLOYEETableAdapter daEmployee = new RestoBook.Common.Model.DataSetRestoBookTableAdapters.EMPLOYEETableAdapter())
            {
                daEmployee.Fill(ds.EMPLOYEE);
            }
        }

        /// <summary>
        /// Prepares the pricelist dataprovider.
        /// </summary>
        public void PreparePriceListDP()
        {
            using (RestoBook.Common.Model.DataSetRestoBookTableAdapters.PRICELISTTableAdapter daPriceList = new RestoBook.Common.Model.DataSetRestoBookTableAdapters.PRICELISTTableAdapter())
            {
                daPriceList.Fill(ds.PRICELIST);
            }
        }

        /// <summary>
        /// Prepares the address dataprovider.
        /// </summary>
        public void PrepareAddressDP()
        {
            using (RestoBook.Common.Model.DataSetRestoBookTableAdapters.ADDRESSTableAdapter daAddress = new RestoBook.Common.Model.DataSetRestoBookTableAdapters.ADDRESSTableAdapter())
            {
                daAddress.Fill(ds.ADDRESS);
            }
        }

        /// <summary>
        /// Prepares the full dataprovider.
        /// </summary>
        public void PrepareFullDataProvider()
        {
            using (RestoBook.Common.Model.DataSetRestoBookTableAdapters.RESTAURANTTableAdapter daRestaurant = new RestoBook.Common.Model.DataSetRestoBookTableAdapters.RESTAURANTTableAdapter())
            {
                daRestaurant.Fill(ds.RESTAURANT);
            }

            using (RestoBook.Common.Model.DataSetRestoBookTableAdapters.FOODTYPETableAdapter daFoodType = new RestoBook.Common.Model.DataSetRestoBookTableAdapters.FOODTYPETableAdapter())
            {
                daFoodType.Fill(ds.FOODTYPE);
            }

            using (RestoBook.Common.Model.DataSetRestoBookTableAdapters.SERVICETableAdapter daService = new RestoBook.Common.Model.DataSetRestoBookTableAdapters.SERVICETableAdapter())
            {
                daService.Fill(ds.SERVICE);
            }

            using (RestoBook.Common.Model.DataSetRestoBookTableAdapters.OWNERTableAdapter daOwner = new RestoBook.Common.Model.DataSetRestoBookTableAdapters.OWNERTableAdapter())
            {
                daOwner.Fill(ds.OWNER);
            }

            using (RestoBook.Common.Model.DataSetRestoBookTableAdapters.EMPLOYEETableAdapter daEmployee = new RestoBook.Common.Model.DataSetRestoBookTableAdapters.EMPLOYEETableAdapter())
            {
                daEmployee.Fill(ds.EMPLOYEE);
            }
        }

        /// <summary>
        /// Prepare a DataAdapter for Reservation table
        /// </summary>
        public void PrepareReservationDP()
        {
            using (DataSetRestoBookTableAdapters.RESERVATIONTableAdapter daReservation = new DataSetRestoBookTableAdapters.RESERVATIONTableAdapter())
            {
                daReservation.Fill(ds.RESERVATION);
            }
        }

        public void PrepareCustomerDP()
        {
            using (DataSetRestoBookTableAdapters.CUSTOMERTableAdapter daCustomer = new DataSetRestoBookTableAdapters.CUSTOMERTableAdapter())
            {
                daCustomer.Fill(ds.CUSTOMER);
            }
        }

        public void PrepareFullReservation()
        {
            PrepareReservationDP();
            PrepareServiceDP();
            PrepareCustomerDP();
            PrepareRestaurantDP();
        }

        #endregion PREPARE DATAPROVIDER METHODS
    }
}

