using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;

public class UIManager : MonoSingleton<UIManager>
{
    public NodeMenu nodeMenu;

    public BuildingMenu buildingMenu;
    public EmptyTileMenu emptyTileMenu;
    public LocketTileMenu lockedTileMenu;

    public GameObject buildMenu;
    public ConfirmBuildingPanel confirmBuildingPanel;
    public Canvas nodeMenusCanva;
    public GameObject nodeSelected;
    public Sprite selectedSprite;
    public DemolishButton demolishButton;

    public ConfirmDemolishion confirmDemolishion;


    void Update()
    {
        DeactivateCanvas();

        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                if(!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                {
                    TouchOnNodeAction();
                }
            }
        }
    }

    void DeactivateCanvas()
    {
        if(buildMenu.activeInHierarchy)
        {
            nodeMenusCanva.gameObject.SetActive(false);
        }
        else
        {
            nodeMenusCanva.gameObject.SetActive(true);
        }
    }

    void TouchOnNodeAction()
    {
        Touch touch = Input.GetTouch(0);

        Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
        Vector2 touchPos2D = new Vector2(touchPos.x, touchPos.y);

        RaycastHit2D hit = Physics2D.Raycast(touchPos2D, Vector2.zero);

        var hitCollider = hit.collider;

        if (hitCollider == null)
        {
            buildingMenu.Deactivate();
            emptyTileMenu.Deactivate();
            lockedTileMenu.Deactivate();
        }

        if(!buildingMenu.gameObject.activeInHierarchy && !emptyTileMenu.gameObject.activeInHierarchy && !lockedTileMenu.gameObject.activeInHierarchy)
        {
            if (hitCollider != null)
            {
                if (!buildMenu.gameObject.activeInHierarchy)
                {
                    buildingMenu.Deactivate();
                    emptyTileMenu.Deactivate();
                    lockedTileMenu.Deactivate();

                    nodeSelected = hitCollider.gameObject;

                    selectedSprite = hitCollider.transform.GetComponent<SpriteRenderer>().sprite;
                    int index = StructureDatabase.Instance.structureDatabaseList.FindIndex(i => i.icon == selectedSprite);

                    GameManager.Instance.SetSelectedStructureCost(StructureDatabase.Instance.structureDatabaseList[index].materialsCost, StructureDatabase.Instance.structureDatabaseList[index].goldCost, StructureDatabase.Instance.structureDatabaseList[index].gemsCost);

                    buildMenu.GetComponent<BuildMenu>().currentPrefab = hitCollider.gameObject;
                    confirmBuildingPanel.nodePosition = hitCollider.gameObject.transform.position;
                    demolishButton.nodePosition = hitCollider.gameObject.transform.position;

                    if (hitCollider.CompareTag("Structure"))
                    {
                        Vector3 objPosition = hitCollider.gameObject.transform.localPosition;
                        if (buildingMenu.canChange)
                        {
                            nodeMenu.ChangePosition(objPosition);
                            buildingMenu.Activate();
                            buildingMenu.ChangePosition(objPosition);
                        }
                        else
                            buildingMenu.Deactivate();
                    }
                    else if (hitCollider.CompareTag("Empty_Tile"))
                    {
                        Vector3 objPosition = hitCollider.gameObject.transform.localPosition;
                        if (emptyTileMenu.canChange)
                        {
                            nodeMenu.ChangePosition(objPosition);
                            emptyTileMenu.Activate();
                            emptyTileMenu.ChangePosition(objPosition);
                        }
                        else
                            emptyTileMenu.Deactivate();
                    }
                    else if (hitCollider.CompareTag("Locked_Tile"))
                    {
                        Vector3 objPosition = hitCollider.gameObject.transform.localPosition;
                        if (lockedTileMenu.canChange)
                        {
                            nodeMenu.ChangePosition(objPosition);
                            lockedTileMenu.Activate();
                            lockedTileMenu.ChangePosition(objPosition);
                        }
                        else
                            lockedTileMenu.Deactivate();
                    }
                }
            }
        }
        else
        {
            buildingMenu.Deactivate();
            emptyTileMenu.Deactivate();
            lockedTileMenu.Deactivate();
        }
    }

    public void SetDemolishonIcon()
    {
        confirmDemolishion.SetDemolishIcon(selectedSprite);
    }
}
