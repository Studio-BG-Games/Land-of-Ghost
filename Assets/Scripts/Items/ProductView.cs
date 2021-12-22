using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProductView : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Image _imagePriceItem;
    [SerializeField] private TextMeshProUGUI _priceText;
    public void Init(Items item)
    {
        _image.sprite = item.Icon;
        string plus ="";
        if (item.ItemPrice != null)
        {
            _imagePriceItem.sprite = item.ItemPrice.Icon;
            plus = "+";
        }
        else
        {
            _imagePriceItem.enabled = false;
        }
        _priceText.text = $"{item.MoneyPrice} {plus}";
    }
}
