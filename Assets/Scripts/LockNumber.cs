using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2021.11.11
/// </summary>

public class LockNumber : MonoBehaviour
{
    [SerializeField]
    private int _mycode;

    private int[] password = new int[]{12,4,8,9};

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckPassword();
    }

    private void CheckPassword()
    {
       foreach(int pass in password)
        {

        }
    }
}
