using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TroopsPanel : MonoBehaviour
{
    public Transform container;
    public Transform troopTemplate;

    private void Awake()
    {
        troopTemplate.gameObject.SetActive(false);

        for (int i = 3; i < FriendlyTroopsDatabase.Instance.friendlyInfantryDatabase.Count; i++)
        {
            RecruitUnit(FriendlyTroopsDatabase.Instance.friendlyInfantryDatabase[i].unitName, FriendlyTroopsDatabase.Instance.friendlyInfantryDatabase[i].icon, FriendlyTroopsDatabase.Instance.friendlyInfantryDatabase[i].materialsCost, FriendlyTroopsDatabase.Instance.friendlyInfantryDatabase[i].goldCost, FriendlyTroopsDatabase.Instance.friendlyInfantryDatabase[i].gemsCost, FriendlyTroopsDatabase.Instance.friendlyInfantryDatabase[i].populationCost, FriendlyTroopsDatabase.Instance.friendlyInfantryDatabase[i].id);
        }
        for (int i = 0; i < FriendlyTroopsDatabase.Instance.friendlyRiderDatabase.Count; i++)
        {
            RecruitUnit(FriendlyTroopsDatabase.Instance.friendlyRiderDatabase[i].unitName, FriendlyTroopsDatabase.Instance.friendlyRiderDatabase[i].icon, FriendlyTroopsDatabase.Instance.friendlyRiderDatabase[i].materialsCost, FriendlyTroopsDatabase.Instance.friendlyRiderDatabase[i].goldCost, FriendlyTroopsDatabase.Instance.friendlyRiderDatabase[i].gemsCost, FriendlyTroopsDatabase.Instance.friendlyRiderDatabase[i].populationCost, FriendlyTroopsDatabase.Instance.friendlyRiderDatabase[i].id);
        }
        for (int i = 0; i < FriendlyTroopsDatabase.Instance.friendlyShooterDatabase.Count; i++)
        {
            RecruitUnit(FriendlyTroopsDatabase.Instance.friendlyShooterDatabase[i].unitName, FriendlyTroopsDatabase.Instance.friendlyShooterDatabase[i].icon, FriendlyTroopsDatabase.Instance.friendlyShooterDatabase[i].materialsCost, FriendlyTroopsDatabase.Instance.friendlyShooterDatabase[i].goldCost, FriendlyTroopsDatabase.Instance.friendlyShooterDatabase[i].gemsCost, FriendlyTroopsDatabase.Instance.friendlyShooterDatabase[i].populationCost, FriendlyTroopsDatabase.Instance.friendlyShooterDatabase[i].id);
        }
        for (int i = 0; i < FriendlyTroopsDatabase.Instance.friendlyMachineDatabase.Count; i++)
        {
            RecruitUnit(FriendlyTroopsDatabase.Instance.friendlyMachineDatabase[i].unitName, FriendlyTroopsDatabase.Instance.friendlyMachineDatabase[i].icon, FriendlyTroopsDatabase.Instance.friendlyMachineDatabase[i].materialsCost, FriendlyTroopsDatabase.Instance.friendlyMachineDatabase[i].goldCost, FriendlyTroopsDatabase.Instance.friendlyMachineDatabase[i].gemsCost, FriendlyTroopsDatabase.Instance.friendlyMachineDatabase[i].populationCost, FriendlyTroopsDatabase.Instance.friendlyMachineDatabase[i].id);
        }
        for (int i = 0; i < FriendlyTroopsDatabase.Instance.friendlySpecialDatabase.Count; i++)
        {
            RecruitUnit(FriendlyTroopsDatabase.Instance.friendlySpecialDatabase[i].unitName, FriendlyTroopsDatabase.Instance.friendlySpecialDatabase[i].icon, FriendlyTroopsDatabase.Instance.friendlySpecialDatabase[i].materialsCost, FriendlyTroopsDatabase.Instance.friendlySpecialDatabase[i].goldCost, FriendlyTroopsDatabase.Instance.friendlySpecialDatabase[i].gemsCost, FriendlyTroopsDatabase.Instance.friendlySpecialDatabase[i].populationCost, FriendlyTroopsDatabase.Instance.friendlySpecialDatabase[i].id);
        }
    }

    public void RecruitUnit(string unitName, Sprite unitIcon, int unitCostMaterials, int unitCostGold, int unitCostGems, int unitPopulationCost, int unitId)
    {
        Transform unitTransform = Instantiate(troopTemplate, container);
        unitTransform.gameObject.SetActive(true);

        unitTransform.Find("Unit_Details").Find("Unit_Name").GetComponent<TextMeshProUGUI>().text = unitName;
        unitTransform.Find("Unit_Details").Find("Unit_Icon").GetComponent<Image>().sprite = unitIcon;

        unitTransform.Find("Unit_Details").Find("Unit_Cost").Find("Materials").GetComponent<TextMeshProUGUI>().text = unitCostMaterials.ToString();
        unitTransform.Find("Unit_Details").Find("Unit_Cost").Find("Gold").GetComponent<TextMeshProUGUI>().text = unitCostGold.ToString();
        unitTransform.Find("Unit_Details").Find("Unit_Cost").Find("Gems").GetComponent<TextMeshProUGUI>().text = unitCostGems.ToString();
        unitTransform.Find("Unit_Details").Find("Unit_Cost").Find("Population").GetComponent<TextMeshProUGUI>().text = unitPopulationCost.ToString();

        unitTransform.gameObject.GetComponent<UnitSlotTemplate>().unitId = unitId;
    }
}