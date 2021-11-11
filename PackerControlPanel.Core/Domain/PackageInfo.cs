using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PackerControlPanel.Core.Domain
{
    public class PackageInfo
    {
        public static string[] BoxTypes
        {
            get
            {
                return new string[]
                {
                    "None",
                    "8X6X4",
                    "8X6X6",
                    "8X8X8",
                    "Mexico Box",
                    "Small Bag",
                    "Medium Bag",
                    "Large Bag",
                    "Green Bin",
                    "Coloured Tote",
                };
            }
        }

        public PackageInfo()
        {
            this.BoxingDirections = "";
            this.BoxType = PackageInfo.BoxTypes[0];
        }
        public PackageInfo(string boxType, string boxingDirections)
        {
            this.BoxingDirections = boxingDirections;
            this.BoxType = boxType;
        }

        [XmlElement("PackingDirections")]
        public string BoxingDirections { get; set; }

        [XmlElement("PackagingType")]
        public string BoxType { get; set; }

        public override string ToString()
        {
            return "Package Type: " + BoxType.ToString() + "\n Boxing Directions: " + BoxingDirections;
        }
    }
}
