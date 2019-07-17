using UnityEngine;

namespace Geekbrains
{
	public class FlashLightController : BaseController, IOnUpdate, IInitialization
	{
		private FlashLightModel _flashLight;
		
		public void OnUpdate()
		{
			if (!IsActive) return;
			
			if (_flashLight.EditBatteryCharge())
			{
				UiInterface.LightUiText.Text = _flashLight.BatteryChargeCurrent;
				UiInterface.FlashLightUiBar.Fill = _flashLight.Charge;
				_flashLight.Rotation();

				if (_flashLight.BatteryChargeCurrent <= _flashLight.BatteryChargeMax/2)
				{
					UiInterface.FlashLightUiBar.SetColor(Color.red);
				}
			}
			else
			{
				Off();
			}
		}

		public void OnStart()
		{
			_flashLight = Main.Instance.Inventory.FlashLight;
			UiInterface.LightUiText.SetActive(false);
			UiInterface.FlashLightUiBar.SetActive(false);
		}

		public override void On()
		{
			if (IsActive)return;
			if (_flashLight.BatteryChargeCurrent <= 0) return;
			base.On();
			_flashLight.Switch(true);
			UiInterface.LightUiText.SetActive(true);
			UiInterface.FlashLightUiBar.SetActive(true);
			UiInterface.FlashLightUiBar.SetColor(Color.green);
		}

		public sealed override void Off()
		{
			if (!IsActive) return;
			base.Off();
			_flashLight.Switch(false);
			UiInterface.LightUiText.SetActive(false);
			UiInterface.FlashLightUiBar.SetActive(false);
		}
	}
}