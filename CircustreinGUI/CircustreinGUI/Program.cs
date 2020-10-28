using System;
using System.Collections.Generic;
using CircustreinApplication;

namespace CircustreinGUI
{
    class Program
    {
        static void Main(string[] args)
        {
            AnimalCollection coll = new AnimalCollection();
            List<Animal> anim = new List<Animal>();
            Animal a1 = new Animal() {Size = Size.Large};
            Animal a2 = new Animal() { Size = Size.Medium };
            Animal a3 = new Animal() { Size = Size.Small };
            Animal a4 = new Animal() { Size = Size.Large };
            Animal a5 = new Animal() { Size = Size.Small };
            Animal a6 = new Animal() { Size = Size.Medium };

            anim.Add(a1);
            anim.Add(a2);
            anim.Add(a3);
            anim.Add(a4);
            anim.Add(a5);
            anim.Add(a6);

             anim = coll.SortBySize(anim);
        }
    }
}
