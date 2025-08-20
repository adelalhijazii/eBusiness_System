
namespace eBusiness.Models.Repository
{
    public class MasterPortfolioCategoryMenuRepository : IRepository<MasterPortfolioCategoryMenu>
    {
        public MasterPortfolioCategoryMenuRepository(AppDbContext _db)
        {
            Db = _db;
        }

        public AppDbContext Db { get; }

        public void Active(int id, MasterPortfolioCategoryMenu entity)
        {
            MasterPortfolioCategoryMenu data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public void Add(MasterPortfolioCategoryMenu entity)
        {
            entity.IsActive = true;
            Db.MasterPortfolioCategoryMenu.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, MasterPortfolioCategoryMenu entity)
        {
            MasterPortfolioCategoryMenu data = Find(id);
            data.IsActive = false;
            data.IsDelete = true;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public MasterPortfolioCategoryMenu Find(int id)
        {
            var data = Db.MasterPortfolioCategoryMenu.SingleOrDefault(x => x.MasterPortfolioCategoryMenuId == id);
            return data;
        }

        public void Update(int id, MasterPortfolioCategoryMenu entity)
        {
            Db.MasterPortfolioCategoryMenu.Update(entity);
            Db.SaveChanges();
        }

        public IList<MasterPortfolioCategoryMenu> View()
        {
            return Db.MasterPortfolioCategoryMenu.Where(data => data.IsDelete == false).ToList();
        }

        public IList<MasterPortfolioCategoryMenu> ViewFromClient()
        {
            return Db.MasterPortfolioCategoryMenu.Where(data => data.IsDelete == false && data.IsActive == true).ToList();
        }
    }
}
