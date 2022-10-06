using UnityEngine;
using UnityEngine.UI;

public class BlockShopItem : ShopItem
{
    [Header("Blocking")]
    [SerializeField] protected bool _isBlocked;
    [SerializeField] protected Image _blockImage;


    new void Start()
    {
        base.Start();
        SetBlock(_isBlocked);
    }

    /// <summary>
    /// Метод, который позволяет купить предмет из магазина
    /// </summary>
    public void Buy()
    {
        int gold = PlayerPrefs.GetInt(_goldPrefName);
        if ((!_isBlocked) & (!_isSold) & (gold >= _price))
        {
            PlayerPrefs.SetInt(_goldPrefName, gold - _price);
            _isSold = true;
            _priceText.text = _textAfterPurchase;
            StartAction();
        }
    }

    /// <summary>
    /// Метод, который позволяет изменить значение блокировки покупки предмета
    /// </summary>
    /// <param name="value"></param>
    public void SetBlock(bool value)
    {
        _isBlocked = value;

        if (_blockImage != null)
        {
            _blockImage.gameObject.SetActive(_isBlocked);
        }
    }
    
    /// <summary>
    /// Метод, который позволяет получить значение блокировки
    /// </summary>
    /// <returns>текущее значение блокировки</returns>
    public bool GetBlock()
    {
        return _isBlocked;
    }
}
