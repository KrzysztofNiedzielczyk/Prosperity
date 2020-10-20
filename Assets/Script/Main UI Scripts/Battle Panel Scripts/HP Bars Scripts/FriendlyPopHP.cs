using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FriendlyPopHP : MonoBehaviour
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
        value = GameManager.Instance.GetPopulationAmount();
        return value;
    }
}
