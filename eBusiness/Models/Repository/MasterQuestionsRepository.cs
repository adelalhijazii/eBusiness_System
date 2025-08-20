
namespace eBusiness.Models.Repository
{
    public class MasterQuestionsRepository : IRepository<MasterQuestions>
    {
        public MasterQuestionsRepository(AppDbContext _db)
        {
            Db = _db;
        }

        public AppDbContext Db { get; }

        public void Active(int id, MasterQuestions entity)
        {
            MasterQuestions data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public void Add(MasterQuestions entity)
        {
            entity.IsActive = true;
            Db.MasterQuestions.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, MasterQuestions entity)
        {
            MasterQuestions data = Find(id);
            data.IsActive = false;
            data.IsDelete = true;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public MasterQuestions Find(int id)
        {
            var data = Db.MasterQuestions.SingleOrDefault(x => x.MasterQuestionsId == id);
            return data;
        }

        public void Update(int id, MasterQuestions entity)
        {
            Db.MasterQuestions.Update(entity);
            Db.SaveChanges();
        }

        public IList<MasterQuestions> View()
        {
            return Db.MasterQuestions.Where(data => data.IsDelete == false).ToList();
        }

        public IList<MasterQuestions> ViewFromClient()
        {
            return Db.MasterQuestions.Where(data => data.IsDelete == false && data.IsActive == true).ToList();
        }
    }
}
