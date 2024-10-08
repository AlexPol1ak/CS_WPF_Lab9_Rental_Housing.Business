﻿using CS_WPF_Lab9_Rental_Housing.Business.Managers;
using CS_WPF_Lab9_Rental_Housing.DAL.Repositories;
using CS_WPF_Lab9_Rental_Housing.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CS_WPF_Lab9_Rental_Housing.Business.Infastructure
{
    /// <summary>
    /// Managers factory
    /// </summary>
    public class ManagersFactory
    {
        private readonly IUnitOfWork efUnitOfWork;
        private HouseManager houseManager;
        private ApartmentManager apartmentManager;
        private PhotoManager photoManager;

        public ManagersFactory(string connectionStringName)
        {
            IConfigurationRoot config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).
                AddJsonFile("appsettings.json").Build();

            string connectionString = config.GetConnectionString(connectionStringName);
            efUnitOfWork = new EfUnitOfWork(connectionString);
        }

        /// <summary>
        /// Returns the houses management manager.
        /// </summary>
        /// <returns>HouseManager</returns>
        public HouseManager GetHouseManager()
        {
            if (houseManager is null) houseManager = new HouseManager(efUnitOfWork);
            return houseManager;
        }

        /// <summary>
        /// Returns the apartments management manager.
        /// </summary>
        /// <returns>ApartmentManager</returns>
        public ApartmentManager GetApartmentManager()
        {
            if (apartmentManager is null) apartmentManager = new ApartmentManager(efUnitOfWork);
            return apartmentManager;
        }

        /// <summary>
        /// Returns the photos management manager.
        /// </summary>
        /// <returns>PhotoManager</returns>
        public PhotoManager GetPhotoManager()
        {
            if (photoManager == null) photoManager = new PhotoManager(efUnitOfWork);
            return photoManager;
        }
    }
}
