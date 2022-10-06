using UnityEngine;

public class SimpleItem : ShopItem
{
    public void Buy()
    {
        int gold = PlayerPrefs.GetInt(_goldPrefName);
        if ((!_isSold) & (gold >= _price))
        {
            PlayerPrefs.SetInt(_goldPrefName, gold - _price);
            _isSold = true;
            _priceText.text = _textAfterPurchase;
            StartAction();
        }
    }
}
