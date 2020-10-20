using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Vector3 objPosition;

    void Start()
    {
        objPosition = gameObject.transform.position;
    }

    private void OnDestroy()
    {
        float materialsCost = GameManager.Instance.halvedSelectedStructureMaterialsCost;
        float goldCost = GameManager.Instance.halvedSelectedStructureGoldCost;
        float gemsCost = GameManager.Instance.halvedSelectedStructureGemsCost;

        GameManager.Instance.AddMaterials(Mathf.FloorToInt(materialsCost));
        GameManager.Instance.AddGold(Mathf.FloorToInt(goldCost));
        GameManager.Instance.AddGems(Mathf.FloorToInt(gemsCost));
    }
}