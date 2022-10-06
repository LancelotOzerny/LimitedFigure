using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    [SerializeField] private string prefName;
    private AudioSource _audio;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();

        SetPrefValue();
    }

    public void SetValue(Slider scroll)
    {
        _audio.volume = scroll.value;
    }

    public void SetPrefValue()
    {
        if (PlayerPrefs.HasKey(prefName))
        {
            _audio.volume = PlayerPrefs.GetFloat(prefName) / 2;
        }
    }
}
