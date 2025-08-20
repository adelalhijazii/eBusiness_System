
namespace eBusiness.Models.Repository
{
    public class MasterAboutUsRepository : IRepository<MasterAboutUs>
    {
        public MasterAboutUsRepository(AppDbContext _db)
        {
            Db = _db;
        }

        public AppDbContext Db { get; }

        public void Active(int id, MasterAboutUs entity)
        {
            MasterAboutUs data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public void Add(MasterAboutUs entity)
        {
            entity.IsActive = true;
            Db.MasterAboutUs.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, MasterAboutUs entity)
        {
            MasterAboutUs data = Find(id);
            data.IsActive = false;
            data.IsDelete = true;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public MasterAboutUs Find(int id)
        {
            var data = Db.MasterAboutUs.SingleOrDefault(x => x.MasterAboutUsId == id);
            return data;
        }

        public void Update(int id, MasterAboutUs entity)
        {
            Db.MasterAboutUs.Update(entity);
            Db.SaveChanges();
        }

        public IList<MasterAboutUs> View()
        {
            return Db.MasterAboutUs.Where(data => data.IsDelete == false).ToList();
        }

        public IList<MasterAboutUs> ViewFromClient()
        {
            return Db.MasterAboutUs.Where(data => data.IsDelete == false && data.IsActive == true).ToList();
        }
    }
}
