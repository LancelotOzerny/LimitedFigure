using UnityEngine;

public class ShopAction : MonoBehaviour
{
    public enum Action { Set, Add };
    [SerializeField] protected Action _action;
    [SerializeField] protected string _prefName;
    [SerializeField] protected int _value;

    private void Start()
    {
        if (!PlayerPrefs.HasKey(_prefName))
        {
            PlayerPrefs.SetInt(_prefName, 0);
        }
    }

    public void StartAction() 
    {
        if (_action == Action.Set)
        {
            if (PlayerPrefs.GetInt(_prefName) < _value)
            {
                PlayerPrefs.SetInt(_prefName, _value);
            }
        }

        if (_action == Action.Add)
        {
            PlayerPrefs.SetInt(_prefName, PlayerPrefs.GetInt(_prefName) + _value);
        }

        Debug.Log(PlayerPrefs.GetInt(_prefName));
    }
}
