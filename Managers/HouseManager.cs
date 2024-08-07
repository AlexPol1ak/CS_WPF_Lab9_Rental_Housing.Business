using CS_WPF_Lab9_Rental_Housing.Domain.Entities;
using CS_WPF_Lab9_Rental_Housing.Domain.Interfaces;
using System.Linq.Expressions;

namespace CS_WPF_Lab9_Rental_Housing.Business.Managers
{
    public class HouseManager : BaseManager
    {
        public HouseManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #region basic CRUD operations

        /// <summary>
        /// Add house.
        /// </summary>

        public void AddHouse(House house)
        {
            housesRepository.Create(house);
        }

        /// <summary>
        /// Delete house by ID.
        /// </summary>
        /// <param name="id">House ID</param>
        public bool DeleteHouse(int id)
        {
            return housesRepository.Delete(id);
        }

        /// <summary>
        /// House search.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IEnumerable<House> FindHouse(Expression<Func<House, bool>> predicate) =>
            housesRepository.Find(predicate);

        /// <summary>
        /// Get house by ID.
        /// </summary>
        public House GetHouseById(int id, bool loadApartments = false)
        {
            if (loadApartments)
            {
                House house = housesRepository.Get(id);
                LoadApartments(house);
                return house;
            }
            return housesRepository.Get(id);
        }

        /// <summary>
        /// Get all houses.
        /// </summary>
        /// <returns>All houses</returns>
        public IEnumerable<House> GetAllHouses(bool loadApartments = false)
        {
            if (loadApartments)
            {
                var allHouses = housesRepository.GetAll().ToList();
                LoadApartments(allHouses);
                return allHouses;
            }

            return housesRepository.GetAll();
        }

        /// <summary>
        /// Update house.
        /// </summary>
        /// <param name="house"></param>
        public void UpdateHouse(House house)
        {
            housesRepository.Update(house);
            unitOfWork.SaveChanges();
        }

        /// <summary>
        /// Check to see if there's a house.
        /// </summary>
        public bool ContainsHouse(House house)
        {
            return housesRepository.Contains(house);
        }

        /// <summary>
        /// Count all houses.
        /// </summary>
        /// <returns></returns>
        public int CountHouses() => housesRepository.Count();

        #endregion

        public void LoadApartments(House house)
        {
            LoadRelatedEntities(house, h => h.Apartments);
        }

        public void LoadApartments(IEnumerable<House> houses)
        {
            foreach (House house in houses) LoadApartments(house);
        }
    }

}
