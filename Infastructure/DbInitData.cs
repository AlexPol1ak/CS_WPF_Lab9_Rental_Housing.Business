using CS_WPF_Lab9_Rental_Housing.Business.Managers;
using CS_WPF_Lab9_Rental_Housing.Domain.Entities;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CS_WPF_Lab9_Rental_Housing.Business.Infastructure
{
    public static  class DbInitData
    {
        public static void SetupData(ManagersFactory factory, bool onlyEmpty = true)
        {
            
            var housesManager = factory.GetHouseManager();
            var apartmentManager = factory.GetApartmentManager();

            if (onlyEmpty is true)
            {
                if (housesManager.CountHouses() != 0 & apartmentManager.CountApartments() != 0)
                    return;
            }

            List<House> houses = CreateHouses();      
            foreach (House house in houses)
            {
                housesManager.AddHouse(house);
            }
            housesManager.SaveChanges();
            MessageBox.Show("Create");
        }
        #region Create House
        private static List<House> CreateHouses()
        {
            House h1 = new House()
            {
                City = "Минск",
                Street = "Одинцова",
                Number = 11,
                Block = null,
                CountFloors = 10,
                HasElevator = true,
                BuildingYear = 1994
            };
            House h2 = new House()
            {
                City = "Минск",
                Street = "Одоевского",
                Number = 22,
                Block = 2,
                CountFloors = 5,
                HasElevator = false,
                BuildingYear = 1980
            };

            List<House> houses = new List<House>() { h1, h2 };
            List<Apartment> apartments = CreateApartments();

            int countApart = apartments.Count / houses.Count;
            int numberApart = 0;
            int houseInd = 0;

            List<Apartment> temAddpApart = new List<Apartment>();
            for(int i = 0; i < apartments.Count; i++)
            {              
                temAddpApart.Add(apartments[i]);
                numberApart++;

                if(numberApart >= countApart)
                {
                    houses[houseInd].Apartments = temAddpApart;
                    houseInd++;
                    numberApart = 0;
                    temAddpApart = new List<Apartment>();
                }

            }
            
            return houses;

        }
        #endregion

        #region Create Apartment
        /// <summary>
        /// Creates 6 apartments
        /// </summary>
        /// <returns>6 fake apartments</returns>
        private static List<Apartment> CreateApartments()
        {
            Apartment a1 = new Apartment()
            {
                Number = 11,
                Floor = 2,
                CountRooms = 2,
                Area = 60.5,
                Owner = "Иванов А.А",
                OwnerTel = 375231234567,
                Price = 340
            };

            Apartment a2 = new Apartment()
            {
                Number = 21,
                Floor = 6,
                CountRooms = 2,
                Area = 60.5,
                Owner = null,
                OwnerTel = null,
                Price = null
            };

            Apartment a3 = new Apartment()
            {
                Number = 31,
                Floor = 8,
                CountRooms = 1,
                Area = 42.5,
                Owner = "Федоров А.А",
                OwnerTel = 375231270237,
                Price = 240
            };

            Apartment a4 = new Apartment()
            {
                Number = 12,
                Floor = 2,
                CountRooms = 2,
                Area = 58.5,
                Owner = "Сидоров А.А",
                OwnerTel = 375237654321,
                Price = 340
            };
            Apartment a5 = new Apartment()
            {
                Number = 22,
                Floor = 3,
                CountRooms = 3,
                Area = 78.5,
                Owner = null,
                OwnerTel = null,
                Price = 440
            };

            Apartment a6 = new Apartment()
            {
                Number = 32,
                Floor = 2,
                CountRooms = 2,
                Area = 50.5,
                Owner = "Фоменко А.А",
                OwnerTel = 3752412312345,
                Price = 340
            };

            var apartments = new List<Apartment>() { a1, a2, a3, a4, a5, a6 };
            IEnumerator<Photo> photoEnumerator = GetPhoto(12).GetEnumerator();

            //Adding 2 photos to each apartment
            foreach ( Apartment a in apartments)
            {
                List<Photo> photos = new List<Photo>();
                for(int i = 0; i <2; i++)

                {
                    photoEnumerator.MoveNext();
                    photos.Add(photoEnumerator.Current);                   
                } 
                a.Photos = photos;                           
            }
            return apartments;
        }
        #endregion

        #region Create Photo
        /// <summary>
        /// Photo generation.
        /// </summary>
        /// <param name="limitPhoto">Maximum number of photos received</param>
        /// <returns></returns>
        private static IEnumerable<Photo> GetPhoto(int limitPhoto = 10)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Images");
            var allFiles = Directory.EnumerateFiles(path).ToList();

            if (allFiles.Count == 0) yield break;

            int count = 0;
            int index = 0;
            while (count < limitPhoto)
            {
                // Получаем текущий файл по индексу
                string photoPath = allFiles[index];
                string photoName = Path.GetFileName(photoPath);
                Photo ph = new Photo() { PhotoName = photoName };

                yield return ph;

                count++;
                index++;
                // При достижения конца списка фото- начать завново.
                if (index >= allFiles.Count)
                {
                    index = 0;
                }
            }
        }
        #endregion
    }
}
