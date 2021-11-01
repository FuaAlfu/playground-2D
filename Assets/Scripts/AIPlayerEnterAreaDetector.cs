using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2021.11.1
/// </summary>
public class AIPlayerEnterAreaDetector : MonoBehaviour
{
    [field: SerializeField]
    public bool PlayerInArea { get; private set; }
    public Transform Player { get; private set; }

    [SerializeField]
    private string detectionTag = "Player";


    private void OnTriggerEnter2D(Collider2D c)
    {
        if(c.CompareTag(detectionTag))
        {
            PlayerInArea = true;
            Player = c.gameObject.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D c)
    {
        if (c.CompareTag(detectionTag))
        {
            PlayerInArea = false;
            Player = null;
        }
    }
}
