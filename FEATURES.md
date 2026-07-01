Compare to Mesen2 and MesenCE, MesenYY has following features:

- Louder master volume (minus SNES and SMS), similar to other emulator (e.g. NES to FCEUX, GB/GBC to SameBoy, GBA to mGBA)
- Separately store battery save by console, all consoles' save store together is a mess.
- Enable auto savestate also updates battery save, made battery save safer
- Added 11x and 12x window size, suitable for GB, GBA, and WS on 4K monitor (for someone prefers windowed mode)
- Added 100% speed shortcut key, same as FCEUX and BizHawk
- Removed some symbols' former blank of HUD font, now "22:33" and "22.33" looks more comfortable
- Tweaked audio player HUD after modified HUD font, and 10 minutes won't display to right side anymore
- More Prescale factors, but removed Prescale 10x
- Bilinear interpolation now also has override option
- Faster turbo speed of controller, now it has 12, 15, 20, 30 (highest still same though)
- Window size could be kept (e.g. NES 7x switch to SNES won't change to 8x)
- HUD size could be changed in setting
- NES: Replaced default YUV palette to [Five Reality](https://forums.nesdev.org/viewtopic.php?p=293025#p293025), it has similar brightness, but more saturated, and matches NTSC NES, just compare darker cyan and brighter colors' hue change
- NES: Replaced palette presets, tweaked these NTSC NES palettes ($09)
- NES: Added _Use linear square channel mixer_ option, same as NintendulatorNRS
- NES: Added _Not reset square channels phase_ option, mimics some Famiclones which not swap duty cycles
- NES: Tweaked non-linear square channel mixer, slightly closer to Famicom
- SNES: Added _Allow invalid VRAM access_ option, same as Snes9x
- Gameboy: Replaced default palette and presets
- Gameboy: Made a short tone silent of GBC's bootROM, caused a side effect though, currently only found _King James Bible_ had be affected
- Gameboy: Renamed .srm to .sav, for tranfer to other Gameboy emulator conveniently
- Gameboy: If MBC3 didn't use RTC (e.g. Pokemon Red), it won't create .rtc anymore
- Gameboy: Let MBC3's RTC running at realtime speed, it won't be affacted by pause or speed up/down anymore
- GBA: Let RTC reads system datetime when create/reset RTC
- Changed some default settings, may made experience better

After Mesen2 was silent a long time after 2025-07-15 dev build, I decided making a fork, and this is.
Mesen2 is a nice emulator, but it has some pain points, so I improved them.
If you also think these changes are useful, have an enjoy ^_^