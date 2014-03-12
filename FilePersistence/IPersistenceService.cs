using System.Collections.Generic;

namespace FilePersistence
{
    interface IPersistenceService<T>
    {
        IEnumerable<T> GetAll();
        int Create(T barTab);
        T GetAll(int id);
        bool Update(T barTab);
        bool Destroy(int id);
    }
}
