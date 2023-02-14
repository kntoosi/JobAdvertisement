using System.Collections.Generic;
using System.ComponentModel;

namespace CrouseServiceAdvertisement.Models
{
    public class DtPersonnelSearch
    {
        /// <summary>
        /// List of Personnel ID(srl)
        /// </summary>
        public List<int> Srls { get; set; }

        /// <summary>
        /// List of Personnel Code
        /// </summary>
        public List<int> PrsCodes { get; set; }

        /// <summary>
        /// List of Unit Id (Manager Organ Id)
        /// </summary>
        public List<int> UnitIds { get; set; }

        /// <summary>
        /// List of Manager Personnel Code
        /// </summary>
        public List<int> ManagerPrsCodes { get; set; }

        /// <summary>
        /// A part of first name or last name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Personnel Status
        /// <para>
        /// <list type="table">
        /// <item><term>0</term><description>Not Active</description></item>
        /// <item><term>1</term><description>Active</description></item>
        /// <item><term>2</term><description>All</description></item>
        /// </list>
        /// </para>
        /// </summary>
        [DefaultValue(1)]
        public byte Active { get; set; }
    }

}
