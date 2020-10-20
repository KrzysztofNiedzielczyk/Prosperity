using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildMenu : MonoBehaviour
{
    public Transform container;
    public Transform structureTemplate;
    public Sprite tools;
    public Sprite coin;
    public Sprite jewel;
    public GameObject currentPrefab;

    public StructureDatabase structureDatabase;

    private void Awake()
    {
        structureTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        for (int i = 2; i < structureDatabase.structureDatabaseList.Count; i++)
        {
            BuildStructure(structureDatabase.structureDatabaseList[i].icon, tools, structureDatabase.structureDatabaseList[i].materialsCost, coin, structureDatabase.structureDatabaseList[i].goldCost, jewel, structureDatabase.structureDatabaseList[i].gemsCost, structureDatabase.structureDatabaseList[i].obj);
        }
    }

    public void BuildStructure(Sprite structureIcon, Sprite tools, int structureCostMaterials, Sprite coin, int structureCostGold, Sprite jewel, int structureCostGems, GameObject obj)
    {
        Transform structureTransform = Instantiate(structureTemplate, container);
        structureTransform.gameObject.SetActive(true);

        structureTransform.Find("Image").GetComponent<Image>().sprite = structureIcon;

        structureTransform.Find("Coin").GetComponent<Image>().sprite = coin;
        structureTransform.Find("Gold").GetComponent<TextMeshProUGUI>().text = structureCostGold.ToString();

        structureTransform.Find("Tools").GetComponent<Image>().sprite = tools;
        structureTransform.Find("Materials").GetComponent<TextMeshProUGUI>().text = structureCostMaterials.ToString();

        structureTransform.Find("Jewel").GetComponent<Image>().sprite = jewel;
        structureTransform.Find("Gems").GetComponent<TextMeshProUGUI>().text = structureCostGems.ToString();

        structureTransform.GetComponent<StructureSlotTemplate>().structurePrefab = obj;
    }
}
