#pragma once

#include "pch.h"
#include "Shared/Video/BaseVideoFilter.h"
#include "Shared/SettingTypes.h"

class SnesDefaultVideoFilter : public BaseVideoFilter
{
private:
	uint32_t _calculatedPalette[0x8000] = {};
	VideoConfig _videoConfig = {};
	SnesConfig _snesConfig = {};

	static constexpr uint8_t gammaRamp[32] = {
		0x00, 0x01, 0x03, 0x06, 0x0a, 0x0f, 0x15, 0x1c,
		0x24, 0x2d, 0x37, 0x42, 0x4e, 0x5b, 0x69, 0x78,
		0x88, 0x90, 0x98, 0xa0, 0xa8, 0xb0, 0xb8, 0xc0,
		0xc8, 0xd0, 0xd8, 0xe0, 0xe8, 0xf0, 0xf8, 0xff,
	};

	SnesHighResBlendMode _highResBlendMode = SnesHighResBlendMode::None;
	bool _forceFixedRes = false;

	void InitLookupTable();

	__forceinline static uint32_t BlendPixels(uint32_t a, uint32_t b);
	__forceinline uint32_t GetPixel(uint16_t* ppuFrame, uint32_t offset);

	void ApplyBlend(FrameInfo frameInfo, uint32_t* out);

protected:
	void OnBeforeApplyFilter() override;
	FrameInfo GetFrameInfo() override;

public:
	SnesDefaultVideoFilter(Emulator* emu);

	void ApplyFilter(uint16_t* ppuOutputBuffer) override;
	OverscanDimensions GetOverscan() override;
};