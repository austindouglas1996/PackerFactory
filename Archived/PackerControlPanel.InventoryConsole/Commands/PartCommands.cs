using CommandHandlerLib.Attributes;
using PackerControlPanel.Core.Domain;
using PackerControlPanel.Core.Repository;
using PackerControlPanel.InventoryConsole.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.InventoryConsole.Commands
{
    [CommandLibrary("Parts")]
    public class PartCommands
    {
        private static IPartRepository Parts
        {
            get
            {
                IPartRepository parts = CommandUtility.AlkonInventory.Parts;
                if (parts == null)
                    throw new ArgumentNullException("Inventory is null.");

                return parts;
            }
        }

        [Command("AddPart", "Adds a new part into the database.")]
        public static string AddPart(string partName, int boxCount)
        {
            return AddPart(partName, boxCount, "", PackageType.None);
        }

        [Command("AddPart", "Adds a new part into the database.")]
        public static string AddPart(string partName, int boxCount, string description, PackageType boxType)
        {
            if (Parts.FirstOrDefault(p => p.Name == partName) != null)
                return string.Format("<r>A part already exists by that name. Failed to create part.");

            Part newPart = new Part(partName, boxCount, description, boxType);

            Parts.Add(newPart);

            return string.Format("Added the part '{0}' with the ID of '{1}'.", partName, newPart.ID);
        }

        [Command("AddParts", "Adds an array of parts into the collection.")]
        public static IEnumerator<string> AddParts(string[] partName, int[] boxCount, string[] description, PackageType[] boxType)
        {
            for (int i = 0; i < partName.Count(); i++)
            {
                yield return AddPart(partName[i], boxCount[i], description[i], boxType[i]);
            }
        }


        [Command("GetPart", "Displays information about a part based on ID.")]
        public static string GetPart(int id, string[] args = null)
        {
            Part part = Parts.GetPartWithJobs(id);

            if (part == null)
                return string.Format("<r>Invalid value. Failed to find a part by the ID of '{0}'.", id);

            StringBuilder sb = new StringBuilder();

            Part[] children = Parts.GetPartChildren(part);

            // Console table strings.
            string partTable = new Part[] { part }.ToTable().ToString();
            string parentTable = part.Parent == null ? " No Parent.\n" : new Part[] { part.Parent }.ToTable().ToString();
            string childrenTable = children.Count() == 0 ? " No children.\n" : children.ToTable().ToString();
            string jobTable = part.Jobs.Count() == 0 ? " No jobs.\n" : part.Jobs.ToArray().ToTable().ToString();

            // Packaging information table.
            ConsoleTable packageTable = new ConsoleTable("Package Type", "Package Description");
            packageTable.AddRow(part.PackingInfo.BoxType.ToString(), part.PackingInfo.Description);

            // Write.
            sb.AppendLine(" Part Information:\n" + partTable.ToString());
            sb.AppendLine(" Parent Information:\n" + parentTable.ToString());
            
            // Packing information.
            sb.AppendLine(" Part Packaging Information:\n" + packageTable.ToString());
            sb.AppendLine(" Packing Instructions: \n " + part.PackingInfo.BoxingDirections + "\n");

            // Children.
            sb.AppendLine(" Children:\n" + childrenTable.ToString());

            // Jobs.
            sb.AppendLine(" Jobs:\n" + jobTable.ToString());

            return sb.ToString();
        }

        [Command("GetParts", "Displays information about all parts within the database.")]
        public static string GetParts()
        {
            if (Parts.GetAll().Count() == 0)
                return "No parts found.";

            return Parts.GetAll().ToArray().ToTable().ToString();
        }

        [Command("FindPart", "Displays information about a part based on name.")]
        public static string FindPart(string partName)
        {
            Part part = Parts.GetPartWithJobs(Parts.GetPartID(partName));
            if (part == null)
                return string.Format("<r>Invalid value. Failed to find a part by the name of '{0}'.", partName);

            return GetPart(part.ID, null);
        }

        [Command("FindPart", "Displays information about a part based on value and search type.")]
        public static string FindPart(string text, int searchType, string[] args = null)
        {
            if (searchType != 0 && searchType != 1)
                return "<r>Invalid search type. Use 0 for start of text. Use 1 for end of text.";

            Part part = null;

            if (searchType == 0)
                part = Parts.FirstOrDefault(p => p.Name.ToLower().StartsWith(text.ToLower()));
            else
                part = Parts.FirstOrDefault(p => p.Name.ToLower().EndsWith(text.ToLower()));

            if (part == null)
                return string.Format("<r>Failed to find a part that {0} with '{1}'", searchType == 0 ? "starts" : "ends", text);

            return GetPart(part.ID, args);
        }


        [Command("RemovePart", "Removes a part based on ID.")]
        public static string RemovePart(string name)
        {
            Parts.Remove(Parts.GetPartWithJobs(Parts.GetPartID(name)));
            return string.Format("Removed the part '{0}'.", name);
        }

        [Command("RemoveAll", "Removes all parts within the database.")]
        public static string RemoveAll(string value = "")
        {
            if (value.ToLower() != "deleteall")
                return "<r>Invalid value. Please type 'deleteAll' when using this command to delete all parts.";

            Parts.RemoveAll();

            return "Removed all parts from with the database.";
        }




        [Command("EditPartProp", "Edits the property of a part based on name.")]
        public static string EditPartProp(string partName, string propName, string propValue)
        {
            Part part = Parts.GetPartWithJobs(Parts.GetPartID(partName));
            if (part == null)
                return string.Format("<r>Failed to find a part by the name '{0}'.", partName);

            var propArray = part.GetType().GetProperties().ToList();
            var prop = propArray.Find(f => f.Name.ToLower() == propName.ToLower());

            if (prop == null)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(string.Format("Unable to find a property with the name '{0}'.", propName));
                sb.AppendLine("The following list is the properties you may edit.");

                ConsoleTable table = new ConsoleTable("Property", "Value Type");

                table.AddRow("ID", "Int32");
                table.AddRow("ParentID", "Int32");
                table.AddRow("Name", "String");
                table.AddRow("Description", "String");
                table.AddRow("DefaultBoxCount", "Int32");
                table.AddRow("BoxingDirections", "String");
              
            }

            try
            {
                var nullableType = Nullable.GetUnderlyingType(prop.PropertyType);

                prop.SetValue(part, Convert.ChangeType(propValue, nullableType != null ? nullableType : prop.PropertyType));

                CommandUtility.AlkonInventory.Parts.Edit(part);

                return string.Format("The part '{0}' property '{1}' has been edited to '{2}'.", partName, propName, propValue);
                
            }
            catch (Exception e)
            {
                return string.Format("<r>Failed to edit the property '{0}'. See log for details.", propName);
            }
        }
    }
}
