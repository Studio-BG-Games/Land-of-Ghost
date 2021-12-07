using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class UIAmuletSelect : MonoBehaviour
{
    [SerializeField] private GameObject _hidePanel;
    [SerializeField] private Image _imageAmulet;
    [SerializeField] private TextMeshProUGUI _cellIdText;
    [SerializeField] private TextMeshProUGUI _amuletDescription;
    [SerializeField] private TextMeshProUGUI _buttonSelectText;
    [SerializeField] private string _buttonSelectText1;
    [SerializeField] private string _buttonSelectText2;
    [SerializeField] private InventorySO _inventorySO;
    private List<Amulet> _amulets;
    public void OpenSelectPanel(int cellId)
    {
        _cellIdText.text = $"{cellId}/3";
        _buttonSelectText.text = $"{_buttonSelectText1} {cellId}";
        _hidePanel.SetActive(false);
        gameObject.SetActive(true);
        _amulets = _inventorySO.GetAmulets();
        var firstAmulet = _amulets.First();
        _imageAmulet.sprite = firstAmulet.Icon;
        _amuletDescription.text = firstAmulet.Name;
    }
    public void CloseSelectPanel()
    {
        _hidePanel.SetActive(true);
        gameObject.SetActive(false);
    }
}
