using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnitsCostPanel : MonoBehaviour
{
    public Transform materialsCost;
    public Transform goldCost;
    public Transform gemsCost;
    public Transform populationCost;

    public TextMeshProUGUI _materialsCostTMP;
    public TextMeshProUGUI _goldCostTMP;
    public TextMeshProUGUI _gemsCostTMP;
    public TextMeshProUGUI _populationCostTMP;

    private int _materialsCost = 0;
    private int _goldCost = 0;
    private int _gemsCost = 0;
    private int _populationCost = 0;

    public Image costBlocker;

    public List<Troop> troopsToBuy = new List<Troop>();

    public Transform troopsPanelContainer;

    private void Start()
    {
        for(int i = 1; i < troopsPanelContainer.childCount; i++)
        {
            troopsToBuy.Add(new Troop());
        }
    }

    private void Update()
    {
        UpdateCost();
        CheckIfCanRecruit();
        CheckIfCostLessThen0();
        CalculateUnitToBuy();
    }

    public void AddCost(int materialsCost, int goldCost, int gemsCost, int populationCost)
    {
        _materialsCost += materialsCost;
        _goldCost += goldCost;
        _gemsCost += gemsCost;
        _populationCost += populationCost;
    }

    public void SubtractCost(int materialsCost, int goldCost, int gemsCost, int populationCost)
    {
        _materialsCost -= materialsCost;
        _goldCost -= goldCost;
        _gemsCost -= gemsCost;
        _populationCost -= populationCost;
    }

    public void UpdateCost()
    {
        _materialsCostTMP.text = _materialsCost.ToString();
        _goldCostTMP.text = _goldCost.ToString();
        _gemsCostTMP.text = _gemsCost.ToString();
        _populationCostTMP.text = _populationCost.ToString();
    }

    void CheckIfCostLessThen0()
    {
        if (_materialsCost < 0)
            _materialsCost = 0;
        if (_goldCost < 0)
            _goldCost = 0;
        if (_gemsCost < 0)
            _gemsCost = 0;
        if (_populationCost < 0)
            _populationCost = 0;
    }

    public void PayResources()
    {
        GameManager.Instance.RemoveMaterials(_materialsCost);
        GameManager.Instance.RemoveGold(_goldCost);
        GameManager.Instance.RemoveGems(_gemsCost);
        GameManager.Instance.RemovePopulation(_populationCost);
    }

    void CheckIfCanRecruit()
    {
        if (_materialsCost > GameManager.Instance.GetMaterialsAmount() || _goldCost > GameManager.Instance.GetGoldAmount() || _gemsCost > GameManager.Instance.GetGemsAmount() || _populationCost > GameManager.Instance.GetPopulationAmount())
            costBlocker.gameObject.SetActive(true);
        else
            costBlocker.gameObject.SetActive(false);
    }

    void CalculateUnitToBuy()
    {
        for(int i = 1; i < troopsPanelContainer.childCount; i++)
        {
            var template = troopsPanelContainer.GetChild(i).GetComponent<UnitSlotTemplate>();
            int count = template.amount;
            int id = template.unitId;
            troopsToBuy[i-1].unitCount = count;
            troopsToBuy[i-1].unitID = id;
        }
    }
}