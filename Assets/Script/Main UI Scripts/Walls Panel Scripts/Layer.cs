using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layer : MonoBehaviour
{
    private Transform _devPurachasedPanel;
    private Transform _devBlockerPanel;
    private Transform _upgradeBlockerPanel;

    private void Start()
    {
        _devPurachasedPanel = transform.Find("Purchased_Blockers_Development");
        _devBlockerPanel = transform.Find("Blockers_Development");
        _upgradeBlockerPanel = transform.Find("Blockers_Upgrades");
    }

    private void Update()
    {
        foreach(Transform child in _devBlockerPanel)
        {
            int x = child.GetSiblingIndex();

            if (x > 0)
            {
                if (_devBlockerPanel.GetChild(x - 1).gameObject.activeInHierarchy)
                    child.gameObject.SetActive(true);

                if (_devPurachasedPanel.GetChild(x - 1).gameObject.activeInHierarchy)
                    child.gameObject.SetActive(false);
                else
                    child.gameObject.SetActive(true);
            }
        }

        foreach (Transform child in _upgradeBlockerPanel)
        {
            int x = child.GetSiblingIndex();

            if (_devPurachasedPanel.GetChild(2*x+1).gameObject.activeInHierarchy)
                child.gameObject.SetActive(false);
            else
                child.gameObject.SetActive(true);
        }
    }
}
