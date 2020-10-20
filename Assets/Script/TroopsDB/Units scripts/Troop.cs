using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Troop
{
    public string unitName;
    public int unitCount; 
    public int unitID;
    public float damage;

    public Troop()
    {

    }

    public Troop(int id)
    {
        unitID = id;
    }

    public Troop(int id, int count)
    {
        unitID = id;
        unitCount = count;
    }
    
    public Troop(string name, int count, float dmg)
    {
        unitName = name;
        unitCount = count;
        damage = dmg;
    }


    public void Damage(float dmg, int side)
    {
        if(side == 0)
        {
            for (int i = 0; i < FriendlyTroopsDatabase.Instance.friendlyInfantryDatabase.Count; i++)
            {
                if (unitID == FriendlyTroopsDatabase.Instance.friendlyInfantryDatabase[i].id)
                {
                    damage += dmg - (dmg * (FriendlyTroopsDatabase.Instance.friendlyInfantryDatabase[i].defence + BattleManager.Instance.friendlyDefenceBonus));
                    if (damage >= FriendlyTroopsDatabase.Instance.friendlyInfantryDatabase[i].health)
                    {
                        unitCount -= Mathf.FloorToInt(damage / FriendlyTroopsDatabase.Instance.friendlyInfantryDatabase[i].health);
                        damage = 0;
                    }
                }
            }
            for (int i = 0; i < FriendlyTroopsDatabase.Instance.friendlyRiderDatabase.Count; i++)
            {
                if (unitID == FriendlyTroopsDatabase.Instance.friendlyRiderDatabase[i].id)
                {
                    damage += dmg - (dmg * (FriendlyTroopsDatabase.Instance.friendlyRiderDatabase[i].defence + BattleManager.Instance.friendlyDefenceBonus));
                    if (damage >= FriendlyTroopsDatabase.Instance.friendlyRiderDatabase[i].health)
                    {
                        unitCount -= Mathf.FloorToInt(damage / FriendlyTroopsDatabase.Instance.friendlyRiderDatabase[i].health);
                        damage = 0;
                    }
                }
            }
            for (int i = 0; i < FriendlyTroopsDatabase.Instance.friendlyShooterDatabase.Count; i++)
            {
                if (unitID == FriendlyTroopsDatabase.Instance.friendlyShooterDatabase[i].id)
                {
                    damage += dmg - ((dmg * FriendlyTroopsDatabase.Instance.friendlyShooterDatabase[i].defence + BattleManager.Instance.friendlyDefenceBonus));
                    if (damage >= FriendlyTroopsDatabase.Instance.friendlyShooterDatabase[i].health)
                    {
                        unitCount -= Mathf.FloorToInt(damage / FriendlyTroopsDatabase.Instance.friendlyShooterDatabase[i].health);
                        damage = 0;
                    }
                }
            }
            for (int i = 0; i < FriendlyTroopsDatabase.Instance.friendlyMachineDatabase.Count; i++)
            {
                if (unitID == FriendlyTroopsDatabase.Instance.friendlyMachineDatabase[i].id)
                {
                    damage += dmg - ((dmg * FriendlyTroopsDatabase.Instance.friendlyMachineDatabase[i].defence + BattleManager.Instance.friendlyDefenceBonus));
                    if (damage >= FriendlyTroopsDatabase.Instance.friendlyMachineDatabase[i].health)
                    {
                        unitCount -= Mathf.FloorToInt(damage / FriendlyTroopsDatabase.Instance.friendlyMachineDatabase[i].health);
                        damage = 0;
                    }
                }
            }
            for (int i = 0; i < FriendlyTroopsDatabase.Instance.friendlySpecialDatabase.Count; i++)
            {
                if (unitID == FriendlyTroopsDatabase.Instance.friendlySpecialDatabase[i].id)
                {
                    damage += dmg - ((dmg * FriendlyTroopsDatabase.Instance.friendlySpecialDatabase[i].defence + BattleManager.Instance.friendlyDefenceBonus));
                    if (damage >= FriendlyTroopsDatabase.Instance.friendlySpecialDatabase[i].health)
                    {
                        unitCount -= Mathf.FloorToInt(damage / FriendlyTroopsDatabase.Instance.friendlySpecialDatabase[i].health);
                        damage = 0;
                    }
                }
            }
        }
        
        if(side == 1)
        {
            for (int i = 0; i < EnemyTroopsDatabase.Instance.enemyUnitNeutralDatabase.Count; i++)
            {
                if (unitID == EnemyTroopsDatabase.Instance.enemyUnitNeutralDatabase[i].id)
                {
                    damage += dmg - ((dmg * EnemyTroopsDatabase.Instance.enemyUnitNeutralDatabase[i].defence + BattleManager.Instance.enemyDefenceBonus));
                    if (damage >= EnemyTroopsDatabase.Instance.enemyUnitNeutralDatabase[i].health)
                    {
                        unitCount -= Mathf.FloorToInt(damage / EnemyTroopsDatabase.Instance.enemyUnitNeutralDatabase[i].health);
                        damage = 0;
                    }
                }
            }
            for (int i = 0; i < EnemyTroopsDatabase.Instance.enemyUnitMenaceDatabase.Count; i++)
            {
                if (unitID == EnemyTroopsDatabase.Instance.enemyUnitMenaceDatabase[i].id)
                {
                    damage += dmg - ((dmg * EnemyTroopsDatabase.Instance.enemyUnitMenaceDatabase[i].defence + BattleManager.Instance.enemyDefenceBonus));
                    if (damage >= EnemyTroopsDatabase.Instance.enemyUnitMenaceDatabase[i].health)
                    {
                        unitCount -= Mathf.FloorToInt(damage / EnemyTroopsDatabase.Instance.enemyUnitMenaceDatabase[i].health);
                        damage = 0;
                    }
                }
            }
        }

        if (unitCount < 0)
        {
            unitCount = 0;
        }
    }
}
