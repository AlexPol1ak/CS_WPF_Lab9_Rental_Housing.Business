using CS_WPF_Lab9_Rental_Housing.Business.Managers;
using CS_WPF_Lab9_Rental_Housing.DAL.Repositories;
using CS_WPF_Lab9_Rental_Housing.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_WPF_Lab9_Rental_Housing.Business.Infastructure
{
    public  class ManagersFactary
    {
        private readonly IUnitOfWork efUnitOfWork;
        private  HouseManager houseManager;
        private ApartmentManager apartmentManager;
        private PhotoManager photoManager;

        public ManagersFactary(string connectionStringName)
        {
            IConfigurationRoot config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).
                AddJsonFile("appsettings.json").Build();
            
            string connectionString = config.GetConnectionString(connectionStringName);
            efUnitOfWork = new EfUnitOfWork(connectionString);
        }

        public HouseManager GetHouseManager()
        {
            if (houseManager is null) houseManager = new HouseManager(efUnitOfWork);
            return houseManager;
        }

        public ApartmentManager GetApartmentManager()
        {
            if(apartmentManager is null) apartmentManager = new ApartmentManager(efUnitOfWork);
            return apartmentManager;
        }

        public PhotoManager GetPhotoManager()
        {
            if(photoManager == null) photoManager = new PhotoManager(efUnitOfWork);
            return photoManager;
        }
    }
}
