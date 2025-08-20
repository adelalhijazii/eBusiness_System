namespace eBusiness.Models.Repository
{
    public class MasterTransformingDataRepository : IRepository<MasterTransformingData>
    {
        public MasterTransformingDataRepository(AppDbContext _db)
        {
            Db = _db;
        }

        public AppDbContext Db { get; }

        public void Active(int id, MasterTransformingData entity)
        {
            MasterTransformingData data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public void Add(MasterTransformingData entity)
        {
            entity.IsActive = true;
            Db.MasterTransformingData.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, MasterTransformingData entity)
        {
            MasterTransformingData data = Find(id);
            data.IsActive = false;
            data.IsDelete = true;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public MasterTransformingData Find(int id)
        {
            var data = Db.MasterTransformingData.SingleOrDefault(x => x.MasterTransformingDataId == id);
            return data;
        }

        public void Update(int id, MasterTransformingData entity)
        {
            Db.MasterTransformingData.Update(entity);
            Db.SaveChanges();
        }

        public IList<MasterTransformingData> View()
        {
            return Db.MasterTransformingData.Where(data => data.IsDelete == false).ToList();
        }

        public IList<MasterTransformingData> ViewFromClient()
        {
            return Db.MasterTransformingData.Where(data => data.IsDelete == false && data.IsActive == true).ToList();
        }
    }
}
