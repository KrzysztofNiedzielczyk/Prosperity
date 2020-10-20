using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemsMarket : MonoBehaviour
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
        int gemsAmount = GameManager.Instance.GetGemsAmount();
        int goldAmount = GameManager.Instance.GetGoldAmount();

        if (gemsAmount < 100)
        {
            costBlocker3.gameObject.SetActive(true);
            if (gemsAmount < 10)
            {
                costBlocker2.gameObject.SetActive(true);
                if (gemsAmount < 1)
                {
                    costBlocker1.gameObject.SetActive(true);
                }
            }
        }
        if (gemsAmount >= 1)
        {
            costBlocker1.gameObject.SetActive(false);
            if (gemsAmount >= 10)
            {
                costBlocker2.gameObject.SetActive(false);
                if (gemsAmount >= 100)
                {
                    costBlocker3.gameObject.SetActive(false);
                }
            }
        }

        if (goldAmount >= 1000)
        {
            costBlocker4.gameObject.SetActive(false);
            if (goldAmount >= 10000)
            {
                costBlocker5.gameObject.SetActive(false);
                if (goldAmount >= 100000)
                {
                    costBlocker6.gameObject.SetActive(false);
                }
            }
        }
        if (goldAmount < 100000)
        {
            costBlocker6.gameObject.SetActive(true);
            if (goldAmount < 10000)
            {
                costBlocker5.gameObject.SetActive(true);
                if (goldAmount < 1000)
                {
                    costBlocker4.gameObject.SetActive(true);
                }
            }
        }
    }
}
