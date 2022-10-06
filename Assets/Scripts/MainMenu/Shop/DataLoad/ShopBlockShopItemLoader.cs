using System.Collections.Generic;
using UnityEngine;

public class ShopBlockShopItemLoader : MonoBehaviour
{
    public string path = "file.txt";
    protected BlockShopItem[] _items;
    protected List<BlockShopItem> _loadedItems;
    DataLoader _loader = new DataLoader();

    public void Load()
    {
        _items = ScriptableObject.FindObjectsOfType<BlockShopItem>();
        _loadedItems = new List<BlockShopItem>();
        _loader.LoadData(path);

        // Сортируем данные  собираем всю информацию
        for (int i = 0; i < _loader.data.Count; i += 3)
        {
            BlockShopItem item = new BlockShopItem();
            item.SetName(_loader.data[i]);
            item.SetSold(_loader.data[i + 1] == "true" ? true : false);
            item.SetBlock(_loader.data[i + 2] == "true" ? true : false);
            _loadedItems.Add(item);
        }

        // распределяем данные по предметам
        for (int i = 0; i < _items.Length; i++)
        {
            if (_loadedItems.Count <= 0)
            {
                break;
            }   
            
            for (int j = _loadedItems.Count - 1; j >= 0; j--)
            {
                if (_items[i].GetName() == _loadedItems[j].GetName())
                {
                    _items[i].SetSold(_loadedItems[j].GetSold());
                    _items[i].SetBlock(_loadedItems[j].GetBlock());
                    _loadedItems.RemoveAt(j);
                }
            }
        }
    }
    public void Save()
    {
        _loader.data = new List<string>();
        _items = ScriptableObject.FindObjectsOfType<BlockShopItem>();

        foreach (BlockShopItem item in _items)
        {
            _loader.data.Add(item.GetName());
            _loader.data.Add((item.GetSold() == true ? "true" : "false"));
            _loader.data.Add((item.GetBlock() == true ? "true" : "false"));
        }

        _loader.SaveData(path);
    }
}
