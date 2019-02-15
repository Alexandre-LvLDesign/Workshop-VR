using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Belt_TransformFollow : VRTK_TransformFollow {

    protected override void SetRotationOnGameObject(Quaternion newRotation)
    {
        Vector3 rotation = transformToChange.rotation.eulerAngles;

        rotation.y = newRotation.eulerAngles.y;
        transformToChange.rotation = Quaternion.Euler(rotation);
        transform.position = new Vector3(transformToFollow.transform.position.x, transformToFollow.transform.position.y - 10.0f, transformToFollow.transform.position.z);
    }
}
