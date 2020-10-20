using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleFriendlyTroopsDetails : MonoBehaviour
{
    public Transform container;

    private void Update()
    {
        for(int i = 0; i < FriendlyTroops.Instance.friendlyTroops.Count; i++)
        {
            if(FriendlyTroops.Instance.friendlyTroops[i].unitCount > 0)
            {
                for(int j = 0; j < container.childCount; j++)
                {
                    if (container.GetChild(j).GetComponent<BattleUnitSlotTemplate>().unitID == FriendlyTroops.Instance.friendlyTroops[i].unitID)
                    {
                        container.GetChild(j).gameObject.SetActive(true);
                        container.GetChild(j).GetComponent<BattleUnitSlotTemplate>().unitAmount = FriendlyTroops.Instance.friendlyTroops[i].unitCount;
                    }
                }
            }
        }
    }
}
