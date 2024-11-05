using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructParameters : MonoBehaviour
{
    public Vector3 structPosition;
    public bool isPosed;


    private void Update()
    {
        structPosition = transform.position;
    }
}
