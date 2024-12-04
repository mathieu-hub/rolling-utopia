using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StructDetection : MonoBehaviour
{
    public bool collideWithBuildable;
    [Space(5)]
    public bool collideWithCP_Platform;
    [Space(5)]
    public bool isDetectedInPlacementAOE; //Use this parameter as a condition to call function (bonus, malus, gains)

    private float verticalPos;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<StructDetection>() != null)
        {
            //BUILDABLE
            if (other.GetComponent<StructParameters>().ID >= 1
                && other.GetComponent<StructParameters>().isPosed)
            {
                //Debug.Log("Collide Buildable");
                collideWithBuildable = true;
            }

            //CP_PLATFORM
            /*if (other.GetComponent<StructParameters>().ID == 0
                && other.GetComponent<StructParameters>().isPosed)
            {
                //Debug.Log("Collide CP_Platform");
                collideWithCP_Platform = true;
                verticalPos = gameObject.transform.position.y;
            }*/
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
                //Debug.Log("Discollide Buildable");
                collideWithBuildable = false;
            }

            //CP_PLATFORM
            /*if (other.GetComponent<StructParameters>().ID == 0
                && other.GetComponent<StructParameters>().isPosed)
            {
                Debug.Log("Discollide CP_Platform");
                collideWithCP_Platform = false;
            }*/
        }
    }

    private void Update()
    {
        if (gameObject.transform.position.y < 1)
        {
            collideWithCP_Platform = true;
        }
        else
        {
            collideWithCP_Platform = false;
        }

        /*if (collideWithCP_Platform)
        {
            if (gameObject.transform.position.y != verticalPos)
            {
                collideWithCP_Platform = false;
            }
        }*/
    }
}
