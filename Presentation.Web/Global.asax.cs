﻿using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Infrastructure.Data;

namespace Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Database.SetInitializer<SampleContext>(null);
            // The database initializer will create the database and the specified tables. 
            // If you're using an existing database with code first, don't execute any logic at all.

            // Database.SetInitializer(new CreateDatabaseIfNotExists<SampleContext>()); // Default, will run if nothing is done.
            // The default option. When the application runs the first time, entity framework will create
            // a code first database if it does not already exist. If the database exists and you have done modifications
            // this will throw an InvalidOperationException.

            // Database.SetInitializer(new DropCreateDatabaseAlways<SampleContext>());
            // This option, as the name suggests, will always drop and recreate the database when the application runs the first time.
            // All tables will be deleted as the database is dropped.

            // Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SampleContext>());
            // This option will drop and recreate the database if there are any changes to the model.

            // Alternatively, you can create your own initializer and pass it as the argument.
            // The class will need to implement one of the above in order to inherit some behaviour.
            // These Initializers has a custom seeding function, that will populate the database instance
            // with some fake data that can be used right away.
            if (Database.Exists("DefaultConnection"))
            {
                // This initilizer will run if there are no database.
                // Usually this is on the first run, or if the database was deleted.
                // Seeds with some fake data.
                Database.SetInitializer(new ChangeSampleSeedInitializer());
            }
            else 
            {
                // Runs if a database already exists. It drops the database, recreates it and seeds with some fake data.
                Database.SetInitializer(new CreateSampleSeedInitializer());
            }

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
