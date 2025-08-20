
namespace eBusiness.Models.Repository
{
    public class MasterServicesRepository : IRepository<MasterServices>
    {
        public MasterServicesRepository(AppDbContext _db)
        {
            Db = _db;
        }

        public AppDbContext Db { get; }

        public void Active(int id, MasterServices entity)
        {
            MasterServices data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public void Add(MasterServices entity)
        {
            entity.IsActive = true;
            Db.MasterServices.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, MasterServices entity)
        {
            MasterServices data = Find(id);
            data.IsActive = false;
            data.IsDelete = true;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public MasterServices Find(int id)
        {
            var data = Db.MasterServices.SingleOrDefault(x => x.MasterServicesId == id);
            return data;
        }

        public void Update(int id, MasterServices entity)
        {
            Db.MasterServices.Update(entity);
            Db.SaveChanges();
        }

        public IList<MasterServices> View()
        {
            return Db.MasterServices.Where(data => data.IsDelete == false).ToList();
        }

        public IList<MasterServices> ViewFromClient()
        {
            return Db.MasterServices.Where(data => data.IsDelete == false && data.IsActive == true).ToList();
        }
    }
}
