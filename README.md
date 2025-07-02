# DigitalRainScreensaver

Simple screensaver that outputs different colored digital rain effects on each monitor connected until you move mouse.

All complicated work done in: https://github.com/rezmason/matrix (where html canvas are loaded from)

![image](https://github.com/user-attachments/assets/5db5981f-7205-42d1-afb7-0b3946d53e48)

## How to use

Building requires the [dotnet sdk](https://dotnet.microsoft.com/en-us/download).

After installing the SDK open a Terminal and navigate to the folder you checked out the code in and run:

```
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -o publish
```

This will create a file called `MatrixScreensaver.exe` rename `.exe` to `.scr`

In File Explorer, right click the .scr file and choose 'Install'
