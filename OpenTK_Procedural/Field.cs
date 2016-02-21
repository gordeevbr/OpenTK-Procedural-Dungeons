using OpenTK;
using System.Drawing;

namespace OpenTK_Procedural
{
    static class Field
    {
        public static int FieldWidth { get; private set; } = 1000;
        public static int FieldHeight { get; private set; } = 1000;
        public static int FieldCellCap { get; private set; } = 150;
        public static int MaxCellLength { get; private set; } = 100;
        public static int MinCellLength { get; private set; } = 50;
        public static int DistanceFromMiddle { get; private set; } = 150;
        public static double AllowedSideDifferenceTimes { get; private set; } = 0.5;
        public static Point Middle
        {
            get
            {
                return new Point(FieldWidth / 2, FieldHeight / 2);
            }
        } 

        public static double TranslateCoordinatesX(double X, int ViewPortWidth)
        {
            return (X * ((double)ViewPortWidth / (double)FieldWidth));
        }

        public static double TranslateCoordinatesY(double Y, int ViewPortHeight)
        {
            return (Y * ((double)ViewPortHeight / (double)FieldHeight));
        }
    }
}
