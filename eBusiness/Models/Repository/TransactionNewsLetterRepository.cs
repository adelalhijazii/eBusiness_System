
namespace eBusiness.Models.Repository
{
    public class TransactionNewsLetterRepository : IRepository<TransactionNewsLetter>
    {
        public TransactionNewsLetterRepository(AppDbContext _db)
        {
            Db = _db;
        }

        public AppDbContext Db { get; }

        public void Active(int id, TransactionNewsLetter entity)
        {
            TransactionNewsLetter data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public void Add(TransactionNewsLetter entity)
        {
            entity.IsActive = true;
            Db.TransactionNewsLetter.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, TransactionNewsLetter entity)
        {
            TransactionNewsLetter data = Find(id);
            data.IsActive = false;
            data.IsDelete = true;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public TransactionNewsLetter Find(int id)
        {
            var data = Db.TransactionNewsLetter.SingleOrDefault(x => x.TransactionNewsLetterId == id);
            return data;
        }

        public void Update(int id, TransactionNewsLetter entity)
        {
            Db.TransactionNewsLetter.Update(entity);
            Db.SaveChanges();
        }

        public IList<TransactionNewsLetter> View()
        {
            return Db.TransactionNewsLetter.Where(data => data.IsDelete == false).ToList();
        }

        public IList<TransactionNewsLetter> ViewFromClient()
        {
            return Db.TransactionNewsLetter.Where(data => data.IsDelete == false && data.IsActive == true).ToList();
        }
    }
}
