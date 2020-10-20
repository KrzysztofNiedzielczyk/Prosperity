using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quarry1 : MonoBehaviour
{
    public int materialAmount = 20;

    public float perSeconds = 10f;

    private int phase = 0;

    private void Start()
    {
        StartCoroutine(AddResource(materialAmount));
    }

    IEnumerator AddResource(int materialAmount)
    {
        while (true)
        {
            phase++;
            yield return new WaitForSeconds(perSeconds);
            GameManager.Instance.AddMaterials(materialAmount);
        }
    }
}
