using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolFacebook
{
    public class ListGroup
    {
        public ListGroup()
        {
            ListG = new List<Group>();
        }
        public ListGroup(List<Group> groups):this()
        {
            this.ListG = groups;
        }
        public override string ToString()
        {
            return "Count ListGroup= " + ListG.Count;
        }

        public override int GetHashCode()
        {
            var code = 0;
            foreach (var g in ListG)
            {
                code = code.GetHashCode() ^ g.GetHashCode();
            }
            return code;
        }

        public override bool Equals(object obj)
        {
            return this.GetHashCode() == obj.GetHashCode();
        }
        public List<Group> ListG { get; private set; }
    }
}
