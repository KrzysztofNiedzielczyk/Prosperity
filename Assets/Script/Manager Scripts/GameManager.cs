using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public ConfirmDemolishion confirmDemolishion;

    [SerializeField] private int _materials = 0;
    [SerializeField] private int _gold = 0;
    [SerializeField] private int _gems = 0;
    [SerializeField] private int _population = 10;

    public int selectedStructureMaterialsCost;
    public int selectedStructureGoldCost;
    public int selectedStructureGemsCost;

    public float halvedSelectedStructureMaterialsCost;
    public float halvedSelectedStructureGoldCost;
    public float halvedSelectedStructureGemsCost;

    public void SetSelectedStructureCost(int selectedMineralsCost, int selectedGoldCost, int selectedGemsCost)
    {
        selectedStructureMaterialsCost = selectedMineralsCost;
        selectedStructureGoldCost = selectedGoldCost;
        selectedStructureGemsCost = selectedGemsCost;

        halvedSelectedStructureMaterialsCost = Mathf.Round(selectedStructureMaterialsCost)/2;
        halvedSelectedStructureGoldCost = Mathf.Round(selectedStructureGoldCost)/2;
        halvedSelectedStructureGemsCost = Mathf.Round(selectedStructureGemsCost)/2;
    }

    public int GetMaterialsAmount()
    {
        return _materials;
    }

    public int GetGoldAmount()
    {
        return _gold;
    }

    public int GetGemsAmount()
    {
        return _gems;
    }
    public int GetPopulationAmount()
    {
        return _population;
    }


    public void AddMaterials(int materialsAmount)
    {
        _materials += materialsAmount;
    }

    public void AddGold(int goldAmount)
    {
        _gold += goldAmount;
    }

    public void AddGems(int gemAmount)
    {
        _gems += gemAmount;
    }

    public void AddPopulation(int poppulationAmount)
    {
        _population += poppulationAmount;
    }

    public void RemoveMaterials(int materialsCost)
    {
        _materials -= materialsCost;
    }

    public void RemoveGold(int goldCost)
    {
        _gold -= goldCost;
    }

    public void RemoveGems(int gemCost)
    {
        _gems -= gemCost;
    }

    public void RemovePopulation(int poppulationAmount)
    {
        _population -= poppulationAmount;
    }

    public void SetDemolishData()
    {
        confirmDemolishion.SetDemolishData(halvedSelectedStructureMaterialsCost, halvedSelectedStructureGoldCost, halvedSelectedStructureGemsCost);
    }
}
