using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    [Header("Item Name")]
    [SerializeField] protected string itemName = string.Empty;

    [Header("Price Settings")]
    [SerializeField] protected int _price;
    [SerializeField] protected Text _priceText;
    [SerializeField] protected string _goldPrefName;
    [SerializeField] protected string _textAfterPurchase; 

    [Header("Purchase Settings")]
    [SerializeField] protected bool _isSold;

    protected void Start()
    {
        _priceText.text = _price.ToString();

        if (_isSold)
        {
            _priceText.text = _textAfterPurchase;
        }

        if (!PlayerPrefs.HasKey(_goldPrefName))
        {
            PlayerPrefs.SetInt(_goldPrefName, 0);
        }
    }

    protected void StartAction()
    {
        ShopAction action = GetComponent<ShopAction>();
        if (action != null)
        {
            action.StartAction();
        }
    }

    public int getPrice()
    {
        return _price;
    }

    public bool GetSold()
    {
        return _isSold;
    }

    public void SetSold(bool value)
    {
        _isSold = value;
    }

    public string GetName()
    {
        return itemName;
    }

    public void SetName(string value)
    {
        itemName = value;
    }
}