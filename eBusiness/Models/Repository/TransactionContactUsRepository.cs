
namespace eBusiness.Models.Repository
{
    public class TransactionContactUsRepository : IRepository<TransactionContactUs>
    {
        public TransactionContactUsRepository(AppDbContext _db)
        {
            Db = _db;
        }

        public AppDbContext Db { get; }

        public void Active(int id, TransactionContactUs entity)
        {
            TransactionContactUs data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public void Add(TransactionContactUs entity)
        {
            entity.IsActive = true;
            Db.TransactionContactUs.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, TransactionContactUs entity)
        {
            TransactionContactUs data = Find(id);
            data.IsActive = false;
            data.IsDelete = true;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public TransactionContactUs Find(int id)
        {
            var data = Db.TransactionContactUs.SingleOrDefault(x => x.TransactionContactUsId == id);
            return data;
        }

        public void Update(int id, TransactionContactUs entity)
        {
            Db.TransactionContactUs.Update(entity);
            Db.SaveChanges();
        }

        public IList<TransactionContactUs> View()
        {
            return Db.TransactionContactUs.Where(data => data.IsDelete == false).ToList();
        }

        public IList<TransactionContactUs> ViewFromClient()
        {
            return Db.TransactionContactUs.Where(data => data.IsDelete == false && data.IsActive == true).ToList();
        }
    }
}
