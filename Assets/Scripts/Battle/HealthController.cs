using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private Image _healthBar;
    private int _maxHP;
    public void Initialize(int maxHP, int currentHP)
    {
        _maxHP = maxHP;
        _healthBar.rectTransform.localScale = new Vector3((float)currentHP / (float)maxHP, 1);
        _healthText.text = $"’œ {currentHP}/{maxHP}";
    }
    public void OnHealthChange(int currentHP)
    {
        _healthBar.rectTransform.localScale = new Vector3((float)currentHP / (float)_maxHP, 1);
        _healthText.text = $"’œ {currentHP}/{_maxHP}";
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
  