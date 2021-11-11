using EntityRepository;
using PackerControlPanel.Core.Domain;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml;
using System.Xml.Serialization;

namespace PackerControlPanel.Core.Domain
{
    [XmlRoot(ElementName = "Description")]
    public class PartDescInfo : IEntity
    {
        public PartDescInfo()
        {
            // Needed for XML Serialization.
        }
        
        public PartDescInfo(string partName, string description)
        {
            this.PartName = partName;
            this.FormalDescription = description;
        }

        public int ID { get; set; }
        public string PartName { get; set; }
        public string FormalDescription { get; set; }
    }
}