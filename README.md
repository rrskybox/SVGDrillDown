# SVGDrillDown

Windows Forms Desktop App that converts Carbide Create SVG file to Shapeoko 3 Gcode for simple hole drilling.
Only supports drilling using a single bit per job.

Background

Carbide 3 Pro (beta) does not allow simple plunge drilling, i.e. 1/8 inch bits drilling 1/8 inch holes.  
All holes must be milled, that is, sized 10% or so greater than the bit chosen.  This app is a work-around.

Procedure

1. Install SVGDrillDown (Click Once app)
2. Create hole pattern using Carbide Create -> Design.
3. Add rectangle surrounding holes to designate stock size (lower left corner as origin -- X0, Y0, Z0)
4. Save design as *.svg file.
5. Launch SVGDrillDown -> Set stock width, drill depth, feed speed and plunge speed.
6. SVGDrillDown -> Open SVG to select *.svg file.
7. SVGDrillDown -> Save Gcode to save converted gcode.
8. Launch Carbide Motion: install bit, inialize Shapeoko, zero at lower left corner of stock (see #3).
9. Run job.

Software

SVGDrillDown is a Visual Studio 2019 project written in C#.  Installation .exe is in "publish" directory.  Download publish directory and install.

Be careful.  This is not a fully tested application and could cause damage to the CNC machine if not closely supervised.  
The user assumes full responsibility for use of this program.

