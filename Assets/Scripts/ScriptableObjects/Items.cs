using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Items : ScriptableObject
{ 
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;
    [SerializeField] private int _id;
    [SerializeField] private string _descroption;

    public string Name { get => _name; protected set => _name = value; }
    public Sprite Icon { get => _icon; protected set => _icon = value; }
    public int Id { get => _id; protected set => _id = value; }
    public string Description { get => _descroption; protected set => _descroption = value; }
    public virtual void Use()
    {
        Debug.Log($"using Item {Name}");
    }
}
