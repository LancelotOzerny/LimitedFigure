using UnityEngine;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour
{
    public enum ChangerType { image, sprite, text, camera }
    [SerializeField] protected Color _color;
    [SerializeField] protected string _prefName = "ColorLevel";
    [SerializeField] protected int _prefValue;
    [SerializeField] protected ChangerType _type;

    void Start()
    {
        if (!PlayerPrefs.HasKey(_prefName))
        {
            PlayerPrefs.SetInt(_prefName, 0);
        }
        ChangeColor();
    }

    public void ChangeColor()
    {
        if (PlayerPrefs.GetInt(_prefName) >= _prefValue)
        {
            if (_type == ChangerType.image)
            {
                GetComponent<Image>().color = _color;
            }

            if (_type == ChangerType.sprite)
            {
                GetComponent<SpriteRenderer>().color = _color;
            }

            if (_type == ChangerType.text)
            {
                GetComponent<Text>().color = _color;
            }

            if (_type == ChangerType.camera)
            {
                GetComponent<Camera>().backgroundColor = _color;
            }
        }
    }
}
