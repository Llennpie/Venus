# Venus

- **Venus** is a "machinima" editor for *Super Mario 64*, built on the Unity Engine and [libsm64](https://github.com/libsm64).
- This is only a demo. If you're looking to create machinima, check out [Saturn](https://github.com/Llennpie/Saturn).
- In order to compile or launch the editor, a prior copy of the game is required. This is to avoid including any copyrighted material.

#### Features

- Simple freeze camera
- In-game color code editor
- Configurable resolution/aspect ratio, fullscreen
- Supports both Windows and Linux

## Installation

Venus has been tested on both Windows (using [MSYS2 64-bit](https://www.msys2.org/)) and Ubuntu.

First, install dependencies:

#### Windows
```
pacman -S unzip make git mingw-w64-i686-gcc mingw-w64-x86_64-gcc mingw-w64-i686-glew mingw-w64-x86_64-glew mingw-w64-i686-SDL2 mingw-w64-i686-SDL mingw-w64-x86_64-SDL2 mingw-w64-x86_64-SDL python3
```
#### Ubuntu
```
sudo apt install build-essential git python3 libglew-dev libsdl2-dev
```

Next, clone the project and build libsm64:

```
git clone https://github.com/Llennpie/Venus
cd Venus
./build-libsm64
```

In order to play/test the project, a prior copy of the game is required. Place a vanilla *Super Mario 64* US ROM into the repo's directory and rename it to `baserom.us.z64`. After building the Unity project, place another `baserom.us.z64` next to the executable.

![Screenshot](screenshot.png)
