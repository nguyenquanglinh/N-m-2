using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolFacebook
{
   public class Groups
    {
        

        public Groups(string name,string herf)
        {
            this.Name = name;
            this.Href = herf;
        }
        public override string ToString()
        {
            return Name;
        }
        public Groups()
        {
 
        }
        public string Href { get;  set; }
        public string Name { get;  set; }
    }
}
