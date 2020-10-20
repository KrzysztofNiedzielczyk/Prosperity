using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEnemyTroopDetails : MonoBehaviour
{
    public Transform container;

    private void Update()
    {
        for (int i = 0; i < EnemyTroops.Instance.enemyUnits.Count; i++)
        {
            if (EnemyTroops.Instance.enemyUnits[i].unitCount > 0)
            {
                for (int j = 0; j < container.childCount; j++)
                {
                    if (container.GetChild(j).GetComponent<BattleEnemySlotTemplate>().unitID == EnemyTroops.Instance.enemyUnits[i].unitID)
                    {
                        container.GetChild(j).gameObject.SetActive(true);
                        container.GetChild(j).GetComponent<BattleEnemySlotTemplate>().unitAmount = EnemyTroops.Instance.enemyUnits[i].unitCount;
                    }
                }
            }
        }
    }
}
