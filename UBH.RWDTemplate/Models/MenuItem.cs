using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UBH.RWDTemplate.Models
{
    /// <summary>
    /// MenuItem class represents a row in the MenuItem table.
    /// </summary>
    public class MenuItem
    {
        public int Identity { get; set; }
        public string MenuName { get; set; }
        public string Label { get; set; }
        public int ParentId { get; set; }
        public int SortOrder { get; set; }
        public string URL { get; set; }
        public string Class { get; set; }
        public string Target { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}