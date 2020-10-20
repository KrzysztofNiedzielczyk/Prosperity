using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    public Slider slider;

    private void Update()
    {
        if (BattleManager.Instance.battleHomeActive == false)
        {
            slider.maxValue = SetValue();
            slider.value = SetValue();
        }
        else if (BattleManager.Instance.battleHomeActive == true)
            slider.value = SetValue();
    }

    public float SetValue()
    {
        float value = 0f;
        for (int i = 0; i < 25; i++)
        {
            if (EnemyTroops.Instance.enemyUnits[i].unitID == EnemyTroopsDatabase.Instance.enemyUnitNeutralDatabase[i].id)
                value += EnemyTroops.Instance.enemyUnits[i].unitCount * EnemyTroopsDatabase.Instance.enemyUnitNeutralDatabase[i].health;
        }
        for (int i = 25; i < 27; i++)
        {
            if (EnemyTroops.Instance.enemyUnits[i].unitID == EnemyTroopsDatabase.Instance.enemyUnitMenaceDatabase[i - 25].id)
                value += EnemyTroops.Instance.enemyUnits[i].unitCount * EnemyTroopsDatabase.Instance.enemyUnitMenaceDatabase[i - 25].health;
        }
        return value;
    }
}
