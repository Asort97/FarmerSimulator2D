using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellSelector : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Transform pointPos;
    private PlayerStats playerStats;
    private Vector3 pos;

    private void Start()
    {
        playerStats = PlayerStats.Instance;    
    }

    public Collider2D[] SelectorRaduis()
    {
        Collider2D[] beds = Physics2D.OverlapCircleAll(pointPos.position, playerStats.ActionRaduis, layerMask);
        return beds;
    }

    public Collider2D SelectorClosestBed(ModeSwitcher.ModeStates states)
    {
        Collider2D[] beds = Physics2D.OverlapCircleAll(pointPos.position, playerStats.ActionRaduis, layerMask);

        float minDist = 20f;
        Collider2D closestBed = null;

        foreach (var bed in beds)
        {
            if(states == ModeSwitcher.ModeStates.Planting)
            {
                if (!bed.GetComponent<GardenBed>().IsPlanted)
                {
                    float dist = Vector2.Distance(transform.position, bed.transform.position);
                    if (dist < minDist)
                    {
                        minDist = dist;
                        closestBed = bed;
                    }                
                }                
            }
            if(states == ModeSwitcher.ModeStates.Destroying)
            {
                if (bed.GetComponent<GardenBed>().IsPlanted)
                {
                    float dist = Vector2.Distance(transform.position, bed.transform.position);
                    if (dist < minDist)
                    {
                        minDist = dist;
                        closestBed = bed;
                    }                
                }                
            }
        }
        return closestBed;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(196, 177, 0, 0.3f);
        Gizmos.DrawSphere(pointPos.position, playerStats.ActionRaduis);
    }
}
