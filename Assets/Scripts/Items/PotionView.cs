using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PotionView : ItemsView<Potion>
{
    [SerializeField] private TextMeshProUGUI _amountText;
    public override void Init(Potion item, int amount = 1)
    {
        base.Init(item);
        _amountText.text = amount.ToString();
    }
}
