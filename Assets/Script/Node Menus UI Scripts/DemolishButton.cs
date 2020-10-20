using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemolishButton : MonoBehaviour
{
    public GameObject emptyTilePrefab;
    public Vector3 nodePosition;
    public Transform nodesContainer;

    public void DestroyStructure()
    {
        Instantiate(emptyTilePrefab, nodePosition, Quaternion.identity, nodesContainer);
        Destroy(UIManager.Instance.nodeSelected);
    }
}
