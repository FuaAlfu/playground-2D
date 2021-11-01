using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 2021.11.1
/// </summary>

public class OnTrigger2DUtil : MonoBehaviour
{
    /*
    this approach not so efficient,
    we have to use physics overlap box, cast ..

    its only good for a short event such as , boss events.
     */
    public string targetTag = "Player";
    public UnityEvent OnTriggerEnterEvent, OnTriggerExitEvent;

    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.CompareTag(targetTag))
        {
            OnTriggerEnterEvent?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D c)
    {
        if (c.CompareTag(targetTag))
        {
            OnTriggerExitEvent?.Invoke();
        }
    }
}
