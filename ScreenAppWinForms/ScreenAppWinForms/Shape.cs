using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenAppWinForms
{
    //klasa abstrakcyjna dzięki niej można zpisywać Line Rectangle i Ellipse w tej samej liśćie typu bazowego
    abstract class Shape
    {
        //służy do odróżnienia obiektów pochodnych od siebie
        public int id;
    }
}
