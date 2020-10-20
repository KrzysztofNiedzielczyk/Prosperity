using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigHut : MonoBehaviour
{
    public int materialAmount = 10;
    public int goldAmount = 1;

    public float perSeconds = 10f;

    private int phase = 0;
    public int goldPerPhase = 6;

    private void Start()
    {
        StartCoroutine(AddResource(materialAmount, goldAmount));
    }

    IEnumerator AddResource(int materialAmount, int goldAmount)
    {
        while (true)
        {
            phase++;
            yield return new WaitForSeconds(perSeconds);
            GameManager.Instance.AddMaterials(materialAmount);
            if (phase >= goldPerPhase)
            {
                GameManager.Instance.AddGold(goldAmount);
                phase = 0;
            }
        }
    }
}
