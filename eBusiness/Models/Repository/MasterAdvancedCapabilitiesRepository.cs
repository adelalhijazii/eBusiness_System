
namespace eBusiness.Models.Repository
{
    public class MasterAdvancedCapabilitiesRepository : IRepository<MasterAdvancedCapabilities>
    {
        public MasterAdvancedCapabilitiesRepository(AppDbContext _db)
        {
            Db = _db;
        }

        public AppDbContext Db { get; }

        public void Active(int id, MasterAdvancedCapabilities entity)
        {
            MasterAdvancedCapabilities data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public void Add(MasterAdvancedCapabilities entity)
        {
            entity.IsActive = true;
            Db.MasterAdvancedCapabilities.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, MasterAdvancedCapabilities entity)
        {
            MasterAdvancedCapabilities data = Find(id);
            data.IsActive = false;
            data.IsDelete = true;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public MasterAdvancedCapabilities Find(int id)
        {
            var data = Db.MasterAdvancedCapabilities.SingleOrDefault(x => x.MasterAdvancedCapabilitiesId == id);
            return data;
        }

        public void Update(int id, MasterAdvancedCapabilities entity)
        {
            Db.MasterAdvancedCapabilities.Update(entity);
            Db.SaveChanges();
        }

        public IList<MasterAdvancedCapabilities> View()
        {
            return Db.MasterAdvancedCapabilities.Where(data => data.IsDelete == false).ToList();
        }

        public IList<MasterAdvancedCapabilities> ViewFromClient()
        {
            return Db.MasterAdvancedCapabilities.Where(data => data.IsDelete == false && data.IsActive == true).ToList();
        }
    }
}
