namespace GVSU.Simulators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using GVSU.BusinessLogic;
    using GVSU.Contracts;
    using Serialization.DTO;

    public class CharityServiceSimulator : ICharityService
    {
        private readonly IDictionary<int, ICharity> _charityList;

        public CharityServiceSimulator()
        {
            _charityList = new Dictionary<int, ICharity>();
        }

        public int CreateCharity(ICharity charity)
        {
            _charityList.Add(charity.Id, charity);
            return charity.Id;
        }

        public void DeleteCharityById(int id)
        {
            _charityList.Remove(id);
        }

        public IEnumerable<ICharity> GetAllCharities()
        {
            return _charityList.Values;
        }

        public ICharity GetCharityById(int id)
        {
            return _charityList[id];
        }

        public void UpdateCharity(ICharity charity)
        {
            _charityList[charity.Id] = charity;
        }
    }
}