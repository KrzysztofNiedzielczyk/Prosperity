using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmDemolishion : MonoBehaviour
{
    public TextMeshProUGUI materialsAmount;
    public TextMeshProUGUI goldAmount;
    public TextMeshProUGUI gemsAmount;
    public Transform structureSelected;


    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void SetDemolishData(float materialsValue, float goldValue, float gemsValue)
    {
        string materialsString = Mathf.FloorToInt(materialsValue).ToString();
        string goldString = Mathf.FloorToInt(goldValue).ToString();
        string gemsString = Mathf.FloorToInt(gemsValue).ToString();

        materialsAmount.text = materialsString;
        goldAmount.text = goldString;
        gemsAmount.text = gemsString;
    }

    public void SetDemolishIcon(Sprite icon)
    {
        structureSelected.GetComponent<Image>().sprite = icon;
    }
}
