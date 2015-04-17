using RestoBook.WebService.Business.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoBook.WebService
{
    public class NinjectBindings //: NinjectModule
    {
        /// <summary>
        /// When Winforms is started up, ninject will load all the bindings in order to know
        /// which interface gets replaced by which class.
        /// We can easily mock managers, objects, views, etc. this way, and replace the "real classes"
        /// by mocked classes.
        /// </summary>
        //public override void Load()
        //{
        //    //Bind<IRestoBookService>().To<RestoBookService>();
        //    //Bind<IEmployeeManager>().To<EmployeeManager>();
        //    //Bind<IFoodTypeManager>().To<FoodTypeManager>();
        //    //Bind<IOwnerManager>().To<OwnerManager>();
        //    //Bind<IPriceListManager>().To<PriceListManager>();
        //    //Bind<IRestaurantManager>().To<RestaurantManager>();
        //    //Bind<IServiceManager>().To<ServiceManager>();

        //}
    }
}
