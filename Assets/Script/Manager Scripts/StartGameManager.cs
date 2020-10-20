using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameManager : MonoSingleton<StartGameManager>
{
    public Transform nodesContainer;
    public GameObject[] startingPositionStructure;
    private Vector3[] _mapPositions = new Vector3[]
    {
        //Base locations
        new Vector3(0,0,0),
        new Vector3(1,1,0),
        new Vector3(1,-1,0),
        new Vector3(-1,-1,0),
        new Vector3(-1,1,0),
        new Vector3(0,2,0),
        new Vector3(2,0,0),
        new Vector3(0,-2,0),
        new Vector3(-2,0,0),

        //Right Up
        new Vector3(1,3,0),
        new Vector3(2,2,0),
        new Vector3(3,1,0),

        //Right
        new Vector3(4,0,0),

        //Right Down
        new Vector3(3,-1,0),
        new Vector3(2,-2,0),
        new Vector3(1,-3,0),

        //Left Down
        new Vector3(-1,-3,0),
        new Vector3(-2,-2,0),
        new Vector3(-3,-1,0),

        //Left
        new Vector3(-4,0,0),

        //Left Up
        new Vector3(-3,1,0),
        new Vector3(-2,2,0),
        new Vector3(-1,3,0)
    };

    void Start()
    {
        for (int i = 0; i < _mapPositions.Length; i++)
        {
            Instantiate(startingPositionStructure[i], _mapPositions[i], Quaternion.identity, nodesContainer);
        }
    }
}
