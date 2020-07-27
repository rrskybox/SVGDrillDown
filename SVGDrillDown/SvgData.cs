using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Xml.Linq;

namespace SVGDrillDown
{
    class SvgData
    {

        /*  
         *  <svg width = "750px" height="894px">
         *  <circle cx = "72" cy="6" r="6" stroke="black" stroke-width="1" fill="none" />
         *  <path d="M792 24 L792 936 L24 936 L24 24 L792 24 Z " stroke="black" stroke-width="1" fill="none" />
        */

        const string SVGEntry = "svg";
        const string PathEntry = "path";
        const string CircleEntry = "circle";

        const string WidthElement = "width";
        const string HeightElement = "height";
        const string CXElement = "cx";
        const string CYElement = "cy";
        const string RadiusElement = "r";
        const string DrawElement = "d";

        public List<DrillPoint> dPoints = new List<DrillPoint>();
        public Mapper pMap = new Mapper();

        public SvgData(string filePath)
        {
            //Open svg file into xml object
            XElement svgDoc = XElement.Load(filePath);
            foreach (XElement xe in svgDoc.Elements())
            {
                switch (xe.Name.LocalName)
                {
                    case SVGEntry:
                        {
                            IEnumerable<XAttribute> xat = xe.Attributes();
                            foreach (XAttribute xa in xat)
                            {
                                switch (xa.Name.LocalName)
                                {
                                    case WidthElement:
                                        {
                                            pMap.PixWidth = Convert.ToInt32(xa.Value);
                                            break;
                                        };
                                    case HeightElement:
                                        {
                                            pMap.PixHeight = Convert.ToInt32(xa.Value);
                                            break;
                                        }
                                }
                            }
                            break;
                        };
                    case CircleEntry:
                        {
                            IEnumerable<XAttribute> xat = xe.Attributes();
                            DrillPoint dp = new DrillPoint();
                            foreach (XAttribute a in xat)
                            {
                                switch (a.Name.LocalName)
                                {
                                    case CXElement:
                                        {
                                            dp.X = Convert.ToDouble(a.Value);
                                            break;
                                        };
                                    case CYElement:
                                        {
                                            dp.Y = Convert.ToDouble(a.Value);
                                            break;
                                        }
                                    case RadiusElement:
                                        {
                                            dp.R = Convert.ToDouble(a.Value);
                                            break;
                                        }
                                }
                            }
                            dPoints.Add(dp);
                            break;
                        };
                    case PathEntry:
                        {
                            IEnumerable<XAttribute> xat = xe.Attributes();
                            foreach (XAttribute xa in xat)
                            {
                                switch (xa.Name.LocalName)
                                {
                                    case DrawElement:
                                        {
                                            Point dp = PathParse(xa.Value);
                                            pMap.PixHeight = dp.Y;
                                            pMap.PixWidth = dp.X;
                                            break;
                                        }
                                }
                            };
                            break;
                        }
                        //else no line or something unexpected...  Continue
                }
            }
        }

        Point PathParse(string drawString)
        {
            //<path d="M816 0 L816 960 L0 960 L0 0 L816 0 Z " stroke="black" stroke-width="1" fill="none" />
            //"M816 0 L816 960 L0 960 L0 0 L816 0 Z "
            char[] trimChars = new char[] { 'M', 'L', 'Z', '\\', '\"', '>' };
            //string d = line.Split('=')[1];
            string[] vertex = drawString.Split(' ');
            int[] xPix = new int[4];
            int[] yPix = new int[4];
            xPix[0] = Convert.ToInt32(vertex[0].Trim(trimChars)); yPix[0] = Convert.ToInt32(vertex[1].Trim(trimChars));
            xPix[1] = Convert.ToInt32(vertex[2].Trim(trimChars)); yPix[1] = Convert.ToInt32(vertex[3].Trim(trimChars));
            xPix[2] = Convert.ToInt32(vertex[4].Trim(trimChars)); yPix[2] = Convert.ToInt32(vertex[5].Trim(trimChars));
            xPix[3] = Convert.ToInt32(vertex[6].Trim(trimChars)); yPix[3] = Convert.ToInt32(vertex[7].Trim(trimChars));
            Point dp = new Point(xPix.Max(), yPix.Max());
            return dp;
        }

        public struct DrillPoint
        {
            public double X;  //X position in inches
            public double Y;  //Y position in inches
            public double Z;  //Z depth in inches
            public double R;  //Hole radius in inches
        }

        public struct DrillSpeeds
        {
            public double Feed;  //Normal speed between holes
            public double Raise;  //Height, in inches, to lift before moving
            public double Plunge;  //Speed, in inches per sec, to drill into material
        }

        public class Mapper
        {
            public int PixHeight { get; set; }
            public int PixWidth { get; set; }
            public double PixPerInch { get; set; }

            public double XPosition(int xPix) => xPix / PixPerInch;
            public double YPosition(int YPix) => YPix / PixPerInch;

        }
    }
}

