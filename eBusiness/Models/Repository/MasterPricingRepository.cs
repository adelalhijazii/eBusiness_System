
namespace eBusiness.Models.Repository
{
    public class MasterPricingRepository : IRepository<MasterPricing>
    {
        public MasterPricingRepository(AppDbContext _db)
        {
            Db = _db;
        }

        public AppDbContext Db { get; }

        public void Active(int id, MasterPricing entity)
        {
            MasterPricing data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public void Add(MasterPricing entity)
        {
            entity.IsActive = true;
            Db.MasterPricing.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, MasterPricing entity)
        {
            MasterPricing data = Find(id);
            data.IsActive = false;
            data.IsDelete = true;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public MasterPricing Find(int id)
        {
            var data = Db.MasterPricing.SingleOrDefault(x => x.MasterPricingId == id);
            return data;
        }

        public void Update(int id, MasterPricing entity)
        {
            Db.MasterPricing.Update(entity);
            Db.SaveChanges();
        }

        public IList<MasterPricing> View()
        {
            return Db.MasterPricing.Where(data => data.IsDelete == false).ToList();
        }

        public IList<MasterPricing> ViewFromClient()
        {
            return Db.MasterPricing.Where(data => data.IsDelete == false && data.IsActive == true).ToList();
        }
    }
}
