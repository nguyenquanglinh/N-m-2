﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolFacebook
{
   public class Group:Obj
    {
        /// <summary>
        /// chứa địa chỉ+tên của group
        /// </summary>
        /// <param name="name">tên </param>
        /// <param name="herf">địa chỉ</param>
        public Group(string name,string herf):this()
        {
            this.Name = name;
            this.Href = herf;
        }
        //TODO: wpf


        public override bool Equals(object obj)
        {
            return this.GetHashCode() == obj.GetHashCode();
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Href.GetHashCode();
        }
        public override string ToString()
        {
            return "Name group= "+Name;
        }
        public Group():base("group")
        {
 
        }
        public string Href { get;  set; }
        public string Name { get;  set; }
    }
}
