using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class UIMoneySlot : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _price;
    public UnityEvent OnTrySell;
    private void OnMouseDown()
    {
        OnTrySell?.Invoke();
    }
    public void ItemSellChange(int amount)
    {
        _price.text = amount.ToString();
    } 
    public void Clear()
    {
        _price.text = "";
    }
}
