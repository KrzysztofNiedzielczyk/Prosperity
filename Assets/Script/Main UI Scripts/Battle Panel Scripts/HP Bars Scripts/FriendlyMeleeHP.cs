using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FriendlyMeleeHP : MonoBehaviour
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
        for (int i = 0; i < 9; i++)
        {
            if (FriendlyTroops.Instance.friendlyTroops[i].unitID == FriendlyTroopsDatabase.Instance.friendlyInfantryDatabase[i].id)
                value += FriendlyTroops.Instance.friendlyTroops[i].unitCount * FriendlyTroopsDatabase.Instance.friendlyInfantryDatabase[i].health;
        }
        for (int i = 9; i < 14; i++)
        {
            if (FriendlyTroops.Instance.friendlyTroops[i].unitID == FriendlyTroopsDatabase.Instance.friendlyRiderDatabase[i-9].id)
                value += FriendlyTroops.Instance.friendlyTroops[i].unitCount * FriendlyTroopsDatabase.Instance.friendlyRiderDatabase[i-9].health;
        }
        return value;
    }
}
