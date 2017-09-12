using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYSENDER.Models
{
    public class DttbParameter
    {
        public DttbParameter()
        {
            PdisplayLength = 10;
            Psearch = string.Empty;
            IsplayStart = 1;

        }

        /// <summary>
        /// Text used for filtering
        /// </summary>
        public string Psearch { get; set; }

        /// <summary>
        /// Number of records that should be shown in table
        /// </summary>
        public int PdisplayLength { get; set; }

        /// <summary>
        /// First record that should be shown(used for paging)
        /// </summary>
        public int IsplayStart { get; set; }

        /// <summary>
        /// Number of columns in table
        /// </summary>
        public int Icolumns { get; set; }

        /// <summary>
        /// Number of columns that are used in sorting
        /// </summary>
        public int IsortingCols { get; set; }

        /// <summary>
        /// Comma separated list of column names
        /// </summary>
        public string PColumns { get; set; }
    }
}
