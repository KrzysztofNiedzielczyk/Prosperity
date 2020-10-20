using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FriendlyRangedHP : MonoBehaviour
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
        for (int i = 14; i < 19; i++)
        {
            if (FriendlyTroops.Instance.friendlyTroops[i].unitID == FriendlyTroopsDatabase.Instance.friendlyShooterDatabase[i - 14].id)
                value += FriendlyTroops.Instance.friendlyTroops[i].unitCount * FriendlyTroopsDatabase.Instance.friendlyShooterDatabase[i - 14].health;
        }
        for (int i = 19; i < 22; i++)
        {
            if (FriendlyTroops.Instance.friendlyTroops[i].unitID == FriendlyTroopsDatabase.Instance.friendlyMachineDatabase[i - 19].id)
                value += FriendlyTroops.Instance.friendlyTroops[i].unitCount * FriendlyTroopsDatabase.Instance.friendlyMachineDatabase[i - 19].health;
        }
        for (int i = 22; i < 23; i++)
        {
            if (FriendlyTroops.Instance.friendlyTroops[i].unitID == FriendlyTroopsDatabase.Instance.friendlySpecialDatabase[i - 22].id)
                value += FriendlyTroops.Instance.friendlyTroops[i].unitCount * FriendlyTroopsDatabase.Instance.friendlySpecialDatabase[i - 22].health;
        }
        return value;
    }
}
