
using Microsoft.EntityFrameworkCore;

namespace eBusiness.Models.Repository
{
    public class MasterPortfolioItemMenuRepository : IRepository<MasterPortfolioItemMenu>
    {
        public MasterPortfolioItemMenuRepository(AppDbContext _db)
        {
            Db = _db;
        }

        public AppDbContext Db { get; }

        public void Active(int id, MasterPortfolioItemMenu entity)
        {
            MasterPortfolioItemMenu data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public void Add(MasterPortfolioItemMenu entity)
        {
            entity.IsActive = true;
            Db.MasterPortfolioItemMenu.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, MasterPortfolioItemMenu entity)
        {
            MasterPortfolioItemMenu data = Find(id);
            data.IsActive = false;
            data.IsDelete = true;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public MasterPortfolioItemMenu Find(int id)
        {
            var data = Db.MasterPortfolioItemMenu.SingleOrDefault(x => x.MasterPortfolioItemMenuId == id);
            return data;
        }

        public void Update(int id, MasterPortfolioItemMenu entity)
        {
            Db.MasterPortfolioItemMenu.Update(entity);
            Db.SaveChanges();
        }

        public IList<MasterPortfolioItemMenu> View()
        {
            return Db.MasterPortfolioItemMenu.Include(x => x.MasterPortfolioCategoryMenu).Where(data => data.IsDelete == false).ToList();
        }

        public IList<MasterPortfolioItemMenu> ViewFromClient()
        {
            return Db.MasterPortfolioItemMenu.Where(data => data.IsDelete == false && data.IsActive == true).ToList();
        }
    }
}
