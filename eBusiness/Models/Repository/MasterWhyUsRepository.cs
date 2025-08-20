
namespace eBusiness.Models.Repository
{
    public class MasterWhyUsRepository : IRepository<MasterWhyUs>
    {
        public MasterWhyUsRepository(AppDbContext _db)
        {
            Db = _db;
        }

        public AppDbContext Db { get; }

        public void Active(int id, MasterWhyUs entity)
        {
            MasterWhyUs data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public void Add(MasterWhyUs entity)
        {
            entity.IsActive = true;
            Db.MasterWhyUs.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, MasterWhyUs entity)
        {
            MasterWhyUs data = Find(id);
            data.IsActive = false;
            data.IsDelete = true;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public MasterWhyUs Find(int id)
        {
            var data = Db.MasterWhyUs.SingleOrDefault(x => x.MasterWhyUsId == id);
            return data;
        }

        public void Update(int id, MasterWhyUs entity)
        {
            Db.MasterWhyUs.Update(entity);
            Db.SaveChanges();
        }

        public IList<MasterWhyUs> View()
        {
            return Db.MasterWhyUs.Where(data => data.IsDelete == false).ToList();
        }

        public IList<MasterWhyUs> ViewFromClient()
        {
            return Db.MasterWhyUs.Where(data => data.IsDelete == false && data.IsActive == true).ToList();
        }
    }
}
