using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Items : ScriptableObject
{ 
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;
    [SerializeField] private int _id;
    [SerializeField] private string _descroption;
    [SerializeField] private int _moneyPrice;
    [SerializeField] private Items _itemPrice;
    [SerializeField] private ItemsView _view;
    public string Name { get => _name; protected set => _name = value; }
    public Sprite Icon { get => _icon; protected set => _icon = value; }
    public int Id { get => _id; set => _id = value; }
    public string Description { get => _descroption; protected set => _descroption = value; }
    public int MoneyPrice { get => _moneyPrice; protected set => _moneyPrice = value; }
    public Items ItemPrice { get => _itemPrice; protected set => _itemPrice = value; }
    public ItemsView View { get => _view; private set => _view = value; }

}
