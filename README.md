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

### Ubuntu

Install dependencies:
```
sudo apt install -y binutils-mips-linux-gnu build-essential git libcapstone-dev pkgconf python3
```
Clone the repo from within the Linux shell:
```
git clone https://github.com/Llennpie/Venus.git
cd Venus
```

Build *libsm64*:
```
./build-libsm64
```

In order to play/test the project, a prior copy of the game is required. Place a vanilla *Super Mario 64* US ROM into the repo's directory and rename it to `baserom.us.z64`. After building the Unity project, place another `baserom.us.z64` next to the executable.

![Screenshot](screenshot.png)
