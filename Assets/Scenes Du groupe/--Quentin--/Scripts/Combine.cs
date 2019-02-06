using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Combine : VRTK_SnapDropZone
{
    [Header("Combine Settings")]

    public GameObject targetPrefab;
    public GameObject bulletPrefab;

    protected virtual void OnTriggerStay(Collider collider)
    {
        if(bulletPrefab.transform.rotation == targetPrefab.transform.rotation)
        {
            Debug.Log("yeah");
            CheckCanSnap(collider.GetComponentInParent<VRTK_InteractableObject>());
        }
    }

    protected override void OnTriggerEnter(Collider collider)
    {
        //base.OnTriggerEnter(collider);
    }
}
