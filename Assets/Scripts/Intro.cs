using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Intro : MonoBehaviour
{
    [SerializeField] private float _videoLengthSeconds;
    public UnityEvent<string> OnVideoEnd;
    private void Start()
    {
        StartCoroutine(WaitVideoEnd());
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }
    private IEnumerator WaitVideoEnd()
    {
        yield return new WaitForSeconds(_videoLengthSeconds);
        OnVideoEnd?.Invoke("MainMenu");
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
            OnVideoEnd?.Invoke("MainMenu");
    } 
}
