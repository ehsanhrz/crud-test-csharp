namespace Mc2.CrudTest.Presentation.Shared.DataPersistance.Abstractions
{
    public interface IDBContext
    {
        void Commit();
        void RollBack();
    }
}