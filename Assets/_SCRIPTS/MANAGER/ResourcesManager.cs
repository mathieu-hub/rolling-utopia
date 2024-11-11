using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : MonoBehaviour
{
    public static ResourcesManager Instance;

    public int credits;
    public int scraps;
    public int metal;

    public int citizen;
    public int globalSatisfaction;
    public int happiness;
    public int health;
    public int hungriness;

    public int structures;
    public int water;
    public int energy;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UIManager.Instance.UpdateResourcesValuesUI();
    }
}
