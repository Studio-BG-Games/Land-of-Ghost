using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
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

}
