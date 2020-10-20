using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsPanel : MonoBehaviour
{
    public Transform firstLayer;
    public Transform secondLayer;
    public Transform thirdLayer;

    private void Update()
    {
        if (firstLayer.Find("Purchased_Blockers_Development").GetChild(0).gameObject.activeInHierarchy)
            secondLayer.Find("Blockers_Development").GetChild(0).gameObject.SetActive(false);
        else
            secondLayer.Find("Blockers_Development").GetChild(0).gameObject.SetActive(true);

        if (secondLayer.Find("Purchased_Blockers_Development").GetChild(0).gameObject.activeInHierarchy)
            thirdLayer.Find("Blockers_Development").GetChild(0).gameObject.SetActive(false);
        else
            thirdLayer.Find("Blockers_Development").GetChild(0).gameObject.SetActive(true);
    }
}
