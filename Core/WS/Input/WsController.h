#pragma once
#include "pch.h"
#include "WS/WsConsole.h"
#include "Shared/BaseControlDevice.h"
#include "Shared/Emulator.h"
#include "Shared/InputHud.h"

class WsController : public BaseControlDevice
{
private:
	WsConsole* _console = nullptr;
	vector<KeyMapping> _verticalMappings;
	uint32_t _horizontalTurboSpeed = 0;
	uint32_t _verticalTurboSpeed = 0;

protected:
	string GetKeyNames() override
	{
		return "UDLRudlrSsBA";
	}

	void InternalSetStateFromInput() override
	{
		bool isVerticalMode = _console->IsVerticalMode();
		vector<KeyMapping>& keyMappings = isVerticalMode ? _verticalMappings : _keyMappings;
		uint32_t turboSpeed = isVerticalMode ? _verticalTurboSpeed : _horizontalTurboSpeed;
		bool turboOn = IsTurboOn(turboSpeed);

		for(KeyMapping& keyMapping : keyMappings) {
			SetPressedState(Buttons::A, keyMapping.A);
			SetPressedState(Buttons::B, keyMapping.B);
			SetPressedState(Buttons::Sound, keyMapping.GenericKey1);
			SetPressedState(Buttons::Start, keyMapping.Start);
			SetPressedState(Buttons::Up, keyMapping.Up);
			SetPressedState(Buttons::Down, keyMapping.Down);
			SetPressedState(Buttons::Left, keyMapping.Left);
			SetPressedState(Buttons::Right, keyMapping.Right);

			SetPressedState(Buttons::Up2, keyMapping.U);
			SetPressedState(Buttons::Down2, keyMapping.D);
			SetPressedState(Buttons::Left2, keyMapping.L);
			SetPressedState(Buttons::Right2, keyMapping.R);

			if(turboOn) {
				SetPressedState(Buttons::A, keyMapping.TurboA);
				SetPressedState(Buttons::B, keyMapping.TurboB);
			}
		}
	}

	void RefreshStateBuffer() override
	{
	}

public:
	enum Buttons
	{
		Up = 0,
		Down,
		Left,
		Right,
		Up2,
		Down2,
		Left2,
		Right2,
		Sound,
		Start,
		B,
		A
	};

	WsController(Emulator* emu, WsConsole* console, uint8_t port, KeyMappingSet horizontalMappings, KeyMappingSet verticalMappings) : BaseControlDevice(emu, ControllerType::WsController, port, horizontalMappings)
	{
		_verticalMappings = verticalMappings.GetKeyMappingArray();
		_console = console;
		_horizontalTurboSpeed = horizontalMappings.TurboSpeed;
		_verticalTurboSpeed = verticalMappings.TurboSpeed;
	}

	uint8_t ReadRam(uint16_t addr) override
	{
		return 0;
	}

	void WriteRam(uint16_t addr, uint8_t value) override
	{
	}

	void InternalDrawController(InputHud& hud) override
	{
		if(_console->IsVerticalMode()) {
			hud.DrawOutline(28, 35);

			hud.DrawButton(20, 24, 3, 3, IsPressed(Buttons::Right));
			hud.DrawButton(20, 30, 3, 3, IsPressed(Buttons::Left));
			hud.DrawButton(17, 27, 3, 3, IsPressed(Buttons::Up));
			hud.DrawButton(23, 27, 3, 3, IsPressed(Buttons::Down));

			hud.DrawButton(5, 24, 3, 3, IsPressed(Buttons::Right2));
			hud.DrawButton(5, 30, 3, 3, IsPressed(Buttons::Left2));
			hud.DrawButton(2, 27, 3, 3, IsPressed(Buttons::Up2));
			hud.DrawButton(8, 27, 3, 3, IsPressed(Buttons::Down2));

			hud.DrawButton(21, 9, 5, 3, IsPressed(Buttons::B));
			hud.DrawButton(22, 8, 3, 5, IsPressed(Buttons::B));
			hud.DrawButton(18, 3, 5, 3, IsPressed(Buttons::A));
			hud.DrawButton(19, 2, 3, 5, IsPressed(Buttons::A));

			hud.DrawButton(21, 15, 2, 3, IsPressed(Buttons::Start));
			hud.DrawButton(21, 19, 2, 3, IsPressed(Buttons::Sound));

			hud.DrawNumber(_port + 1, 13, 2);
		} else {
			hud.DrawOutline(37, 24);

			hud.DrawButton(5, 2, 3, 3, IsPressed(Buttons::Up2));
			hud.DrawButton(5, 8, 3, 3, IsPressed(Buttons::Down2));
			hud.DrawButton(2, 5, 3, 3, IsPressed(Buttons::Left2));
			hud.DrawButton(8, 5, 3, 3, IsPressed(Buttons::Right2));

			hud.DrawButton(5, 13, 3, 3, IsPressed(Buttons::Up));
			hud.DrawButton(5, 19, 3, 3, IsPressed(Buttons::Down));
			hud.DrawButton(2, 16, 3, 3, IsPressed(Buttons::Left));
			hud.DrawButton(8, 16, 3, 3, IsPressed(Buttons::Right));

			hud.DrawButton(30, 15, 5, 3, IsPressed(Buttons::A));
			hud.DrawButton(31, 14, 3, 5, IsPressed(Buttons::A));
			hud.DrawButton(24, 18, 5, 3, IsPressed(Buttons::B));
			hud.DrawButton(25, 17, 3, 5, IsPressed(Buttons::B));

			hud.DrawButton(13, 17, 4, 2, IsPressed(Buttons::Sound));
			hud.DrawButton(18, 17, 4, 2, IsPressed(Buttons::Start));

			hud.DrawNumber(_port + 1, 16, 2);
		}
	}

	vector<DeviceButtonName> GetKeyNameAssociations() override
	{
		return {
			{ "a", Buttons::A },
			{ "b", Buttons::B },
			{ "sound", Buttons::Sound },
			{ "start", Buttons::Start },
			{ "up", Buttons::Up },
			{ "down", Buttons::Down },
			{ "left", Buttons::Left },
			{ "right", Buttons::Right },
			{ "up2", Buttons::Up2 },
			{ "down2", Buttons::Down2 },
			{ "left2", Buttons::Left2 },
			{ "right2", Buttons::Right2 },
		};
	}
};