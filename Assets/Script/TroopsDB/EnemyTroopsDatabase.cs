using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTroopsDatabase : MonoSingleton<EnemyTroopsDatabase>
{
    public List<Unit> enemyUnitNeutralDatabase = new List<Unit>();
    public List<Unit> enemyUnitMenaceDatabase = new List<Unit>();
}
