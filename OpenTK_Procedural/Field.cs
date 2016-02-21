using OpenTK;

namespace OpenTK_Procedural
{
    static class Field
    {
        public static int FieldWidth { get; private set; } = 1000;
        public static int FieldHeight { get; private set; } = 1000;

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
