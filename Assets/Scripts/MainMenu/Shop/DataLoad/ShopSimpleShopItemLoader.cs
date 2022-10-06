using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSimpleShopItemLoader : MonoBehaviour
{
    public string path = "file.txt";
    protected SimpleItem[] _items;
    protected List<SimpleItem> _loadedItems;
    DataLoader _loader = new DataLoader();

    public void Load()
    {
        _items = ScriptableObject.FindObjectsOfType<SimpleItem>();
        _loadedItems = new List<SimpleItem>();
        _loader.LoadData(path);

        // Сортируем данные  собираем всю информацию
        for (int i = 0; i < _loader.data.Count; i += 2)
        {
            SimpleItem item = new SimpleItem();
            item.SetName(_loader.data[i]);
            item.SetSold(_loader.data[i + 1] == "true" ? true : false);
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
                    _loadedItems.RemoveAt(j);
                }
            }
        }
    }
    public void Save()
    {
        _loader.data = new List<string>();
        _items = ScriptableObject.FindObjectsOfType<SimpleItem>();

        foreach (SimpleItem item in _items)
        {
            _loader.data.Add(item.GetName());
            _loader.data.Add((item.GetSold() == true ? "true" : "false"));
        }

        _loader.SaveData(path);
    }
}
