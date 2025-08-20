
namespace eBusiness.Models.Repository
{
    public class MasterTeamRepository : IRepository<MasterTeam>
    {
        public MasterTeamRepository(AppDbContext _db)
        {
            Db = _db;
        }

        public AppDbContext Db { get; }

        public void Active(int id, MasterTeam entity)
        {
            MasterTeam data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public void Add(MasterTeam entity)
        {
            entity.IsActive = true;
            Db.MasterTeam.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, MasterTeam entity)
        {
            MasterTeam data = Find(id);
            data.IsActive = false;
            data.IsDelete = true;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public MasterTeam Find(int id)
        {
            var data = Db.MasterTeam.SingleOrDefault(x => x.MasterTeamId == id);
            return data;
        }

        public void Update(int id, MasterTeam entity)
        {
            Db.MasterTeam.Update(entity);
            Db.SaveChanges();
        }

        public IList<MasterTeam> View()
        {
            return Db.MasterTeam.Where(data => data.IsDelete == false).ToList();
        }

        public IList<MasterTeam> ViewFromClient()
        {
            return Db.MasterTeam.Where(data => data.IsDelete == false && data.IsActive == true).ToList();
        }
    }
}
