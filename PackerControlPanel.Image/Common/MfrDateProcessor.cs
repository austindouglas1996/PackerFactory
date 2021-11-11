namespace PackerControlPanel.Image
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows.Forms;
    using PackerControlPanel.Image.Helpers;
    
    public static class MfrDateProcessor
    {
        public static StandardMfrDateConverter Standard
        {
            get
            {
                return new StandardMfrDateConverter();
            }
        }

        public static Dictionary<DateTime[], int>[] DecipherString(IMfrDateConverter converter, string value)
        {
            return converter.DecipherString(value);
        }

        public static Tuple<DateTime[], int> DecipherLine(IMfrDateConverter converter, string value)
        {
            return converter.DecipherLine(value);
        }
    }
}