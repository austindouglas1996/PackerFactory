using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using EntityRepository;
using PackerControlPanel.Core.Domain;
using PackerControlPanel.Core.Repository;

namespace PackerControlPanel.Data.Repository
{
    public class PartDescRepositoryList : List<PartDescInfo>, IPartDescRepository
    {
        public void AddRange(params PartDescInfo[] entities)
        {
            base.AddRange(entities);
        }

        public bool Contains(string partName)
        {
            return base.Find(p => p.PartName == partName) != null;
        }

        public void Edit(PartDescInfo entity)
        {
            throw new NotSupportedException();
        }

        public IEnumerable<PartDescInfo> Find(Func<PartDescInfo, bool> predicate)
        {
            return base.FindAll(new Predicate<PartDescInfo>(predicate));
        }

        public PartDescInfo FirstOrDefault(Func<PartDescInfo, bool> predicate)
        {
            var val = base.Find(new Predicate<PartDescInfo>(predicate));
            return val == null ? new PartDescInfo() : val;
        }

        public PartDescInfo Get(int ID)
        {
            return FirstOrDefault(p => p.ID == ID);
        }

        public IEnumerable<PartDescInfo> GetAll()
        {
            return base.ToArray();
        }

        public new void Remove(PartDescInfo entity)
        {
            base.Remove(entity);
        }

        public void RemoveAll()
        {
            base.Clear();
        }

        public void RemoveRange(IEnumerable<PartDescInfo> entities)
        {
            foreach (var entity in entities)
                base.Remove(entity);
        }

        public void SaveChanges()
        {
            throw new NotSupportedException();
        }

        public PartDescInfo SingleOrDefault(Expression<Func<PartDescInfo, bool>> predicate)
        {
            return FirstOrDefault(new Func<PartDescInfo, bool>(predicate.Compile()));
        }

        public static void SaveToFile(string path, PartDescRepositoryList instance)
        {
            bool fExists = File.Exists(path);
            using (var sw = new StreamWriter(new FileStream(path, fExists ? FileMode.Truncate : FileMode.CreateNew)))
            {
                XmlSerializer serializer = new XmlSerializer(instance.GetType());
                serializer.Serialize(sw, instance);
            }
        }

        public static PartDescRepositoryList LoadFromFile(string path)
        {
            using (var fs = new FileStream(path, FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(PartDescRepositoryList));
                return (PartDescRepositoryList)serializer.Deserialize(fs);
            }
        }
    }
}
