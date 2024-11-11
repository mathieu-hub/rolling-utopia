using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StructDetection : MonoBehaviour
{
    public bool collideWithBuildable;
    [Space(5)]
    public bool collideWithCP_Platform;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<StructDetection>() != null)
        {
            //BUILDABLE
            if (other.GetComponent<StructParameters>().ID >= 1
                && other.GetComponent<StructParameters>().isPosed)
            {
                Debug.Log("Collide Buildable");
                collideWithBuildable = true;
            }

            //CP_PLATFORM
            if (other.GetComponent<StructParameters>().ID == 0
                && other.GetComponent<StructParameters>().isPosed)
            {
                Debug.Log("Collide CP_Platform");
                collideWithCP_Platform = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<StructDetection>() != null)
        {
            //BUILDABLE
            if (other.GetComponent<StructParameters>().ID >= 1
                && other.GetComponent<StructParameters>().isPosed)
            {
                Debug.Log("Discollide Buildable");
                collideWithBuildable = false;
            }

            //CP_PLATFORM
            if (other.GetComponent<StructParameters>().ID == 0
                && other.GetComponent<StructParameters>().isPosed)
            {
                Debug.Log("Discollide CP_Platform");
                collideWithCP_Platform = false;
            }
        }
    }
}
