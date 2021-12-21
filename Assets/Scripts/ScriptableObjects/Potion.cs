using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bottle", menuName = "Items/new Potion", order = 51)]
public class Potion : Items
{
    private void Drink()
    {
        Debug.Log($"using Potion {Name}");
    }

    public override void Use()
    {
        base.Use();
        Drink();
    }
}
