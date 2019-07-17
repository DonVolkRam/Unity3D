using UnityEngine;

namespace Geekbrains
{
	public class InputController : BaseController, IOnUpdate
	{
		private KeyCode _activeFlashLight = KeyCode.F;
		public void OnUpdate()
		{
			if (!IsActive) return;
			if (Input.GetKeyDown(_activeFlashLight))
			{
				Main.Instance.FlashLightController.Switch();
			}
		}
	}
}