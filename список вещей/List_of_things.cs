using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIST_OF_THINGS {
    internal class List_of_things  {
        public List_of_things(string Name) {
            Name_ = Name;
           
        }   
        public List_of_things(List<string> list) { }
            
        public string Name_ { get; set; }
        public int id { get; set; }


    }
}
