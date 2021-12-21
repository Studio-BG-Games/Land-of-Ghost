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
    [SerializeField] private Amulet _voidAmuletSO;
    [SerializeField] private Potion _voidPotionSO;
    private List<Amulet> _amulets;
    private Dictionary<Potion, int> _potions;
    private int _currentNumber;
    private int _cellId;
    private Amulet _amuletInSlot;
    private Potion _potionInSlot;
    private bool _isAmulet;
    public UnityEvent OnSetItem;
    public void OpenSelectPanel(int cellId,bool isAmulet)
    {
        _cellId = cellId;
        _cellIdText.text = $"{cellId}/3";
        _hidePanel.SetActive(false);
        gameObject.SetActive(true);
        _isAmulet = isAmulet;
        if (_isAmulet)
        {
            _amuletInSlot = _inventorySO.AmuletsInSlot[cellId - 1];
            _amulets = _inventorySO.GetAmulets();
            if (_amuletInSlot != null)
            {
                _buttonSelectText.text = _buttonSelectText2;
                _amulets.Add(_amuletInSlot);
                _currentNumber = _amulets.Count - 1;
            }
            else
            {
                if (_amulets.Count == 0)
                    _amulets.Add(_voidAmuletSO);
                _currentNumber = 0;
            }
            SetInfo(_amulets);
        }
        else
        {
            _potionInSlot = _inventorySO.PotionsInSlot[cellId - 1];
            _potions = _inventorySO.GetPotions();
            List<Potion> removePotions = new List<Potion>();
            foreach (var potion in _potions)
            {
                if (_inventorySO.PotionsInSlot.Contains(potion.Key) && _potionInSlot != potion.Key)
                    removePotions.Add(potion.Key);
            }
            foreach (var potion in removePotions)
            {
                _potions.Remove(potion);
            }
            if (_potionInSlot != null)
            {
                _buttonSelectText.text = _buttonSelectText2;
                _currentNumber = _potions.Count - 1;
            }
            else
            {                
                if (_potions.Count == 0)
                    _potions.Add(_voidPotionSO, 0);
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
        if (_amulets[_currentNumber] == _amuletInSlot)
            _buttonSelectText.text = _buttonSelectText2;
        else
            _buttonSelectText.text = $"{_buttonSelectText1} {_cellId}";
    }
    private void SetInfo(Dictionary<Potion, int> potions)
    {
        var potion = potions.ElementAt(_currentNumber).Key;
        _image.sprite = potion.Icon;
        _name.text = potion.Name;
        _description.text = potion.Description;
        if (potion == _potionInSlot)
            _buttonSelectText.text = _buttonSelectText2;
        else
            _buttonSelectText.text = $"{_buttonSelectText1} {_cellId}";
    }
    public void PutAmuletInSlot()
    {
        if (_isAmulet)
        {
            _inventorySO.PutAmuletInSlot(_cellId - 1, _amulets[_currentNumber], _amuletInSlot);
            OnSetItem?.Invoke();
        }
        else
        {
            _inventorySO.PutPotionInSlot(_cellId - 1, _potions.ElementAt(_currentNumber).Key, _potionInSlot);
            OnSetItem?.Invoke();
        }
        CloseSelectPanel();
    } 
}
