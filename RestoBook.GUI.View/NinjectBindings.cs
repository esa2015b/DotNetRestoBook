using Ninject.Modules;
using RestoBook.Common.Business.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoBook.GUI.View
{
    public class NinjectBindings : NinjectModule
    {
        /// <summary>
        /// When Winforms is started up, ninject will load all the bindings in order to know
        /// which interface gets replaced by which class.
        /// We can easily mock managers, objects, views, etc. this way, and replace the "real classes"
        /// by mocked classes.
        /// </summary>
        public override void Load()
        {
            //Bind<IRestaurantManager>().To<RestaurantManager>();
            
        }
    }
}
