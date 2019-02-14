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
    }
}
