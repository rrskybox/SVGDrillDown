namespace SVGDrillDown
{
    class Mapper
    {
        public int PixHeight { get; set; }
        public int PixWidth { get; set; }
        public double PixPerInch { get; set; }

        public double XPosition(int xPix) => xPix / PixPerInch;
        public double YPosition(int YPix) => YPix / PixPerInch;

    }
}

