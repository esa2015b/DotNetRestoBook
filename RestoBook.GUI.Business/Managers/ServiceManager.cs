using RestoBook.Common.Model;
using RestoBook.Common.Model.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoBook.Common.Business.Managers
{
    /// <summary>
    /// The servicemanager, deals with the restaurants services.
    /// </summary>
    public class ServiceManager : IServiceManager
    {
        #region PROPERTIES
        private DataProvider dp;
        #endregion PROPERTIES


        #region CONSTRUCTOR
        public ServiceManager()
        {
            this.dp = new DataProvider();
            this.dp.PrepareServiceDP();
        }
        #endregion CONSTRUCTOR


        #region PUBLIC METHODS
        /// <summary>
        /// Gets a service by it's ID
        /// </summary>
        /// <param name="serviceId"></param>
        /// <returns></returns>
        public Service GetServiceById(int serviceId)
        {
            this.RefreshDataSet();
            Service service = new Service();
            service = (from s in this.dp.ds.SERVICE
                     where s.SERVICEID == serviceId
                     select new Service()
                     {
                         Id = (int)s.SERVICEID,
                         BeginShift = s.STARTSHIFT,
                         EndShift = s.ENDSHIFT,
                         IsEnabled = s.ENABLE,
                         PlaceQuantity = s.PLACEQUANTITY,
                         ServiceDay = s.SERVICEDAY.DayOfWeek,
                         ServiceDate = s.SERVICEDAY,
                         TypeService = s.TYPESERVICE
                     }).FirstOrDefault();
            if (service == null)
            {
                //throw new Exception("No restaurant found with this id.");
            }
            return service;
        }

        /// <summary>
        /// Gets a Dictionary of services linked to the restaurant
        /// </summary>
        /// <param name="restaurantId"></param>
        /// <returns></returns>
        public Dictionary<int, string> GetServicesDictionary(int restaurantId)
        {
            this.RefreshDataSet();
            Dictionary<int, string> services = new Dictionary<int, string>();

            this.dp.ds.SERVICE.Where(s => s.RESTAURANTID == restaurantId)
                              .ToList()
                              .ForEach(s => services.Add(
                                  (int)s.SERVICEID,
                                  s.SERVICEDAY.DayOfWeek.ToString() + " " + s.SERVICEDAY.ToString() + " " + s.TYPESERVICE + " - " + s.PLACEQUANTITY.ToString()
                              ));
            return services;
        }

        /// <summary>
        /// Gets a list of services linked to the restaurant.
        /// </summary>
        /// <param name="restaurantId">The restaurant identifier.</param>
        /// <returns>A list of services.</returns>
        public List<Service> GetServices(int restaurantId)
        {
            this.RefreshDataSet();
            List<Service> services = new List<Service>();

            this.dp.ds.SERVICE.Where(s => s.RESTAURANTID == restaurantId)
                              .ToList()
                              .ForEach(s => services.Add(new Service() 
                                                            { 
                                                                Id = (int)s.SERVICEID,
                                                                BeginShift = s.STARTSHIFT,
                                                                EndShift = s.ENDSHIFT,
                                                                IsEnabled = s.ENABLE,
                                                                PlaceQuantity = s.PLACEQUANTITY,
                                                                ServiceDay = s.SERVICEDAY.DayOfWeek,
                                                                ServiceDate = s.SERVICEDAY,
                                                                TypeService = s.TYPESERVICE
                                                            }));
            return services;
        }

        /// <summary>
        /// Creates a new service row.
        /// </summary>
        /// <param name="service">The service row to create.</param>
        /// <param name="restaurantId">The service's restaurant identifier.</param>
        /// <returns>True in case of successful creation, false in case of failure.</returns>
        public bool CreateService(Service service, int restaurantId)
        {
            int nbrRowsCreated = -1;

            using (RestoBook.Common.Model.DataSetRestoBookTableAdapters.SERVICETableAdapter daService = new Model.DataSetRestoBookTableAdapters.SERVICETableAdapter())
            {
                nbrRowsCreated = daService.Insert(restaurantId,
                                                  service.ServiceDate,
                                                  service.TypeService,
                                                  service.BeginShift,
                                                  service.EndShift,
                                                  service.PlaceQuantity,
                                                  service.IsEnabled);
            }
            return nbrRowsCreated > 0;
        }

        /// <summary>
        /// Deletes a given service for a specific restaurant.
        /// </summary>
        /// <param name="service">The service to delete.</param>
        /// <param name="restaurantId">The service's restaurant identifier.</param>
        /// <returns>True in case of successful delete, false in case of failure.</returns>
        public bool DeleteService(Service service, int restaurantId)
        {
            int nbrRowsDeleted = -1;

            using (RestoBook.Common.Model.DataSetRestoBookTableAdapters.SERVICETableAdapter daService = new Model.DataSetRestoBookTableAdapters.SERVICETableAdapter())
            {
                nbrRowsDeleted = daService.Delete(service.Id,
                                                  restaurantId,
                                                  service.ServiceDate,
                                                  service.TypeService,
                                                  service.BeginShift,
                                                  service.EndShift,
                                                  service.PlaceQuantity,
                                                  service.IsEnabled);
            }
            return nbrRowsDeleted > 0;
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
            this.dp.PrepareServiceDP();
        }
        #endregion PRIVATE METHODS

    }
}
