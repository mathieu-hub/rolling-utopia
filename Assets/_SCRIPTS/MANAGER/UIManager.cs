using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("RESOURCES")]
    public TextMeshProUGUI creditsValue;
    public TextMeshProUGUI scrapsValue;
    public TextMeshProUGUI metalsValue;
    public TextMeshProUGUI structuresValue;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateResourcesValuesUI()
    {
        creditsValue.text = ResourcesManager.Instance.credits.ToString();
        scrapsValue.text = ResourcesManager.Instance.scraps.ToString();
        metalsValue.text = ResourcesManager.Instance.metal.ToString();
        structuresValue.text = ResourcesManager.Instance.structures.ToString();
    }
}
