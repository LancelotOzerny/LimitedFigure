using UnityEngine;

public class UnBlockingShopItem : MonoBehaviour
{
    private ShopItem _shopItem;

    private void Start()
    {
        _shopItem = GetComponent<ShopItem>(); 
    }
    
    public void UnBlock(BlockShopItem item)
    {
        if (
            _shopItem.GetSold())
        {
            item.SetBlock(false);
        }
    }
}
