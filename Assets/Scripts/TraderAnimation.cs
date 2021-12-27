using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;

public class TraderAnimation : MonoBehaviour
{
    [SerializeField] private UnityArmatureComponent _armature;
    [SerializeField] private VoidChannelSO _traderTalk;
    [SerializeField] private VoidChannelSO _traderAngry;
    enum amim
    {
        idle = 4,
        talk = 2,
        talk2 = 5,
        angry = 1,
        angry2 = 3,
    }
    private void Start()
    {
        _traderTalk.OnVoid += Talk;
        _traderAngry.OnVoid += Angry;
    }
    private void OnEnable()
    {
        StartCoroutine(WaitAnimationEnd());
    }
    private void OnDisable()
    {
        StopAllCoroutines();
        _traderTalk.OnVoid -= Talk;
        _traderAngry.OnVoid -= Angry;
    }
    public void Talk()
    {
        int animId = (int)amim.talk;
        _armature.animation.GotoAndPlayByProgress(animId.ToString(), 0, 1);
    }
    public void Angry()
    {
        int animId = (int)amim.talk;
        _armature.animation.GotoAndPlayByProgress(animId.ToString(), 0, 1);
    }
    private IEnumerator WaitAnimationEnd()
    {
        int animId = (int)amim.idle;
        while (_armature.animation != null)
        {
            if (_armature.animation.isCompleted)
                _armature.animation.GotoAndPlayByProgress(animId.ToString(), 0, -1);
            yield return null;
        }
    }
}
