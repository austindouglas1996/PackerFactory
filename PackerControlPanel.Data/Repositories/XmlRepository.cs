using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using EntityRepository;
using PackerControlPanel.Core.Repository;
using System.Data.Entity;

namespace PackerControlPanel.Data.Repository
{
    public class XmlRepository<TEntity,TContext> : Repository<TContext, TEntity>, IXmlRepository 
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        public XmlRepository(TContext context, string fileName)
            : base(context)
        {
            this.FileName = fileName;
            this.Context = context;
        }

        public string FileName { get; protected set; }

        public void Save()
        {
            string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\";
            using (var sw = new StreamWriter(new FileStream(path + this.FileName, FileMode.OpenOrCreate)))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<TEntity>));
                serializer.Serialize(sw, this.GetAll());
            }       
        }
    }
}
