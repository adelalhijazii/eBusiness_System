
namespace eBusiness.Models.Repository
{
    public class MasterUsefullLinksRepository : IRepository<MasterUsefullLinks>
    {
        public MasterUsefullLinksRepository(AppDbContext _db)
        {
            Db = _db;
        }

        public AppDbContext Db { get; }

        public void Active(int id, MasterUsefullLinks entity)
        {
            MasterUsefullLinks data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public void Add(MasterUsefullLinks entity)
        {
            entity.IsActive = true;
            Db.MasterUsefullLinks.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, MasterUsefullLinks entity)
        {
            MasterUsefullLinks data = Find(id);
            data.IsActive = false;
            data.IsDelete = true;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public MasterUsefullLinks Find(int id)
        {
            var data = Db.MasterUsefullLinks.SingleOrDefault(x => x.MasterUsefullLinksId == id);
            return data;
        }

        public void Update(int id, MasterUsefullLinks entity)
        {
            Db.MasterUsefullLinks.Update(entity);
            Db.SaveChanges();
        }

        public IList<MasterUsefullLinks> View()
        {
            return Db.MasterUsefullLinks.Where(data => data.IsDelete == false).ToList();
        }

        public IList<MasterUsefullLinks> ViewFromClient()
        {
            return Db.MasterUsefullLinks.Where(data => data.IsDelete == false && data.IsActive == true).ToList();
        }
    }
}
