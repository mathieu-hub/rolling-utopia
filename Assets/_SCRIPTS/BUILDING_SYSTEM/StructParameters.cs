using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructParameters : MonoBehaviour
{
    [Header("GENERAL")]
    public StructNature structNature;
    public int ID;

    [Header("Bulding")]
    public bool cannotBuildOnIt; //Use this parameter as a placement validity condition

    [Header("Cost")]
    public int creditsCost;
    public int scrapsCost;
    public int metalsCost;

    [Header("IN GAME")]
    public Vector3 structPosition;
    [Space(5)]
    public bool enoughResourcesToPose; 
    public bool isPosed;

    private void Start()
    {
        ID = ((int)structNature);
        CheckResourcesToPlacementValidity();
    }

    private void Update()
    {
        structPosition = transform.position;
    }

    public void CheckResourcesToPlacementValidity()
    {
        if (creditsCost <= ResourcesManager.Instance.credits
            && scrapsCost <= ResourcesManager.Instance.scraps
            && metalsCost <= ResourcesManager.Instance.metal)
        {
            enoughResourcesToPose = true;
            Debug.Log("Enough");
        }
        else
        {
            enoughResourcesToPose = false;
            Debug.Log("Not enough");
        }
    }
}

public enum StructNature
{
    CP_Platform = 0,

    B_House = 2,
    B_WaterTank = 3,
    B_Generator = 4,
    B_Factory = 5,
}
