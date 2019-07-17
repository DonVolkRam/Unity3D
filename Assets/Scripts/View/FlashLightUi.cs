using UnityEngine;
using UnityEngine.UI;

namespace Geekbrains
{
    public class FlashLightUi : MonoBehaviour
    {
	    private Text _text;
        [SerializeField] private Image _image;

        private void Awake()
	    {
		    _text = GetComponent<Text>();
            //_image = GetComponent<Image>();
	    }

	    public float Text
	    {
		    set => _text.text = $"{value:0.0}";
	    }
        public float ChargeFill
        {
            set => _image.fillAmount = value;
        }

        public void SetActive(bool value)
	    {
		    _text.gameObject.SetActive(value);
	    }
    }
}
