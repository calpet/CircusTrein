using System;

namespace CircustreinApplication
{
    public class Animal
    {
        public Size Size { get; set; }
        public Diet Diet { get; set; }

        public override string ToString()
        {
            return "\nSize: " + Size + "\n" + "Diet: " + Diet;
        }
    }
}
