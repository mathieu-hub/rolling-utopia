using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StructDetection : MonoBehaviour
{
    public int ID; //Must be the same value with Database prefab ID
    public bool collideWithStruct;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hello There!");

        if (other.GetComponent<StructDetection>() != null)
        {
            if (other.GetComponent<StructDetection>().ID >= 1
                && other.GetComponent<StructParameters>().isPosed)
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
            if (other.GetComponent<StructDetection>().ID >= 1
                && other.GetComponent<StructParameters>().isPosed)
            {
                Debug.Log("Discollide");
                collideWithStruct = false;
            }
        }
    }
}
