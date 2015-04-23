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
        /// Gets a list of services linked to the restaurant.
        /// </summary>
        /// <param name="restaurantId">The restaurant identifier.</param>
        /// <returns>A list of services.</returns>
        public List<Service> GetServices(int restaurantId)
        {
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
                nbrRowsCreated = daService.Insert(service.Id,
                                                  restaurantId,
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
    }
}
