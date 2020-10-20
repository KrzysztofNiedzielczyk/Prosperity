using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour
{
    public int materialAmount = 10;
    public int goldAmount = 1;
    public int gemsAmount = 1;

    public float perSeconds = 10f;

    private int goldPhase = 0;
    private int gemsPhase = 0;
    public int goldPerPhase = 6;
    public int gemsPerPhase = 7;

    private void Start()
    {
        StartCoroutine(AddResource(materialAmount, goldAmount));
    }

    IEnumerator AddResource(int materialAmount, int goldAmount)
    {
        while (true)
        {
            goldPhase++;
            gemsPhase++;
            yield return new WaitForSeconds(perSeconds);
            GameManager.Instance.AddMaterials(materialAmount);
            if (goldPhase >= goldPerPhase)
            {
                GameManager.Instance.AddGold(goldAmount);
                goldPhase = 0;
            }
            if (gemsPhase >= gemsPerPhase)
            {
                GameManager.Instance.AddGems(gemsAmount);
                gemsPhase = 0;
            }
        }
    }
}
