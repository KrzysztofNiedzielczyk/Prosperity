using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tent : MonoBehaviour
{
    public int popAmount = 2;

    public float perSeconds = 10f;

    private int phase = 0;

    private void Start()
    {
        StartCoroutine(AddResource(popAmount));
    }

    IEnumerator AddResource(int popAmount)
    {
        while (true)
        {
            phase++;
            yield return new WaitForSeconds(perSeconds);
            GameManager.Instance.AddPopulation(popAmount);
        }
    }
}
