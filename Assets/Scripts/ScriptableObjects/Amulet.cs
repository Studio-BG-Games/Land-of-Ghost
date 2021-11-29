using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Amulet", menuName = "Items/new Amulet", order = 51)]
public class Amulet : Items
{
    public override void Use()
    {
        Debug.Log($"using Amulet {Name}");
    }
}
