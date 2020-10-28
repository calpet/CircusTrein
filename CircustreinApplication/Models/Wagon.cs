using System;
using System.Collections.Generic;
using System.Text;

namespace CircustreinApplication.Models
{
    public class Wagon
    {
        public int Capacity { get; private set; }
        public List<Animal> Animals { get; set; }

        public Wagon()
        {
            Capacity = 10;
        }




    }
}
