using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Items : ScriptableObject
{ 
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;

    public string Name { get => _name; protected set => _name = value; }
    public Sprite Icon { get => _icon; protected set => _icon = value; }
    public virtual void Use()
    {
        Debug.Log($"using Item {Name}");
    }
}
