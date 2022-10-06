using UnityEngine;
using UnityEngine.UI;

public class SpriteChanger : MonoBehaviour
{
    public enum ChangerType { sprite, image }
    [SerializeField] protected Sprite _sprite;
    [SerializeField] protected string _prefName = "ColorLevel";
    [SerializeField] protected int _prefValue;
    [SerializeField] protected ChangerType _type;

    void Start()
    {
        if (!PlayerPrefs.HasKey(_prefName))
        {
            PlayerPrefs.SetInt(_prefName, 0);
        }
        ChangeSprite();
    }

    public void ChangeSprite()
    {
        if (PlayerPrefs.GetInt(_prefName) >= _prefValue)
        {
            if (_type == ChangerType.image)
            {
                GetComponent<Image>().sprite = _sprite;
            }

            if (_type == ChangerType.sprite)
            {
                GetComponent<SpriteRenderer>().sprite = _sprite;
            }
        }
    }
}
