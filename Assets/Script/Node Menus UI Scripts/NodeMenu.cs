using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeMenu : MonoBehaviour
{
    public void ChangePosition(Vector3 objPosition)
    {
        gameObject.transform.localPosition = objPosition;
    }
}
