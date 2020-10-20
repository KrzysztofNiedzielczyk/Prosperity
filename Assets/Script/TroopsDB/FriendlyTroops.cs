using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyTroops : MonoSingleton<FriendlyTroops>
{
    public List<Troop> friendlyTroops = new List<Troop>();

    void Start()
    {
        for (int i = 0; i < FriendlyTroopsDatabase.Instance.friendlyInfantryDatabase.Count; i++)
            friendlyTroops.Add(new Troop());
        for (int i = 0; i < FriendlyTroopsDatabase.Instance.friendlyRiderDatabase.Count; i++)
            friendlyTroops.Add(new Troop());
        for (int i = 0; i < FriendlyTroopsDatabase.Instance.friendlyShooterDatabase.Count; i++)
            friendlyTroops.Add(new Troop());
        for (int i = 0; i < FriendlyTroopsDatabase.Instance.friendlyMachineDatabase.Count; i++)
            friendlyTroops.Add(new Troop());
        for (int i = 0; i < FriendlyTroopsDatabase.Instance.friendlySpecialDatabase.Count; i++)
            friendlyTroops.Add(new Troop());

        foreach (Infantry unit in FriendlyTroopsDatabase.Instance.friendlyInfantryDatabase)
        {
            friendlyTroops[unit.id - 1].unitID = unit.id;
            friendlyTroops[unit.id - 1].unitName = unit.unitName;
        }
        foreach (Rider unit in FriendlyTroopsDatabase.Instance.friendlyRiderDatabase)
        {
            friendlyTroops[unit.id - 1].unitID = unit.id;
            friendlyTroops[unit.id - 1].unitName = unit.unitName;
        }
        foreach (Shooter unit in FriendlyTroopsDatabase.Instance.friendlyShooterDatabase)
        {
            friendlyTroops[unit.id - 1].unitID = unit.id;
            friendlyTroops[unit.id - 1].unitName = unit.unitName;
        }
        foreach (Machine unit in FriendlyTroopsDatabase.Instance.friendlyMachineDatabase)
        {
            friendlyTroops[unit.id - 1].unitID = unit.id;
            friendlyTroops[unit.id - 1].unitName = unit.unitName;
        }
        foreach (SpecialFriendly unit in FriendlyTroopsDatabase.Instance.friendlySpecialDatabase)
        {
            friendlyTroops[unit.id - 1].unitID = unit.id;
            friendlyTroops[unit.id - 1].unitName = unit.unitName;
        }
    }

    public void AddUnit(int unitID, int unitAmount)
    {
        for (int i = 0; i < friendlyTroops.Count; i++)
        {
            if(friendlyTroops[i].unitID == unitID)
            {
                friendlyTroops[i].unitCount += unitAmount;
            }
        }
    }

    public void RemoveUnit(int unitID, int unitAmount)
    {
        for (int i = 0; i < friendlyTroops.Count; i++)
        {
            if (friendlyTroops[i].unitID == unitID)
            {
                friendlyTroops[i].unitCount -= unitAmount;
            }
        }
    }
}
