using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Student Name: Trent B Minia
 * Student ID: 301041132
 * 
 * Description: Power class
 * 
 */

namespace COMP123_S2019_FinalTestA.Objects {
    public class Power {
        public string Name { get; set; }

        // Constructor
        public Power(string name) {
            this.Name = name;
        }

        public override string ToString() {
            return Name;
        }

    }
}
