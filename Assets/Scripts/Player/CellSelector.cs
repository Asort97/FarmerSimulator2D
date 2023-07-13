using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellSelector : MonoBehaviour
{
    [SerializeField] private float actionRaduis;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Transform pointPos;
    private Vector3 pos;

    private void Update()
    {
        SelectRaduis();
    }
    private void SelectRaduis()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(pointPos.position, actionRaduis, layerMask);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(pointPos.position, actionRaduis);
    }
}
