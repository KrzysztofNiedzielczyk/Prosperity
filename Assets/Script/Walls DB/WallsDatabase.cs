using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsDatabase : MonoSingleton<WallsDatabase>
{
    public List<Walls> wallsDatabaseList = new List<Walls>();
}
