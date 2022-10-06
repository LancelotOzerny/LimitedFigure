using UnityEngine;
using UnityEngine.UI;

public class Timer
{
    private int seconds;
    private int minutes;
    private int hourses;

    public void AddSeconds(int value)
    {
        if (value < 0)
            return;

        seconds += value;

        minutes += seconds / 60;
        seconds = seconds % 60;

        hourses = minutes / 60;
        minutes = minutes % 60;
    }

    public static string GetStringTime(int value)
    {
        Timer timer = new Timer();
        timer.AddSeconds(value);

        string time = string.Empty;

        if (timer.seconds < 10)
        {
            time = "0" + timer.seconds.ToString();
        }
        else
        {
            time = timer.seconds.ToString();
        }

        if (timer.minutes < 10)
        {
            time = "0" + timer.minutes.ToString() + ":" + time;
        }
        else
        {
            time = timer.minutes.ToString() + ":" + time;
        }

        if (timer.hourses > 0)
        {
            if (timer.hourses < 10)
            {
                time = "0" + timer.hourses.ToString() + ":" + time;
            }
            else
            {
                time = timer.hourses.ToString() + ":" + time;
            }
        }

        return time;
    }

    public int GetIntTime()
    {
        return seconds + minutes * 60 + hourses * 3600;
    }
};

public class CounterController : MonoBehaviour
{
    public enum CounterActions { Replace, Add };
    public enum CounterType { counter, timer };

    [SerializeField] private int count;

    [SerializeField] private Timer timer = new Timer();
    private float second = 1.0f;

    [Header("Counter Settings")]
    [SerializeField] private CounterType type;

    [Header("Prefab Settings")]
    [SerializeField] private string prefabName;
    [SerializeField] private CounterActions action;

    [Header("Text Settings")]
    [SerializeField] private string textBefore;
    [SerializeField] private string textAfter;

    private Text text;

    void Start()
    {
        count = 0;
        text = GetComponent<Text>();
    
        if (!PlayerPrefs.HasKey(prefabName))
        {
            PlayerPrefs.SetInt(prefabName, 0);
        }
    }

    private void Update()
    {
        if (type == CounterType.timer)
        {
            second -= Time.deltaTime;

            if (second <= 0)
            {
                timer.AddSeconds(1);
                second = 1.0f;
                SetText();
            }
        }
    }

    public void Add(int value)
    {
        if (value > 0)
        {
            if (type == CounterType.counter)
            {
                count += value;
                SetText();
            }

            if (type == CounterType.timer)
            {
                timer.AddSeconds(value);
            }
        }

        CheckPref();
    }

    public void Sub(int value)
    {
        if (value > 0)
        {
            if (count - value < 0)
            {
                count = 0;
            }
            else
            {
                count -= value;
            }
            SetText();
        }

        CheckPref();
    }

    private void SetText()
    {
        if (type == CounterType.counter)
        {
            text.text = textBefore + count.ToString() + textAfter;
        }

        if (type == CounterType.timer)
        {
            text.text = textBefore + Timer.GetStringTime(timer.GetIntTime()) + textAfter;
        }
    }

    private void CheckPref()
    {
        if (type == CounterType.timer)
        {
            count = timer.GetIntTime();
        }

        if (action == CounterActions.Replace)
        {
            if (count > PlayerPrefs.GetInt(prefabName))
            {
                PlayerPrefs.SetInt(prefabName, count);
            }
        }

        if (action == CounterActions.Add)
        {
            PlayerPrefs.SetInt(prefabName, PlayerPrefs.GetInt(prefabName) + count);
        }
        
    }
}
