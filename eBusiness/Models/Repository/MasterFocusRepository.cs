
namespace eBusiness.Models.Repository
{
    public class MasterFocusRepository : IRepository<MasterFocus>
    {
        public MasterFocusRepository(AppDbContext _db)
        {
            Db = _db;
        }

        public AppDbContext Db { get; }

        public void Active(int id, MasterFocus entity)
        {
            MasterFocus data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public void Add(MasterFocus entity)
        {
            entity.IsActive = true;
            Db.MasterFocus.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, MasterFocus entity)
        {
            MasterFocus data = Find(id);
            data.IsActive = false;
            data.IsDelete = true;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public MasterFocus Find(int id)
        {
            var data = Db.MasterFocus.SingleOrDefault(x => x.MasterFocusId == id);
            return data;
        }

        public void Update(int id, MasterFocus entity)
        {
            Db.MasterFocus.Update(entity);
            Db.SaveChanges();
        }

        public IList<MasterFocus> View()
        {
            return Db.MasterFocus.Where(data => data.IsDelete == false).ToList();
        }

        public IList<MasterFocus> ViewFromClient()
        {
            return Db.MasterFocus.Where(data => data.IsDelete == false && data.IsActive == true).ToList();
        }
    }
}
