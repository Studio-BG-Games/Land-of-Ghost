using PixelCrushers.DialogueSystem;
using System.Collections;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    [SerializeField] private LevelData _levelSettings;
    private DialogueSystemTrigger _dialogueSystemTrigger;
    private void Awake()
    {
        _dialogueSystemTrigger = GetComponent<DialogueSystemTrigger>();
        _dialogueSystemTrigger.conversation = _levelSettings.ConversationName;
    }
    public void TakeDmgDialog()
    {
        _dialogueSystemTrigger.conversation = _levelSettings.ConversationName + "TakeDmg";
        _dialogueSystemTrigger.Start();
    }
    public void DeathDialog()
    {
        _dialogueSystemTrigger.conversation = _levelSettings.ConversationName + "Death";
        _dialogueSystemTrigger.Start();
    }
}
