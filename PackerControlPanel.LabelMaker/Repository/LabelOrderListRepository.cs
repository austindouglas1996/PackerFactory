using EntityRepository;
using PackerControlPanel.Image.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Image.Repository
{
    public class LabelOrderListRepository : ILabelOrderRepository
    {
        private List<LabelOrderEntry> _Entries;

        public LabelOrderListRepository()
        {
            _Entries = new List<LabelOrderEntry>();
        }

        public void Add(LabelOrderEntry entity)
        {
            _Entries.Add(entity);
        }

        public void AddRange(params LabelOrderEntry[] entities)
        {
            _Entries.AddRange(entities);
        }

        public void Edit(LabelOrderEntry entity)
        {
            int index = _Entries.IndexOf(entity);
            _Entries[index] = entity;
        }

        public IEnumerable<LabelOrderEntry> Find(Func<LabelOrderEntry, bool> predicate)
        {
            return _Entries.FindAll(new Predicate<LabelOrderEntry>(predicate));
        }

        public LabelOrderEntry FirstOrDefault(Func<LabelOrderEntry, bool> predicate)
        {
            return _Entries.FirstOrDefault(predicate);
        }

        public LabelOrderEntry Get(int ID)
        {
            return _Entries[ID];
        }

        public IEnumerable<LabelOrderEntry> GetAll()
        {
            return _Entries;
        }

        public LabelOrderEntryFactory CreateFactory()
        {
            return new LabelOrderEntryFactoryDefault();
        }

        public void Remove(LabelOrderEntry entity)
        {
            _Entries.Remove(entity);
        }

        public void RemoveAll()
        {
            _Entries.Clear();
        }

        public void RemoveRange(IEnumerable<LabelOrderEntry> entities)
        {
            for (int i = 0; i < entities.Count(); i++)
                _Entries.Remove(entities.ElementAt(i));
        }

        public virtual void SaveChanges()
        {
            throw new NotSupportedException("The LabelOrderList is a runtime only object. Saving is not supported.");
        }

        public LabelOrderEntry SingleOrDefault(Expression<Func<LabelOrderEntry, bool>> predicate)
        {
            return _Entries.First(predicate.Compile());
        }
    }
}
