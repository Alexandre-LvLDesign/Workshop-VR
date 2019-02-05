using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Combine : VRTK_SnapDropZone
{
    protected virtual void OnTriggerStay(Collider collider)
    {

        CheckCanSnap(collider.GetComponentInParent<VRTK_InteractableObject>());
        
    }

    protected override void OnTriggerEnter(Collider collider)
    {
        //base.OnTriggerEnter(collider);
    }
}
