using PixelCrushers.DialogueSystem;
using System.Collections;
using UnityEngine;

public class DialogTrader : MonoBehaviour
{
    private DialogueSystemTrigger _dialogueSystemTrigger;
    private void Awake()
    {
        _dialogueSystemTrigger = GetComponent<DialogueSystemTrigger>();
    }
    public void TraderQuestStartDialog()
    {
        _dialogueSystemTrigger.conversation = "TraderQuest";
        _dialogueSystemTrigger.Start();
    }
}
