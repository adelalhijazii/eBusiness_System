
namespace eBusiness.Models.Repository
{
    public class MasterFeatureRepository : IRepository<MasterFeature>
    {
        public MasterFeatureRepository(AppDbContext _db)
        {
            Db = _db;
        }

        public AppDbContext Db { get; }

        public void Active(int id, MasterFeature entity)
        {
            MasterFeature data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public void Add(MasterFeature entity)
        {
            entity.IsActive = true;
            Db.MasterFeature.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, MasterFeature entity)
        {
            MasterFeature data = Find(id);
            data.IsActive = false;
            data.IsDelete = true;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public MasterFeature Find(int id)
        {
            var data = Db.MasterFeature.SingleOrDefault(x => x.MasterFeatureId == id);
            return data;
        }

        public void Update(int id, MasterFeature entity)
        {
            Db.MasterFeature.Update(entity);
            Db.SaveChanges();
        }

        public IList<MasterFeature> View()
        {
            return Db.MasterFeature.Where(data => data.IsDelete == false).ToList();
        }

        public IList<MasterFeature> ViewFromClient()
        {
            return Db.MasterFeature.Where(data => data.IsDelete == false && data.IsActive == true).ToList();
        }
    }
}
