using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructDetection : MonoBehaviour
{
    public int ID; //Must be the same value with Database prefab ID
    public bool collideWithStruct;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<StructDetection>() != null)
        {
            if (other.GetComponent<StructDetection>().ID >= 1)
            {
                Debug.Log("Collide");
                collideWithStruct = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<StructDetection>() != null)
        {
            if (other.GetComponent<StructDetection>().ID >= 1)
            {
                Debug.Log("Discollide");
                collideWithStruct = true;
            }
        }
    }
}
