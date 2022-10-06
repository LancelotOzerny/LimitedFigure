using UnityEngine;
using UnityEngine.UI;

public class PrefLoader : MonoBehaviour
{

    [SerializeField] private string prefName;
    [SerializeField] CounterController.CounterType type;

    [SerializeField] private string textBefore;
    [SerializeField] private string textAfter;

    private Text text;

    private void Start()
    {
        text = GetComponent<Text>();

        Realod();
    }

    private void CheckPlayerPref()
    {
        if (!PlayerPrefs.HasKey(prefName))
        {
            PlayerPrefs.SetInt(prefName, 0);
        }
    }

    private void SetText()
    {
        if (type == CounterController.CounterType.counter)
        {
            text.text = textBefore + PlayerPrefs.GetInt(prefName).ToString() + textAfter;
        }

        if (type == CounterController.CounterType.timer)
        {
            text.text = textBefore + Timer.GetStringTime(PlayerPrefs.GetInt(prefName)) + textAfter;
        }
    }

    public void Realod()
    {
        CheckPlayerPref();
        SetText();
    }
}
