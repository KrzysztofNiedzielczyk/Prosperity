using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmWallsPanel : MonoBehaviour
{
    public TextMeshProUGUI materialsCost;
    public TextMeshProUGUI goldCost;
    public TextMeshProUGUI gemsCost;
    public Transform wallsSelected;

    public Image costBlocker;

    private int _materialsCostInt;
    private int _goldCostInt;
    private int _gemsCostInt;
    private float _wallsDefence;

    private Transform _devParent;
    private int _devIndex;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        CheckIfCanBuild();
    }

    public void SetData(Sprite icon, int materialsValue, int goldValue, int gemsValue, float wallsDef, Transform parent, int index)
    {
        wallsSelected.GetComponent<Image>().sprite = icon;
        materialsCost.text = materialsValue.ToString();
        goldCost.text = goldValue.ToString();
        gemsCost.text = gemsValue.ToString();

        _materialsCostInt = materialsValue;
        _goldCostInt = goldValue;
        _gemsCostInt = gemsValue;
        _wallsDefence = wallsDef;
        _devParent = parent;
        _devIndex = index;
    }

    private void CheckIfCanBuild()
    {
        if (_materialsCostInt > GameManager.Instance.GetMaterialsAmount() || _goldCostInt > GameManager.Instance.GetGoldAmount() || _gemsCostInt > GameManager.Instance.GetGemsAmount())
            costBlocker.gameObject.SetActive(true);
        else
            costBlocker.gameObject.SetActive(false);
    }

    public void BuildWalls()
    {
        _devParent.Find("Purchased_Blockers_Development").GetChild(_devIndex).gameObject.SetActive(true);
        GameManager.Instance.RemoveMaterials(_materialsCostInt);
        GameManager.Instance.RemoveGold(_goldCostInt);
        GameManager.Instance.RemoveGems(_gemsCostInt);
        BattleManager.Instance.friendlyDefenceBonus += _wallsDefence;
    }
}
