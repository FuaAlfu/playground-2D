using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2021.9.25
/// </summary>

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 2.2f;


    Rigidbody2D rb2D;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * _speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.right * -_speed * Time.deltaTime);
        }
    }
}
