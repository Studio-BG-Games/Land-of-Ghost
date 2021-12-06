using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private Image _healthBar;
    void Start()
    {
        
    }
    public void OnHealthChange(int maxHP,int currentHP)
    {
        _healthBar.rectTransform.localScale = new Vector3((float)currentHP / (float)maxHP, 1);
        _healthText.text = $"’œ {currentHP}/{maxHP}";
    }
}
  