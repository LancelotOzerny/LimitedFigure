using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    [SerializeField] private string _sliderName;
    private Slider _slider;

    private void Start()
    {
        _slider = GetComponent<Slider>();
    
        if (!PlayerPrefs.HasKey(_sliderName))
        {
            PlayerPrefs.SetFloat(_sliderName, _slider.value);
        }

        _slider.value = PlayerPrefs.GetFloat(_sliderName);
    }

    public void ChangeValue()
    {
        PlayerPrefs.SetFloat(_sliderName, _slider.value);
    }
}
