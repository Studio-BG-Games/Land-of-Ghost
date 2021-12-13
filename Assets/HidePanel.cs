using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePanel : MonoBehaviour
{
    [SerializeField] private GameObject _hidePanel;
    private void OnMouseDown()
    {
        _hidePanel.SetActive(false);
    }
}
