using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_OnlineCourse.Models.MSSQL;
using Microsoft.Practices.Unity;

namespace MVC_OnlineCourse.Models
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();
            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));
            return;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IRepository<Student>, MSSQLRepository<Student>>();
            container.RegisterType<IRepository<Course>, MSSQLRepository<Course>>();
            container.RegisterType<IRepository<Booking>, MSSQLRepository<Booking>>();

            return container;
        }
    }
}