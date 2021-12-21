using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventorySO : ScriptableObject
{
    [SerializeField] private List<Items> _allItems;
    [SerializeField] private List<Items> _items;
    [SerializeField] private Amulet[] _amuletsInSlot;
    [SerializeField] private Potion[] _potionsInSlot;
    [SerializeField] private int _money;

    public Amulet[] AmuletsInSlot { get => _amuletsInSlot; private set => _amuletsInSlot = value; }
    public Potion[] PotionsInSlot { get => _potionsInSlot; private set => _potionsInSlot = value; }
    public List<Items> AllItems { get => _allItems; private set => _allItems = value; }
    public int Money { get => _money; private set => _money = value; }
    public Action OnMoneyChange;
    public List<Amulet> GetAmulets()
    {
        return _items.Where(item => item as Amulet).Select(item => item as Amulet).ToList();
    }
    public Dictionary<Potion, int> GetPotions()
    {
        var potions = _items.Where(item => item as Potion).Select(item => item as Potion).ToList();
        Dictionary<Potion, int> potionsCountMap = new Dictionary<Potion, int>();
        foreach (var potion in potions)
        {
            if (!potionsCountMap.ContainsKey(potion))
                potionsCountMap.Add(potion, potions.Where(p => p == potion).Count());
        }
        return potionsCountMap;
    }
    public Dictionary<Common, int> GetCommons()
    {
        var commons = _items.Where(item => item as Common).Select(item => item as Common).ToList();
        Dictionary<Common, int> commonsCountMap = new Dictionary<Common, int>();
        foreach (var common in commons)
        {
            if (!commonsCountMap.ContainsKey(common))
                commonsCountMap.Add(common, commons.Where(p => p == common).Count());
        }
        return commonsCountMap;
    }
    public Dictionary<Potion, int> GetPotionsNotInSlot()
    {
        var potions = GetPotions();
        Dictionary<Potion, int> potionsNotInSlot = new Dictionary<Potion, int>();
        foreach (var potion in potions)
        {
            if (!_potionsInSlot.Contains(potion.Key))
                potionsNotInSlot.Add(potion.Key, potion.Value);
        }
        return potionsNotInSlot;
    }
    public void AddItem(Items item)
    {
        _items.Add(item);
    }
    public void RemoveItem(Items item)
    {
        _items.Remove(item);
    }
    public void RemoveItem(int itemId)
    {
        var items = _items.Where(i => i.Id == itemId);
        var item = items.FirstOrDefault();
        _items.Remove(item);
        if (item as Potion && items.Count() == 1)
            for (int i = 0; i < _potionsInSlot.Length; i++)
                if (_potionsInSlot[i] != null && _potionsInSlot[i].Id == itemId) _potionsInSlot[i] = null;
    }
    public void PutAmuletInSlot(int id, Amulet amulet, Amulet amuletInSlot)
    {
        if (amulet == amuletInSlot || amulet.Id == 0)
            amulet = null;
        _amuletsInSlot[id] = amulet;
        RemoveItem(amulet);
        if (amuletInSlot != null) AddItem(amuletInSlot);
    }
    public void PutPotionInSlot(int id, Potion potion, Potion potionInSlot)
    {
        if (potion == potionInSlot || potion.Id == 0)
            potion = null;
        _potionsInSlot[id] = potion;
    }
    public void AddMoney(int amount)
    {
        _money += amount;
        OnMoneyChange?.Invoke();
    }
    public void RemoveMoney(int amount)
    {
        _money -= amount;
        OnMoneyChange?.Invoke();
    }
    public bool HaveItem(Items item)
    {
        if (_items.Contains(item)) return true;
        return false;
    }

}