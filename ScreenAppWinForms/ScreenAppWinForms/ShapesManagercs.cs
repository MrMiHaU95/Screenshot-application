using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenAppWinForms
{
    /// <summary>
    /// zawiera listę kształtów już narysowanych przez usera i który muszą być rysowane przy każdym paint evencie 
    /// oraz drugą listę zawierającą listę kształtów redo czyli już cofniętych
    /// </summary>
    static class ShapesManagercs
    {
        private static List<Shape> shapeList = new List<Shape>();

        internal static List<Shape> ShapeList
        {
            get { return ShapesManagercs.shapeList; }
            set { ShapesManagercs.shapeList = value; }
        }

        private static List<Shape> shapeListUndo = new List<Shape>();

        internal static List<Shape> ShapeListUndo
        {
            get { return ShapesManagercs.shapeListUndo; }
            set { ShapesManagercs.shapeListUndo = value; }
        }

    }
}
