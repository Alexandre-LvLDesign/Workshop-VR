using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Belt_Manager : MonoBehaviour {

    [SerializeField] VRTK_TransformFollow tf;
    public Transform t;

    private void OnEnable()
    {
        //tf = GetComponent<VRTK_TransformFollow>();
        StartCoroutine(MyCouroutine());
    }

	IEnumerator MyCouroutine()
    {
        yield return null;
        t = VRTK_DeviceFinder.DeviceTransform(VRTK_DeviceFinder.Devices.Headset);
        
    }
}
