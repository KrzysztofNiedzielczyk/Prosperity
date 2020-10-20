using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StructureDatabase : MonoSingleton<StructureDatabase>
{
    public List<Structure> structureDatabaseList = new List<Structure>();
    //public Dictionary<Sprite, Structure> structureObjectstoStructure = new Dictionary<Sprite, Structure>();

    //private void Start()
    //{
    //    structureObjectstoStructure = Instance.structureDatabaseList.ToDictionary(i => i.icon, i => i);
    //}
}
