using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SVGDrill
{
    class SVGReader
    {
        /*  <svg width = "750px" height="894px">
  <circle cx = "72" cy="6" r="6" stroke="black" stroke-width="1" fill="none" />
        */

        const string SVGEntry = "<svg";
        const string PathEntry = "<path";
        const string CircleEntry = "<circle";

        const string WidthElement = "width=";
        const string HeightElement = "height=";
        const string CXElement = "cx=";
        const string CYElement = "cy=";
        const string RadiusElement = "r=";

        public List<DrillPoint> dPoints = new List<DrillPoint>();
        public Mapper pMap = new Mapper();

        public SVGReader(string filePath)
        {
            DrillSpeeds dSpeeds = new DrillSpeeds();


            //Open svg file into xml object
            using (StreamReader svgText = File.OpenText(filePath))
            {
                string line;
                while (svgText.Peek() > -1)
                {
                    line = svgText.ReadLine();
                    if (line.Contains(SVGEntry))
                    {
                        SVGParse(line);
                    }
                    else if (line.Contains(CircleEntry))
                    {
                        dPoints.Add(PointParse(line));
                    }
                    else if (line.Contains(PathEntry))
                    {
                        Point dp = PathParse(line);
                        pMap.PixHeight = dp.Y;
                        pMap.PixWidth = dp.X;
                    }
                    //else no line or something unexpected...  Continue
                }
            }
        }

        void SVGParse(string line)
        {
            string[] parts = line.Split(' ');
            foreach (string p in parts)
            {
                if (!p.Contains("<"))
                {
                    if (p.Contains(WidthElement)) pMap.PixWidth = Convert.ToInt32(GetNumber(p));
                    else if (p.Contains(HeightElement)) pMap.PixHeight = Convert.ToInt32(GetNumber(p));
                }
            }
            return;
        }

        DrillPoint PointParse(string line)
        {
            DrillPoint dp = new DrillPoint();
            string[] parts = line.Split(' ');
            foreach (string p in parts)
            {
                if (p.Contains(CXElement)) dp.X = Convert.ToDouble(GetNumber(p));
                else if (p.Contains(CYElement)) dp.Y = Convert.ToDouble(GetNumber(p));
                else if (p.Contains(RadiusElement)) dp.R = Convert.ToDouble(GetNumber(p));
            }
            return dp;
        }

        Point PathParse(string line)
        {
            //<path d="M816 0 L816 960 L0 960 L0 0 L816 0 Z " stroke="black" stroke-width="1" fill="none" />
            //"M816 0 L816 960 L0 960 L0 0 L816 0 Z "
            char[] trimChars = new char[] { 'M', 'L', 'Z', '\\', '\"', '>' };
            string d = line.Split('=')[1];
            string[] ml = d.Split(' ');
            int[] xPix = new int[4];
            int[] yPix = new int[4];
            xPix[0] = Convert.ToInt32(ml[0].Trim(trimChars)); yPix[0] = Convert.ToInt32(ml[1].Trim(trimChars));
            xPix[1] = Convert.ToInt32(ml[2].Trim(trimChars)); yPix[1] = Convert.ToInt32(ml[3].Trim(trimChars));
            xPix[2] = Convert.ToInt32(ml[4].Trim(trimChars)); yPix[2] = Convert.ToInt32(ml[5].Trim(trimChars));
            xPix[3] = Convert.ToInt32(ml[6].Trim(trimChars)); yPix[3] = Convert.ToInt32(ml[7].Trim(trimChars));
            Point dp = new Point(xPix.Max(), yPix.Max());
            return dp;
        }

        string GetNumber(string subLine)
        {
            //pulls the number xyz out of the parameter abc="xyz<px>"
            string numPart = subLine.Split('=')[1];
            char[] trimChars = new char[] { '=', 'p', '\\', 'x', '\"', '>', ' ' };
            numPart = numPart.Trim(trimChars);
            return numPart;
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
    }
}
