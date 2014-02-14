using System.Collections.Generic;

namespace FilePersistence
{
    interface IPersistenceService<T>
    {
        IEnumerable<T> Read();
        int Create(T barTab);
        T Read(int id);
        bool Update(T barTab);
        bool Destroy(int id);
    }
}
