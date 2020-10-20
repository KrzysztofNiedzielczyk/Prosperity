using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyTroopsDatabase : MonoSingleton<FriendlyTroopsDatabase>
{
    public List<Infantry> friendlyInfantryDatabase = new List<Infantry>();
    public List<Rider> friendlyRiderDatabase = new List<Rider>();
    public List<Shooter> friendlyShooterDatabase = new List<Shooter>();
    public List<Machine> friendlyMachineDatabase = new List<Machine>();
    public List<SpecialFriendly> friendlySpecialDatabase = new List<SpecialFriendly>();
}