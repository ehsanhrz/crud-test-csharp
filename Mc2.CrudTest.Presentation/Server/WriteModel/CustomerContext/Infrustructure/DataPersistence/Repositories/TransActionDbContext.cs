using Mc2.CrudTest.Presentation.Shared.DataPersistance.Abstractions;

namespace Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.Infrustructure.DataPersistence.Repositories
{
    public class TransActionDbContext : IDBContext
    {
        private readonly AppDbContext dbContext;
        public TransActionDbContext(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Commit()
        {
            dbContext.Commit();
        }

        public void RollBack()
        {
            dbContext.RollBack();
        }
    }
}
