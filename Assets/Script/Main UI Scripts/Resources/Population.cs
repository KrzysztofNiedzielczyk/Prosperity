using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Population : MonoBehaviour
{
    private int _populationAmount;
    public Text amount;

    void Update()
    {
        _populationAmount = GameManager.Instance.GetPopulationAmount();
        amount.text = _populationAmount.ToString();
    }
}
