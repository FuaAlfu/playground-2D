using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 2021.11.3
/// </summary>

public class AIMeleeAttackDetector : MonoBehaviour
{
    public LayerMask targetLayer;
    public UnityEvent<GameObject> OnPlayerDetected;

    [Range(.1f, 1)]
    public float radius;

    [Header("Gizmo params")]
    public Color gizmoColor = Color.green;
    public bool showGizmos = true;

    public bool PlayerDetected { get; internal set; }

    [SerializeField]
    private GameObject p;

    void Update()
    {
        var collider = Physics2D.OverlapCircle(transform.position, radius, targetLayer);
        PlayerDetected = collider != null;
        if (PlayerDetected)
            OnPlayerDetected?.Invoke(collider.gameObject);
        p.SetActive(true);
    }

    private void OnDrawGizmos()
    {
        if(showGizmos)
        {
            Gizmos.color = gizmoColor;
            Gizmos.DrawSphere(transform.position, radius);
        }
    }
}
