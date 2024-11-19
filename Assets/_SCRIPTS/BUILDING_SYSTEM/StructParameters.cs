using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructParameters : MonoBehaviour
{
    [Header("GENERAL")]
    public StructNature structNature;
    public int ID;
    [Space(5)]
    public int creditsCost;
    public int scrapsCost;
    public int metalsCost;

    [Space(10)]
    [Header("IN GAME")]
    public Vector3 structPosition;
    public bool isPosed;

    private void Start()
    {
        ID = ((int)structNature);
    }

    private void Update()
    {
        structPosition = transform.position;
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
