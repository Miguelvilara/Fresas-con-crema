using System.Collections; 
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class Tower : MonoBehaviour
{
    [Header("References")]
    [SerializedField] private Transform turretRotationPoint;

    [Header("Atribute")]
    [SerializedField] private float targetingRange = 5f;

    private void OnDrawGizmosSelected()
    { 
    
        Handles.color = Color Cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, targetingRange);

    }
}
