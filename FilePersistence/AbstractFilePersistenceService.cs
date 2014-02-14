using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace FilePersistence
{
    public abstract class AbstractFilePersistenceService<T> : IPersistenceService<T>
    {
        public abstract string FilePath { get; }

        public IEnumerable<T> Read()
        {
            var items = new List<T>();
            if (!File.Exists(FilePath))
            {
                return items;
            }

            var allAsString = File.ReadAllLines(FilePath);
            foreach (var objAsString in allAsString)
            {
                var obj = JsonConvert.DeserializeObject<T>(objAsString);
                items.Add(obj);
            }

            return items;
        }

        public int Create(T item)
        {
            if (!File.Exists(FilePath))
            {
                File.Create(FilePath);
            }

            var itemAsJson = JsonConvert.SerializeObject(item);
            using (var fileWriter = File.AppendText(FilePath))
            {
                fileWriter.WriteLine(itemAsJson);   
            }
            return 0;
        }

        public T Read(int id)
        {
            throw new NotSupportedException("Cannot Read Individual Items For File Persisted Objects.");
        }

        public bool Update(T barTab)
        {
            throw new NotSupportedException("Cannot Update File Persisted Objects.");
        }

        public bool Destroy(int id)
        {
            throw new NotSupportedException("Cannot Delete File Persisted Objects.");
        }
    }
}