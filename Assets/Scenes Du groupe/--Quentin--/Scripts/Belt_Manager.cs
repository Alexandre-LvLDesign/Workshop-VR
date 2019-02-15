using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Belt_Manager : MonoBehaviour {

    [SerializeField] VRTK_TransformFollow transformFollowScript;
    

    private void OnEnable()
    {
        //transformFollowScript = GetComponent<VRTK_TransformFollow>();
        StartCoroutine(MyCouroutine());
    }

	IEnumerator MyCouroutine()
    {
        yield return null;
        Transform transformToFollow;

        transformToFollow = VRTK_DeviceFinder.DeviceTransform(VRTK_DeviceFinder.Devices.Headset);

        if (VRTK_DeviceFinder.GetHeadsetType() == SDK_BaseHeadset.HeadsetType.Simulator)
        {
            VRTK_SDKSetup sdksetup = transformToFollow.GetComponentInParent<VRTK_SDKSetup>();
            transformToFollow = sdksetup.transform.GetChild(0);
        }
        
        transformFollowScript.gameObjectToFollow = transformToFollow.gameObject;
    }
}
