using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using System;
using UnityEngine.Events;

public class UIItemSelect : MonoBehaviour
{
    [SerializeField] private GameObject _hidePanel;
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _cellIdText;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _description;
    [SerializeField] private TextMeshProUGUI _buttonSelectText;
    [SerializeField] private string _buttonSelectText1;
    [SerializeField] private string _buttonSelectText2;
    [SerializeField] private InventorySO _inventorySO;
    private List<Amulet> _amulets;
    private List<Potion> _potions;
    private int _currentNumber;
    private int _cellId;
    private Amulet _amuletInSlot;
    private Potion _potionInSlot;
    private bool _isAmulet;
    public UnityEvent OnSetAmulet;
    public void OpenSelectPanel(int cellId,bool isAmulet)
    {
        _cellId = cellId;
        _cellIdText.text = $"{cellId}/3";
        _buttonSelectText.text = $"{_buttonSelectText1} {cellId}";
        _hidePanel.SetActive(false);
        gameObject.SetActive(true);
        _isAmulet = isAmulet;
        if (_isAmulet)
        {
            _amuletInSlot = _inventorySO.AmuletsInSlot[cellId - 1];
            _amulets = _inventorySO.GetAmulets();
            if (_amuletInSlot != null)
            {
                _amulets.Add(_amuletInSlot);
                _currentNumber = _amulets.Count - 1;
            }
            else
            {
                _currentNumber = 0;
            }
            SetInfo(_amulets);
        }
        else
        {
            _potionInSlot = _inventorySO.PotionsInSlot[cellId - 1];
            _potions = _inventorySO.GetPotions();
            if (_potionInSlot != null)
            {
                _potions.Add(_potionInSlot);
                _currentNumber = _potions.Count - 1;
            }
            else
            {
                _currentNumber = 0;
            }
            SetInfo(_potions);
        }        
    }
    public void CloseSelectPanel()
    {
        _hidePanel.SetActive(true);
        gameObject.SetActive(false);
    }
    public void NextAmulet()
    {
        if (_isAmulet)
        {
            if (_amulets.Count - 1 == _currentNumber)
                _currentNumber = 0;
            else
                _currentNumber++;
            SetInfo(_amulets);
        }
        else
        {
            if (_potions.Count - 1 == _currentNumber)
                _currentNumber = 0;
            else
                _currentNumber++;
            SetInfo(_potions);
        }
    }
    public void PrevAmulet()
    {
        if (_isAmulet)
        {
            if (_currentNumber == 0)
                _currentNumber = _amulets.Count - 1;
            else
                _currentNumber--;
            SetInfo(_amulets);
        }
        else
        {
            if (_currentNumber == 0)
                _currentNumber = _potions.Count - 1;
            else
                _currentNumber--;
            SetInfo(_potions);
        }
    }
    private void SetInfo(List<Amulet> amulets)
    {
        _image.sprite = amulets[_currentNumber].Icon;
        _name.text = amulets[_currentNumber].Name;
        _description.text = amulets[_currentNumber].Description;
    }
    private void SetInfo(List<Potion> potions)
    {
        _image.sprite = potions[_currentNumber].Icon;
        _name.text = potions[_currentNumber].Name;
        _description.text = potions[_currentNumber].Description;
    }
    public void PutAmuletInSlot()
    {
        if (_isAmulet)
        {
            if (_amulets[_currentNumber] != _amuletInSlot)
            {
                if (_amuletInSlot != null)
                    _inventorySO.AddItem(_amuletInSlot);
                _inventorySO.PutAmuletInSlot(_cellId - 1, _amulets[_currentNumber]);
                OnSetAmulet?.Invoke();
            }
        }
        else
        {
            if (_potions[_currentNumber] != _potionInSlot)
            {
                if (_potionInSlot != null)
                    _inventorySO.AddItem(_potionInSlot);
                _inventorySO.PutPotionInSlot(_cellId - 1, _potions[_currentNumber]);
                OnSetAmulet?.Invoke();
            }
        }
        CloseSelectPanel();
    } 
}
