using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] private string soundPrefName = "slider_SoundsOption";
    private AudioSource _audio;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        _audio.Stop();

        if (!PlayerPrefs.HasKey(soundPrefName))
        {
            PlayerPrefs.SetFloat(soundPrefName, 0.5f);
        }
    }

    public void Play()
    {
        _audio.volume = PlayerPrefs.GetFloat(soundPrefName);
        _audio.Play();
    }
}
