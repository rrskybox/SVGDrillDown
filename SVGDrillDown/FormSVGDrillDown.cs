using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SVGDrillDown
{
    public partial class FormSVGDrillDown : Form
    {
        double imageScale;
        SvgData drawData;

        public FormSVGDrillDown()
        {
            InitializeComponent();
            imageScale = Properties.Settings.Default.ImageScale;
            StockWidthBox.Value = (decimal)Properties.Settings.Default.StockWidth;
            DrillDepthBox.Value = (decimal)Properties.Settings.Default.DrillDepth;
            PlungeRateBox.Value = (decimal)Properties.Settings.Default.PlungeRate;
            FeedRateBox.Value = (decimal)Properties.Settings.Default.FeedRate;
        }

        private void LoadSVGButton_Click(object sender, EventArgs e)
        {
            //Open and loads the SVG file

            DialogResult dr = OpenSVGFileDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                string svgPath = OpenSVGFileDialog.FileName;
                //svRead = new SVGReader(svgPath);
                drawData = new SvgData(svgPath);
                imageScale = drawData.pMap.PixWidth / (double)StockWidthBox.Value;
            }

       }

        private string AddLine(string inLine, string addLine)
        {
            return inLine + addLine + "\n";
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            //Generate Gcode
            string gCodeOut = GenerateGcode();

            //Opens and loads the SVG file
            DialogResult dr = SaveGcodeFileDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                string gcodePath = SaveGcodeFileDialog.FileName;
                File.WriteAllText(gcodePath, gCodeOut);
            }
        }

        private void VerifyGcodeButton_Click(object sender, EventArgs e)
        {
            //Generate Gcode
            string gCodeOut = GenerateGcode();
             //copy gcode to clipboard
           Clipboard.SetText(gCodeOut);
            //Open website
            System.Diagnostics.Process.Start("https://nraynaud.github.io/webgcode/");

        }

        private string GenerateGcode()
        {
            string gCodeOut = "";
            //Decode the svg file contents and generate Gcode

            double drillDepthmm = (double)DrillDepthBox.Value * 25.4;
            double mmPerPix = 25.4 / imageScale;

            string safeZpos = (25.4).ToString("0.0");  //Clearance of 1 inch above zero's Z
            string moveZpos = (12.5).ToString("0.0");  //Clearance of 1/2 inch above for moves
            string zPos = (-drillDepthmm).ToString("0.00");
            string plungeRate = ((int)(PlungeRateBox.Value) * 25.4).ToString("0");  // mm per minute
            string feedRate = ((int)(FeedRateBox.Value) * 25.4).ToString("0");   //mm per minute

            //Initialize CNC
            //gCodeOut = AddLine(gCodeOut, "(Design File: C:/ Users / rick -/ Documents / 3D Models / Cribbage / CribbageBoard1.c2d)");
            //gCodeOut = AddLine(gCodeOut, "(stockMin: 0.00mm, 0.00mm, -19.30mm)");
            //gCodeOut = AddLine(gCodeOut, "(stockMax: 177.80mm, 228.60mm, 0.00mm)");
            //gCodeOut = AddLine(gCodeOut, "(STOCK / BLOCK, 177.80, 228.60, 19.30, 0.00, 0.00, 19.30)");
            gCodeOut = AddLine(gCodeOut, "G90");  //Absolute positioning
            gCodeOut = AddLine(gCodeOut, "G21");  //Set Code to mm
            //gCodeOut = AddLine(gCodeOut, "(Move to safe Z to avoid workholding)");
            gCodeOut = AddLine(gCodeOut, "G53G0Z-5.000"); //Move to absolute (machine position) just short of home Z.
            //gCodeOut = AddLine(gCodeOut, "(Finish Toolpath 7)");
            gCodeOut = AddLine(gCodeOut, "M05");  //High resoluton tooling
            //gCodeOut = AddLine(gCodeOut, "(TOOL / MILL, 3.17, 0.00, 0.00, 0.00)");
            gCodeOut = AddLine(gCodeOut, "M6T102");  // TOOL / MILL, 3.17, 0.00, 0.00, 0.00
            gCodeOut = AddLine(gCodeOut, "M03S10000");
            //gCodeOut = AddLine(gCodeOut, "(PREPOSITION FOR RAPID PLUNGE)");
            gCodeOut = AddLine(gCodeOut, "G0X132.46Y220.93");
            //gCodeOut = AddLine(gCodeOut, "Z12.70F203"); //Raise z all the way up
            //gCodeOut = AddLine(gCodeOut, "G1Z12.5F203");  //Lower Z to clearance level
            gCodeOut = AddLine(gCodeOut, "G1X0Y0F" + feedRate);  // Move to 1" clearance level at origin

            //Note: starts from top as pixel
            double xCenterPix, yCenterPix;
            if (CenterOriginButton.Checked)
            {
                xCenterPix = drawData.pMap.PixWidth / 2;
                yCenterPix = drawData.pMap.PixHeight / 2;
            }
            else
            {
                xCenterPix = 0;
                yCenterPix = drawData.pMap.PixHeight;
            }

            // foreach (SVGReader.DrillPoint dp in svRead.dPoints)
            foreach (SvgData.DrillPoint dp in drawData.dPoints)
            {

                string xPlot = ((dp.X - xCenterPix) * mmPerPix).ToString("0.00");
                string yPlot = ((yCenterPix - dp.Y) * mmPerPix).ToString("0.00");

                //Drill Holes
                gCodeOut = AddLine(gCodeOut, "G1" + "X" + xPlot + "Y" + yPlot + "F" + feedRate); // Hole X:  Y:
                gCodeOut = AddLine(gCodeOut, "G1" + "Z0" + "F" + feedRate); ; // Drop to surface
                gCodeOut = AddLine(gCodeOut, "G1" + "Z" + zPos + "F" + plungeRate); // Make Hole
                gCodeOut = AddLine(gCodeOut, "G1" + "Z" + moveZpos + "F" + feedRate); //Move to clearance level (.5 inches)
            }

            //Park CNC
            gCodeOut = AddLine(gCodeOut, "Z" + safeZpos);
            gCodeOut = AddLine(gCodeOut, "M05");  //Turn off spindle
            gCodeOut = AddLine(gCodeOut, "M02");

            return gCodeOut;
        }
    }
}
