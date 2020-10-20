using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UnitSlotTemplate : MonoBehaviour
{
    public AmountToBuy amountToBuy;
    public int amount;

    public TextMeshProUGUI materialsTMP;
    public TextMeshProUGUI goldTMP;
    public TextMeshProUGUI gemsTMP;
    public TextMeshProUGUI populationTMP;

    public int materialsCost;
    public int goldCost;
    public int gemsCost;
    public int populationCost;

    public int currentMaterialsCost;
    public int currentGoldCost;
    public int currentGemsCost;
    public int currentPopulationCost;

    public int unitId;

    void Start()
    {
        materialsCost = int.Parse(materialsTMP.GetComponent<TextMeshProUGUI>().text);
        goldCost = int.Parse(goldTMP.GetComponent<TextMeshProUGUI>().text);
        gemsCost = int.Parse(gemsTMP.GetComponent<TextMeshProUGUI>().text);
        populationCost = int.Parse(populationTMP.GetComponent<TextMeshProUGUI>().text);
    }

    private void Update()
    {
        CountAmountAndCost();
    }

    public void CountAmountAndCost()
    {
        amount = amountToBuy.amount;
        currentMaterialsCost = amount * materialsCost;
        currentGoldCost = amount * goldCost;
        currentGemsCost = amount * gemsCost;
        currentPopulationCost = amount * populationCost;
    }
}