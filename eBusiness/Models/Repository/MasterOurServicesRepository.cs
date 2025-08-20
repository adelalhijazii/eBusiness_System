
namespace eBusiness.Models.Repository
{
    public class MasterOurServicesRepository : IRepository<MasterOurServices>
    {
        public MasterOurServicesRepository(AppDbContext _db)
        {
            Db = _db;
        }

        public AppDbContext Db { get; }

        public void Active(int id, MasterOurServices entity)
        {
            MasterOurServices data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public void Add(MasterOurServices entity)
        {
            entity.IsActive = true;
            Db.MasterOurServices.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, MasterOurServices entity)
        {
            MasterOurServices data = Find(id);
            data.IsActive = false;
            data.IsDelete = true;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public MasterOurServices Find(int id)
        {
            var data = Db.MasterOurServices.SingleOrDefault(x => x.MasterOurServicesId == id);
            return data;
        }

        public void Update(int id, MasterOurServices entity)
        {
            Db.MasterOurServices.Update(entity);
            Db.SaveChanges();
        }

        public IList<MasterOurServices> View()
        {
            return Db.MasterOurServices.Where(data => data.IsDelete == false).ToList();
        }

        public IList<MasterOurServices> ViewFromClient()
        {
            return Db.MasterOurServices.Where(data => data.IsDelete == false && data.IsActive == true).ToList();
        }
    }
}
