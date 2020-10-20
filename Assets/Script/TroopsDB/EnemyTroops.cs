using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTroops : MonoSingleton<EnemyTroops>
{
    public List<Troop> enemyUnits = new List<Troop>();

    void Start()
    {
        for (int i = 0; i < EnemyTroopsDatabase.Instance.enemyUnitNeutralDatabase.Count; i++)
            enemyUnits.Add(new Troop());
        for (int i = 0; i < EnemyTroopsDatabase.Instance.enemyUnitMenaceDatabase.Count; i++)
            enemyUnits.Add(new Troop());

        foreach (Unit unit in EnemyTroopsDatabase.Instance.enemyUnitNeutralDatabase)
        {
            enemyUnits[unit.id - 1].unitID = unit.id;
            enemyUnits[unit.id - 1].unitName = unit.unitName;
        }
        foreach (Unit unit in EnemyTroopsDatabase.Instance.enemyUnitMenaceDatabase)
        {
            enemyUnits[unit.id - 1].unitID = unit.id;
            enemyUnits[unit.id - 1].unitName = unit.unitName;
        }
    }

    public void AddUnit(int unitID, int unitAmount)
    {
        for (int i = 0; i < enemyUnits.Count; i++)
        {
            if (enemyUnits[i].unitID == unitID)
            {
                enemyUnits[i].unitCount += unitAmount;
            }
        }
    }

    public void RemoveUnit(int unitID, int unitAmount)
    {
        for (int i = 0; i < enemyUnits.Count; i++)
        {
            if (enemyUnits[i].unitID == unitID)
            {
                enemyUnits[i].unitCount -= unitAmount;
            }
        }
    }
}
