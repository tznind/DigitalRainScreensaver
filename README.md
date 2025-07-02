# DigitalRainScreensaver

Simple screensaver that outputs different colored digital rain effects on each monitor connected until you move mouse.

This is a dotnet WinForms project that uses WebView2

- Enumerates the number of displays
- Presents a topmost Form on each display showing effect
- Polls the mouse to see when it moves (upon which code exits)

All code is in [Program.cs](./MatrixScreensaver/Program.cs)

The actual matrix effect (all the hard work!) was done by [rezmason](https://github.com/rezmason), see: https://github.com/rezmason/matrix

![image](https://github.com/user-attachments/assets/5db5981f-7205-42d1-afb7-0b3946d53e48)

## How to use

Checkout the code from GitHub using the above green `<> Code ⌄` button on the website or using `git clone` from command line.

Building requires the [dotnet sdk](https://dotnet.microsoft.com/en-us/download) (net 9.0).

After installing the SDK open a Terminal and navigate to the folder you checked out the code in and run:

```
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -o publish
```

This will create a file called `MatrixScreensaver.exe` rename `.exe` to `.scr`

In File Explorer, right click the .scr file and choose 'Install'
