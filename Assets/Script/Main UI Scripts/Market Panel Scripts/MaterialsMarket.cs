using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialsMarket : MonoBehaviour
{
    public GameObject costBlocker1;
    public GameObject costBlocker2;
    public GameObject costBlocker3;
    public GameObject costBlocker4;
    public GameObject costBlocker5;
    public GameObject costBlocker6;

    void Update()
    {
        SetBlockers();
    }

    void SetBlockers()
    {
        int materialsAmount = GameManager.Instance.GetMaterialsAmount();
        int goldAmount = GameManager.Instance.GetGoldAmount();

        if (materialsAmount < 1000000)
        {
            costBlocker3.gameObject.SetActive(true);
            if (materialsAmount < 100000)
            {
                costBlocker2.gameObject.SetActive(true);
                if (materialsAmount < 10000)
                {
                    costBlocker1.gameObject.SetActive(true);
                }
            }
        }
        if (materialsAmount >= 10000)
        {
            costBlocker1.gameObject.SetActive(false);
            if (materialsAmount >= 100000)
            {
                costBlocker2.gameObject.SetActive(false);
                if (materialsAmount >= 1000000)
                {
                    costBlocker3.gameObject.SetActive(false);
                }
            }
        }

        if (goldAmount >= 1)
        {
            costBlocker4.gameObject.SetActive(false);
            if (goldAmount >= 10)
            {
                costBlocker5.gameObject.SetActive(false);
                if (goldAmount >= 100)
                {
                    costBlocker6.gameObject.SetActive(false);
                }
            }
        }
        if(goldAmount < 100)
        {
            costBlocker6.gameObject.SetActive(true);
            if (goldAmount < 10)
            {
                costBlocker5.gameObject.SetActive(true);
                if (goldAmount < 1)
                {
                    costBlocker4.gameObject.SetActive(true);
                }
            }
        }
    }
}
