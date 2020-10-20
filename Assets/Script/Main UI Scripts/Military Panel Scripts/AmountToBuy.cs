using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmountToBuy : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public int amount = 0;

    private void Start()
    {
        textMeshPro.text = amount.ToString();
    }

    public void Add()
    {
        amount += 1;
        textMeshPro.text = amount.ToString();
    }

    public void Add2()
    {
        amount += 10;
        textMeshPro.text = amount.ToString();
    }

    public void Subtract()
    {
        if(amount > 0)
        {
            amount -= 1;
            textMeshPro.text = amount.ToString();
        }
    }

    public void Subtract2()
    {
        if (amount < 10 && amount > 0)
        {
            amount -= amount;
            textMeshPro.text = amount.ToString();
        }
        if (amount >= 10)
        {
            amount -= 10;
            textMeshPro.text = amount.ToString();
        }
    }

    public void Zero()
    {
        if (amount > 0)
        {
            amount = 0;
            textMeshPro.text = amount.ToString();
        }
    }
}