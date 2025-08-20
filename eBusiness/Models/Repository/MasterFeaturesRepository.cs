
namespace eBusiness.Models.Repository
{
    public class MasterFeaturesRepository : IRepository<MasterFeatures>
    {
        public MasterFeaturesRepository(AppDbContext _db)
        {
            Db = _db;
        }

        public AppDbContext Db { get; }

        public void Active(int id, MasterFeatures entity)
        {
            MasterFeatures data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public void Add(MasterFeatures entity)
        {
            entity.IsActive = true;
            Db.MasterFeatures.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, MasterFeatures entity)
        {
            MasterFeatures data = Find(id);
            data.IsActive = false;
            data.IsDelete = true;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public MasterFeatures Find(int id)
        {
            var data = Db.MasterFeatures.SingleOrDefault(x => x.MasterFeaturesId == id);
            return data;
        }

        public void Update(int id, MasterFeatures entity)
        {
            Db.MasterFeatures.Update(entity);
            Db.SaveChanges();
        }

        public IList<MasterFeatures> View()
        {
            return Db.MasterFeatures.Where(data => data.IsDelete == false).ToList();
        }

        public IList<MasterFeatures> ViewFromClient()
        {
            return Db.MasterFeatures.Where(data => data.IsDelete == false && data.IsActive == true).ToList();
        }
    }
}
