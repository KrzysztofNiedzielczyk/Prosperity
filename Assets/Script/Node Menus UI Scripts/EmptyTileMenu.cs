using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyTileMenu : MonoBehaviour
{
    public BuildingMenu buildingMenu;
    public LocketTileMenu lockedTileMenu;

    public bool canChange;
    private void Start()
    {
        canChange = true;
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (buildingMenu.canChange || lockedTileMenu.canChange)
        {
            buildingMenu.Deactivate();
            lockedTileMenu.Deactivate();
        }
    }

    public void Activate()
    {
        canChange = false;
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        canChange = true;
        gameObject.SetActive(false);
    }

    public void ChangePosition(Vector3 objPosition)
    {
        gameObject.transform.localPosition = objPosition;
    }
}
