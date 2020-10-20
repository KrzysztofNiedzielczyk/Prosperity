using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm2 : MonoBehaviour
{
    public int materialAmount = 10;
    public int popAmount = 2;

    public float perSeconds = 10f;

    private int phase = 0;
    public int popPerPhase = 6;

    private void Start()
    {
        StartCoroutine(AddResource(materialAmount, popAmount));
    }

    IEnumerator AddResource(int materialAmount, int popAmount)
    {
        while (true)
        {
            phase++;
            yield return new WaitForSeconds(perSeconds);
            GameManager.Instance.AddMaterials(materialAmount);
            if (phase >= popPerPhase)
            {
                GameManager.Instance.AddPopulation(popAmount);
                phase = 0;
            }
        }
    }
}
