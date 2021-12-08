using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "InventorySO", menuName = "SO/InventorySO")]
public class InventorySO : ScriptableObject
{
    [SerializeField] private List<Items> _items;
    [SerializeField] private Amulet[] _amuletsInSlot;
    [SerializeField] private Potion[] _potionsInSlot;

    public Amulet[] AmuletsInSlot { get => _amuletsInSlot; private set => _amuletsInSlot = value; }
    public Potion[] PotionsInSlot { get => _potionsInSlot; private set => _potionsInSlot = value; }

    public List<Amulet> GetAmulets()
    {
        return _items.Where(item => item as Amulet).Select(item => item as Amulet).ToList();
    }
    public List<Potion> GetPotions()
    {
        return _items.Where(item => item as Potion).Select(item => item as Potion).ToList();
    }
    public void AddItem(Items item)
    {
        _items.Add(item);
    }
    public void RemoveItem(Items item)
    {
        _items.Remove(item);
    }
    public void PutAmuletInSlot(int id, Amulet amulet)
    {
        _amuletsInSlot[id] = amulet;
        _items.Remove(amulet);
    }
    public void PutPotionInSlot(int id, Potion potion)
    {
        _potionsInSlot[id] = potion;
        _items.Remove(potion);
    }
}
 