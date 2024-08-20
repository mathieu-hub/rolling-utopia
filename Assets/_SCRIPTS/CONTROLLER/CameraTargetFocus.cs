using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTargetFocus : MonoBehaviour
{
    public void OnMouseDown()
    {
        CameraController.instance.targetTransform = transform;
    }
}
