csharp-spritesheet-analyzer
===========================

Analyzes a horizontal sprite sheet sequence and finds offset + width.  
BSD license.  
For version log, view the individual files.  

![Example sprite](/SpriteSheetAnalyzer/bin/Debug/idle.png)

This project uses group-oriented programming framework "Play",  
in case you need to the Play.dll file to run.  
https://github.com/bvssvni/csharp-play

##How To Install and Run

You need to install the Mono framework to run this program:  
http://www.mono-project.com/

1. Download "SpriteSheetAnalyzer.zip".  
2. Extract the zip file.
3. Double-click "SpriteSheetAnalyzer.exe".
4. Click "Open...".
5. Select "idle.png".
6. Write down "offset" and "width" for using the sprite animation in your game.

##Image formats

PNG is the only format supported in this version.  
The PNG file must be cropped to a horizontal sequence.  

##Islands

An "island" is a continiously connected shape surrounded by transparent pixels.  
Since the islands are packed as rectangles, they can not overlap.

The analyzer can extract the islands for cases when a linear offset + width is not sufficient.  

If one frame contains more than one island, you can use the mouse cursor to link them.  
This will update the output coordinates.  

###Where To Find Sprite Sheets

http://spriters-resource.com

Enjoy!  
