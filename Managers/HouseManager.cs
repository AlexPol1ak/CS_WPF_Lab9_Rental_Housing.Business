using CS_WPF_Lab9_Rental_Housing.Domain.Entities;
using CS_WPF_Lab9_Rental_Housing.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CS_WPF_Lab9_Rental_Housing.Business.Managers
{
    public class HouseManager : BaseManager
    {
        public HouseManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #region basic CRUD operations
        public bool DeleteHouse()
        {
            return true;
        }

        public IEnumerable<House> FindHouse(Expression<Func<House, bool>> predicate)=>
            housesRepository.Find(predicate);

        public House GetHouseById(int id) =>housesRepository.Get(id);

        public IEnumerable<House> GetAllHouses() => housesRepository.GetAll();

        public void UpdateHouse(House house)
        {
            housesRepository.Update(house);
            unitOfWork.SaveChanges();
        }

        #endregion
    }

}
