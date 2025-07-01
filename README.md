# DigitalRainScreensaver

Simple screensaver that outputs different colored digital rain effects on each monitor connected until you move mouse.

All complicated work done in: https://github.com/rezmason/matrix (where html canvas are loaded from)

## How to use

Build and publish with the .scr extension:

```
dotnet publish -c Release -r win-x64 --self-contained true -o publish && ren publish\MatrixScreensaver.exe MatrixScreensaver.scr
```

Copy to `%WINDIR%\System32` (requires admin)
