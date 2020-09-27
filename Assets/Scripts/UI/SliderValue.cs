using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Triadium.UI
{
    public class SliderValue : MonoBehaviour
    {

        public GameObject target;
        public GameObject units;

        public GameObject unitsLabel { get { return units; } }

        private Slider _slider;
        private Text _text;

        // Use this for initialization
        void Awake()
        {
            _slider = GetComponent<Slider>();
            _text = target.GetComponent<Text>();
            OnValueChanged(_slider.value);
        }

        void OnEnable()
        {
            _slider.onValueChanged.AddListener(OnValueChanged);
        }

        void OnDisable()
        {
            _slider.onValueChanged.RemoveListener(OnValueChanged);
        }

        void OnValueChanged(float v)
        {
            _text.text = v.ToString();
        }
    }
}
