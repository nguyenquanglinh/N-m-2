using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolFacebook
{
    public class Obj
    {
        public Obj(string className)
        {
            this.ClassName = className;
        }
        public override string ToString()
        {
            return ClassName;
        }
        public string ClassName { get; private set; }
    }
}
