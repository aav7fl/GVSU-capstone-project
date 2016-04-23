namespace GVSU.Data.Services
{
    using System.Web;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using GVSU.Contracts;
    using GVSU.Contracts.Decorators;
    using GVSU.Data.Entities;
    using GVSU.Data.Factories;
    using System;
    public class SQLCharityService : CharityServiceDecorator, IDisposable
    {
        private readonly ApplicationDbContext _store;

        public SQLCharityService(ICharityService service, ApplicationDbContext dbContext)
            : base(service)
        {
            _store = dbContext;
        }

        public override IEnumerable<ICharity> GetAllCharities()
        {
            IEnumerable<Charity> c = _store.Charities
                .Include(e => e.Category)
                .Include(e => e.CreatedBy)
                .Include(e => e.UpdatedBy)
                .Include(e => e.Locations)
                .ToList();
            return c.Select(e => CharityFactory.CreateCharity(e));
        }

        public override ICharity GetCharityById(int id)
        {
            try
            {
                Charity charity = _store.Charities
                    .Include(e => e.Category)
                    .Include(e => e.CreatedBy)
                    .Include(e => e.UpdatedBy)
                    .Include(e => e.Locations)
                    .Include(e => e.Volunteers)
                    .Single(e => e.Id == id);

                charity.TotalHours = Math.Abs((_store.Hours
                    .Where(x => x.CharityId == id)
                    .Sum(x => DbFunctions.DiffMinutes(x.EndTime, x.StartTime)) ?? 0) / 60);

                charity.FollowersCount = charity.Volunteers.Count();

                charity.AverageRating = _store.Hours
                    .Where(x => x.CharityId == id)
                    .Average(g => 
                        g.CharityRating
                    );

                return CharityFactory.CreateCharity(charity);
            }
            catch (InvalidOperationException)
            {
                return null;
            }

        }

        public override int CreateCharity(ICharity charityDTO)
        {
            if (_store.Charities.Any(x => x.Name == charityDTO.Name))
                throw new ArgumentException(); //To-Do: Make custom exception for when duplicate names are found

            Charity c = CharityFactory.CreateCharity(charityDTO);
            if (charityDTO.Category != null)
            {
                c.CategoryId = charityDTO.Category.Id;
            }
            if (charityDTO.CreatedBy != null)
            {
                c.CreatedById = charityDTO.CreatedBy.Id;
            }

            if (charityDTO.UpdatedBy != null)
            {
                c.UpdatedById = charityDTO.UpdatedBy.Id;
            }
            c = _store.Charities.Add(c);
            _store.SaveChanges();
            return c.Id;
        }

        public override void UpdateCharity(ICharity charityDTO)
        {
            Charity oldC = _store.Charities
                .Include(x => x.CreatedBy)
                .Include(x => x.UpdatedBy)
                .Include(x => x.Locations)
                .Single(x => x.Id == charityDTO.Id);

            _store.Entry(oldC).CurrentValues.SetValues(charityDTO);

            if (charityDTO.Category != null)
            {
                oldC.CategoryId = charityDTO.Category.Id;
            }

            if (charityDTO.CreatedBy != null)
            {
                oldC.CreatedById = charityDTO.CreatedBy.Id;
            }

            if (charityDTO.UpdatedBy != null)
            {
                oldC.UpdatedById = charityDTO.UpdatedBy.Id;
            }

            _store.SaveChanges();
        }

        public override void DeleteCharityById(int id)
        {
            Charity c = _store.Charities
                .Single(e => e.Id == id);
            _store.Charities.Remove(c);
            _store.SaveChanges();
        }

        public void Dispose()
        {
        }
    }
}
