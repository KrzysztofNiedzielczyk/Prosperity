using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmBuildingPanel : MonoBehaviour
{
    public TextMeshProUGUI materialsCost;
    public TextMeshProUGUI goldCost;
    public TextMeshProUGUI gemsCost;
    public Transform structureSelected;

    public Vector3 nodePosition;
    private GameObject _structurePrefab;
    public Transform nodesContainer;

    public Image costBlocker;
    public Image replaceBlocker;

    private int _materialsCostInt;
    private int _goldCostInt;
    private int _gemsCostInt;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    private void Start()
    {
        transform.localPosition = Vector3.zero;
    }

    private void Update()
    {
        CheckIfCanBuild();
    }

    public void SetData(Sprite icon, string materialsValue, string goldValue, string gemsValue, GameObject prefab)
    {
        structureSelected.GetComponent<Image>().sprite = icon;
        materialsCost.text = materialsValue;
        goldCost.text = goldValue;
        gemsCost.text = gemsValue;
        _structurePrefab = prefab;

        _materialsCostInt = int.Parse(materialsCost.text);
        _goldCostInt = int.Parse(goldCost.text);
        _gemsCostInt = int.Parse(gemsCost.text);
    }

    private void CheckIfCanBuild()
    {
        if (_materialsCostInt > GameManager.Instance.GetMaterialsAmount() || _goldCostInt > GameManager.Instance.GetGoldAmount() || _gemsCostInt > GameManager.Instance.GetGemsAmount())
            costBlocker.gameObject.SetActive(true);
        else
            costBlocker.gameObject.SetActive(false);

        if (UIManager.Instance.selectedSprite == structureSelected.GetComponent<Image>().sprite)
            replaceBlocker.gameObject.SetActive(true);
        else
            replaceBlocker.gameObject.SetActive(false);
    }

    public void BuildStructure()
    {
        Instantiate(_structurePrefab, nodePosition, Quaternion.identity, nodesContainer);
        GameManager.Instance.RemoveMaterials(_materialsCostInt);
        GameManager.Instance.RemoveGold(_goldCostInt);
        GameManager.Instance.RemoveGems(_gemsCostInt);
        Destroy(UIManager.Instance.nodeSelected);
    }
}
