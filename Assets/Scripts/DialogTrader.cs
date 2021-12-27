using PixelCrushers.DialogueSystem;
using System.Collections;
using UnityEngine;

public class DialogTrader : MonoBehaviour
{
    [SerializeField] private VoidChannelSO _onDialog;
    [SerializeField] private VoidChannelSO _onGetFirstQuest;
    [SerializeField] private VoidChannelSO _onDeclineQuest;
    private DialogueSystemTrigger _dialogueSystemTrigger;
    private string _traderFirstQuest;
    private void Start()
    {
        _traderFirstQuest = PlayerPrefs.GetString("TraderFirstQuest", "unassigned");
        _dialogueSystemTrigger = GetComponent<DialogueSystemTrigger>();
        if (PlayerPrefs.GetInt("TraderFirst") == 1)
            DialogueLua.SetVariable("TraderFirst", true);
        _onDialog.OnVoid += SaveFirstPhrase;
        _onGetFirstQuest.OnVoid += SaveFirstQuest;
        _onDeclineQuest.OnVoid += DeclineFirstQuest;
        _dialogueSystemTrigger.OnUse();
    }
    private void OnDisable()
    {
        _onDialog.OnVoid -= SaveFirstPhrase;
        _onGetFirstQuest.OnVoid -= SaveFirstQuest;
        _onDeclineQuest.OnVoid -= DeclineFirstQuest;
    }
    public void TraderQuestStartDialog()
    {
        _dialogueSystemTrigger.conversation = "TraderQuest";
        DialogueLua.SetQuestField("TraderFirstQuest", "State", _traderFirstQuest);
        _dialogueSystemTrigger.OnUse();
    }
    public void SaveFirstPhrase()
    {
        PlayerPrefs.SetInt("TraderFirst", 1);
    }
    public void SaveFirstQuest()
    {
        _traderFirstQuest = "active";
        PlayerPrefs.SetString("TraderFirstQuest", _traderFirstQuest);
    }
    public void DeclineFirstQuest()
    {
        _traderFirstQuest = "failure";
        PlayerPrefs.SetString("TraderFirstQuest", _traderFirstQuest);
    }
}
