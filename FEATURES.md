Compare to Mesen2 and MesenCE, MesenYY has following features:

- Louder master volume (minus SNES and SMS), similar to other emulator (e.g. NES to FCEUX, GB/GBC to SameBoy, GBA to mGBA).
- Separately store battery save by console, all consoles' save store together is a mess.
- Creating auto savestate also updates battery save, before this it only updates on close/reload, easily lose when accident happens.
- Added 11x and 12x window size, suitable for GB, GBA, and WS on 4K monitor.
- Added 100% speed shortcut key, just like FCEUX and BizHawk.
- Removed some symbols' former blank of HUD font, now "22:33" looks more comfortable.
- Tweaked audio player HUD after modified HUD font, and 10 minutes won't display to right side anymore.
- More Prescale factors, but removed Prescale 10x.
- Bilinear interpolation now also has override option.
- Faster turbo speed of controller, now it has 12, 15, 20, 30 (highest doesn't change though).
- NES: Replaced default YUV palette to [Five Reality](https://forums.nesdev.org/viewtopic.php?p=293025#p293025), it has similar brightness, but more saturated, and more matches NTSC NES, just compare darker cyan and brighter colors' hue change.
- NES: Replaced palette presets, tweaked these NTSC NES palettes ($09).
- NES: Added _Use linear square channel mixer_ option, just like NintendulatorNRS.
- NES: Added _Not reset square channels phase_ option, mimics some Famiclones which not swap duty cycles.
- SNES: Added _Allow invalid VRAM access_ option, just like Snes9x.
- Gameboy: Replaced default palette and presets.
- Gameboy: Made a short tone silent of GBC's bootROM, caused a side effect though, currently only found _King James Bible_ had be affected.
- Gameboy: Renamed .srm to .sav, for tranfer to other Gameboy emulator conveniently.
- Gameboy: If MBC3 didn't use RTC (e.g. Pokemon Red), it won't create .rtc anymore.
- Gameboy: Let MBC3's RTC running at realtime speed, it won't be affacted by pause or speed up/down anymore.
- GBA: Let RTC reads system datetime when create/reset RTC.
- Changed some default settings, may made experience better.

These features are why I created this fork, Mesen2 is a nice emulator, but has some pain points, so I improved them. If you also think these changes useful, have an enjoy ^_^