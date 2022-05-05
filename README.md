# Venus

- **Venus** is a "machinima" editor for *Super Mario 64*, built on the Unity Engine and [libsm64](https://github.com/libsm64).
- This is only an experimental demo. If you're looking to create machinima, check out [Saturn](https://github.com/Llennpie/Saturn).
- In order to compile or launch the editor, a prior copy of the game is required. This is to avoid including any copyrighted material.

#### Features

- Controller support
- Simple freeze camera
- Basic in-game color editor
- Configurable resolution/aspect ratio, fullscreen
- Supports both Windows and Linux

![Screenshot](https://media.discordapp.net/attachments/814630624920076298/965014792437919784/unknown.png)

## Download

Head to the [Releases](https://github.com/Llennpie/Venus/releases) page and follow the instructions to download Venus.

## Editing the Project

In order to play/test the project, a prior copy of the game is required.

- Place a vanilla 8 MB *Super Mario 64* US ROM into the repo's directory and rename it to `baserom.us.z64`. This is required to playtest the project in-editor. 
- After building the Unity project, place another `baserom.us.z64` next to the executable.
- Make sure to also copy `sm64extend.exe` and `assets.txt` into the `Venus_Data/` folder of the Unity build - this makes ROM asset extraction beyond Mario possible.
