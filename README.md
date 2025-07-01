# DigitalRainScreensaver

Simple screensaver that outputs different colored digital rain effects on each monitor connected until you move mouse.

All complicated work done in: https://github.com/rezmason/matrix (where html canvas are loaded from)

## How to use

Publish with the application:
```
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -o publish
```

Rename `.exe` to `.scr`

Right click the .scr file and choose 'Install'
