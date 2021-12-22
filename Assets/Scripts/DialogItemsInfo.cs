using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogItemsInfo : MonoBehaviour
{
    [SerializeField] private StringChannelSO _onClickItemChannel;
    private DialogueSystemTrigger _dialogueSystemTrigger;

    private void Awake()
    {
        _dialogueSystemTrigger = GetComponent<DialogueSystemTrigger>();
    }
    private void OnEnable()
    {
        _onClickItemChannel.OnStringChannel += TraderDialog;
    }
    private void OnDisable()
    {
        _onClickItemChannel.OnStringChannel -= TraderDialog;
    }
    public void TraderDialog(string itemName)
    {
        DialogueLua.SetVariable("ItemName", itemName);
        if(DialogueLua.GetItemField(itemName,"Name").HasReturnValue)
            _dialogueSystemTrigger.OnUse();
    }
}
