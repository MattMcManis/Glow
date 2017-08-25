![https://github.com/MattMcManis/Glow](https://raw.githubusercontent.com/MattMcManis/Glow/master/images/glow-logo.png)

# Glow
mpv Configurator for Windows

* [Overview](#overview)
* [Downloads](#downloads)
* [Installation](#installation)
* [Troubleshooting](#troubleshooting)
* [Build](#build)

## Overview

Glow is a configuration file generator for the mpv media player.

![Glow](https://raw.githubusercontent.com/MattMcManis/Glow/master/images/glow.png)

## Downloads
#### Glow 
* https://github.com/MattMcManis/Glow/releases
* Requires [Microsoft .NET Framework 4.5](https://www.microsoft.com/en-us/download/details.aspx?id=30653)

#### mpv

* Site https://mpv.io
* Builds https://mpv.srsfckn.biz
* Keyboard Shortcuts  https://mpv.io/manual/master/#keyboard-control

## Installation

### Glow
Glow is portable and can be run from any location on the computer.

1. Simply generate a configuration and press Save. 
2. It will automatically find or create the correct config directory.
3. Save your custom user profiles to ini files.

### mpv

https://github.com/rossy/mpv-install/blob/master/README.md

1. Download the [latest build](https://mpv.srsfckn.biz) of mpv and unzip to a location of your choice, such as `C:\Program Files\`.
2. Download the [mpv install bat file](https://github.com/rossy/mpv-install/archive/master.zip), and run it as Administrator from the same folder as `mpv.exe`
3. After your file associations have been set, openining a video or audio file will automatically launch mpv.

## Troubleshooting

If mpv crashes or displays artifacts, change or remove the following:

* Video/Audio Driver
* OpenGL PBO
* HW Decoder


## Build
Visual Studio 2015
<br />
WPF, C#, XAML
<br />
Visual C++ 19.0 Compiler