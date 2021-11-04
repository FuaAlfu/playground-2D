using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2021.11.3
/// </summary>

public class AIPlayerDetector : MonoBehaviour
{
    [field: SerializeField]
    public bool PlayerDetected { get; private set; }
    public Vector2 DirectionToTarget => target.transform.position - detectionOrgin.position;

    [Header("overlapBox params")]
    [SerializeField]
    private Transform detectionOrgin;
    public Vector2 detectorSize = Vector2.one;
    public Vector2 detectorOriginOffset = Vector2.zero;
    public float detectionDeley = 0.3f;
    public LayerMask detectorLayerMask;

    [Header("Gizmo params")]
    public Color gizmoIdleColor = Color.green;
    public Color gizmoDetectedColor = Color.red;
    public bool showGizmos = true;

    private GameObject target;
    public GameObject Target
    {
        get => target;
        private set
        {
            target = value;
            PlayerDetected = target != null;
        }
    }

    [Header("props")]
    [SerializeField]
    private float speed = 2.2f;
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private Transform mainPos;
    private Transform player;
    bool followPlayer;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DetectionCoroutine());

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (followPlayer == true)
            enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, player.position, speed * Time.deltaTime);
        else
            BackToOriginPos();
    }

    private void OnDrawGizmos()
    {
        if (showGizmos && detectionOrgin != null)
        {
            Gizmos.color = gizmoIdleColor;
            if (PlayerDetected)
                Gizmos.color = gizmoDetectedColor;
            Gizmos.DrawCube((Vector2)detectionOrgin.position + detectorOriginOffset, detectorSize);
        }
    }

    IEnumerator DetectionCoroutine()
    {
        yield return new WaitForSeconds(detectionDeley);
        PerformDetection();
        StartCoroutine(DetectionCoroutine());
    }

    public void PerformDetection()
    {
        Collider2D collider = Physics2D.OverlapBox((Vector2)detectionOrgin.position + detectorOriginOffset, detectorSize, 0, detectorLayerMask);
        if(collider != null)
        {
            Target = collider.gameObject;
            followPlayer = true;

        }
        else
        {
            Target = null;
            followPlayer = false;
            BackToOriginPos();
        }
    }

    void BackToOriginPos()
    {
        enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, mainPos.position, speed * Time.deltaTime);

    }
}
