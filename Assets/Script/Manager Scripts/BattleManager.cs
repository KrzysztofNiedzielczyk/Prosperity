using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoSingleton<BattleManager>
{
    public bool battleHomeActive = false;

    public List<float> friendlyDmgList;
    public List<float> enemyDmgList;

    public List<Troop> friendlyBattleUnitsList;
    public List<Troop> enemyBattleUnitsList;

    private bool _isCoroutineStarted = false;

    public float friendlyDefenceBonus = 0f;
    public float enemyDefenceBonus = 0f;




    private bool _isExpeditionCoroutineStarted = false;

    public bool battleExpeditionActive = false;

    public List<float> friendlyExpDmgList;
    public List<float> enemyExpDmgList;

    public List<Troop> friendlyExpBattleUnitsList;
    public List<Troop> enemyExpBattleUnitsList;




    private void Update()
    {
        CheckIfBattleHome();
    }

    public void CheckIfBattleHome()
    {

        for (int i = 0; i < EnemyTroops.Instance.enemyUnits.Count; i++)
        {
            if (EnemyTroops.Instance.enemyUnits[i].unitCount > 0)
            {
                battleHomeActive = true;

                //display battle icon

                if (!_isCoroutineStarted)
                    StartCoroutine(Battle());

                break;
            }
        }
    }

    public void CheckIfBattleExpedition()
    {

        for (int i = 0; i < EnemyExpTroops.Instance.enemyExpUnits.Count; i++)
        {
            if (EnemyExpTroops.Instance.enemyExpUnits[i].unitCount > 0)
            {
                battleExpeditionActive = true;

                if (!_isExpeditionCoroutineStarted)
                    StartCoroutine(BattleExpedition());

                break;
            }
        }
    }

    //BATTLE AT HOME
    ////////////////
    ////////////////
    IEnumerator Battle()
    {
        _isCoroutineStarted = true;

        //wait until battle starts
        yield return new WaitForSeconds(10f);

        //RANGED PHASE
        for (int j = 0; j < 2; j++)
        {
            //clear damage and units battle lists
            friendlyDmgList = new List<float>(0);
            enemyBattleUnitsList = new List<Troop>(0);

            //update friendly ranged units dmg list
            foreach (Troop troop in FriendlyTroops.Instance.friendlyTroops)
            {
                if (troop.unitCount > 0)
                {
                    foreach (Unit unit in FriendlyTroopsDatabase.Instance.friendlyShooterDatabase)
                    {
                        if (unit.id == troop.unitID)
                        {
                            friendlyDmgList.Add(unit.damage * troop.unitCount);
                        }
                    }
                    foreach (Unit unit in FriendlyTroopsDatabase.Instance.friendlyMachineDatabase)
                    {
                        if (unit.id == troop.unitID)
                        {
                            friendlyDmgList.Add(unit.damage * troop.unitCount);
                        }
                    }
                }
            }
            //update enemy units battle list
            foreach (Troop troop in EnemyTroops.Instance.enemyUnits)
            {
                if (troop.unitCount > 0)
                {
                    foreach (Unit unit in EnemyTroopsDatabase.Instance.enemyUnitNeutralDatabase)
                    {
                        if (unit.id == troop.unitID)
                        {
                            enemyBattleUnitsList.Add(new Troop(unit.id, troop.unitCount));
                        }
                    }
                    foreach (Unit unit in EnemyTroopsDatabase.Instance.enemyUnitMenaceDatabase)
                    {
                        if (unit.id == troop.unitID)
                        {
                            enemyBattleUnitsList.Add(new Troop(unit.id, troop.unitCount));
                        }
                    }
                }
            }

            //find random enemy unit and calculate damage
            for (int i = 0; i < friendlyDmgList.Count; i++)
            {
                int x = Random.Range(0, enemyBattleUnitsList.Count);
                while (enemyBattleUnitsList[x].unitCount <= 0)
                {
                    x = Random.Range(0, enemyBattleUnitsList.Count);
                }

                foreach (Troop troop in EnemyTroops.Instance.enemyUnits)
                {
                    if (troop.unitID == enemyBattleUnitsList[x].unitID)
                    {
                        troop.Damage(friendlyDmgList[i], 1);
                    }
                }
            }

            yield return new WaitForSeconds(10f);
        }

        //MAIN BATTLE

        while (true)
        {
            //clear damage and units battle lists at the beginning of turn
            friendlyDmgList = new List<float>(0);
            enemyDmgList = new List<float>(0);
            friendlyBattleUnitsList = new List<Troop>(0);
            enemyBattleUnitsList = new List<Troop>(0);

            //update friendly units battle list
            foreach (Troop troop in FriendlyTroops.Instance.friendlyTroops)
            {
                if(troop.unitCount > 0)
                {
                    //involve only meelee to fight and calculate all damage
                    foreach (Unit unit in FriendlyTroopsDatabase.Instance.friendlyInfantryDatabase)
                    {
                        if (unit.id == troop.unitID)
                        {
                            friendlyDmgList.Add(unit.damage * troop.unitCount);
                            friendlyBattleUnitsList.Add(new Troop(unit.id, troop.unitCount));
                        }
                    }
                    foreach (Unit unit in FriendlyTroopsDatabase.Instance.friendlyRiderDatabase)
                    {
                        if (unit.id == troop.unitID)
                        {
                            friendlyDmgList.Add(unit.damage * troop.unitCount);
                            friendlyBattleUnitsList.Add(new Troop(unit.id, troop.unitCount));
                        }
                    }

                    foreach (Unit unit in FriendlyTroopsDatabase.Instance.friendlyShooterDatabase)
                    {
                        if (unit.id == troop.unitID)
                        {
                            friendlyDmgList.Add(unit.damage * troop.unitCount);
                        }
                    }
                    foreach (Unit unit in FriendlyTroopsDatabase.Instance.friendlyMachineDatabase)
                    {
                        if (unit.id == troop.unitID)
                        {
                            friendlyDmgList.Add(unit.damage * troop.unitCount);
                        }
                    }
                    foreach (Unit unit in FriendlyTroopsDatabase.Instance.friendlySpecialDatabase)
                    {
                        if (unit.id == troop.unitID)
                        {
                            friendlyDmgList.Add(unit.damage * troop.unitCount);
                        }
                    }

                    //involve shooters and specials to fight
                    if (friendlyBattleUnitsList.Count <= 0)
                    {
                        foreach (Unit unit in FriendlyTroopsDatabase.Instance.friendlyShooterDatabase)
                        {
                            if (unit.id == troop.unitID)
                            {
                                friendlyBattleUnitsList.Add(new Troop(unit.id, troop.unitCount));
                            }
                        }
                        foreach (Unit unit in FriendlyTroopsDatabase.Instance.friendlyMachineDatabase)
                        {
                            if (unit.id == troop.unitID)
                            {
                                friendlyBattleUnitsList.Add(new Troop(unit.id, troop.unitCount));
                            }
                        }
                        foreach (Unit unit in FriendlyTroopsDatabase.Instance.friendlySpecialDatabase)
                        {
                            if (unit.id == troop.unitID)
                            {
                                friendlyBattleUnitsList.Add(new Troop(unit.id, troop.unitCount));
                            }
                        }
                    }
                }

                //involve population to fight
                if (friendlyBattleUnitsList.Count <= 0)
                {
                    friendlyBattleUnitsList.Add(new Troop("Population", GameManager.Instance.GetPopulationAmount(), GameManager.Instance.GetPopulationAmount() / 4));
                    friendlyDmgList.Add(friendlyBattleUnitsList[0].damage);
                }
            }
            //update enemy units battle list
            foreach (Troop troop in EnemyTroops.Instance.enemyUnits)
            {
                if (troop.unitCount > 0)
                {
                    foreach (Unit unit in EnemyTroopsDatabase.Instance.enemyUnitNeutralDatabase)
                    {
                        if (unit.id == troop.unitID)
                        {
                            enemyDmgList.Add(unit.damage * troop.unitCount);
                            enemyBattleUnitsList.Add(new Troop(unit.id, troop.unitCount));
                        }
                    }
                    foreach (Unit unit in EnemyTroopsDatabase.Instance.enemyUnitMenaceDatabase)
                    {
                        if (unit.id == troop.unitID)
                        {
                            enemyDmgList.Add(unit.damage * troop.unitCount);
                            enemyBattleUnitsList.Add(new Troop(unit.id, troop.unitCount));
                        }
                    }
                }
            }

            //find random unit and calculate damage
            //friendly damage
            for (int i = 0; i < friendlyDmgList.Count; i++)
            {
                int x = Random.Range(0, enemyBattleUnitsList.Count);
                while (enemyBattleUnitsList[x].unitCount <= 0)
                {
                    x = Random.Range(0, enemyBattleUnitsList.Count);
                }
                        
                foreach (Troop troop in EnemyTroops.Instance.enemyUnits)
                {
                    if (troop.unitID == enemyBattleUnitsList[x].unitID)
                    {
                        troop.Damage(friendlyDmgList[i], 1);
                    }
                }
            }
            //enemy damage
            if (friendlyBattleUnitsList.Count > 0)
            {
                for (int i = 0; i < enemyDmgList.Count; i++)
                {
                    int x = Random.Range(0, friendlyBattleUnitsList.Count);
                    while (friendlyBattleUnitsList[x].unitCount <= 0)
                    {
                        x = Random.Range(0, friendlyBattleUnitsList.Count);
                    }

                    foreach (Troop troop in FriendlyTroops.Instance.friendlyTroops)
                    {
                        if (troop.unitID == friendlyBattleUnitsList[x].unitID)
                        {
                            troop.Damage(enemyDmgList[i], 0);
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < enemyDmgList.Count; i++)
                {
                    GameManager.Instance.RemovePopulation(Mathf.CeilToInt(enemyDmgList[i] - (enemyDmgList[i] * friendlyDefenceBonus)));
                }
            }

            //stop battle if no enemy
            if (enemyBattleUnitsList.Count <= 0)
            {
                battleHomeActive = false;
                _isCoroutineStarted = false;

                //deactivate battle icon

                yield break;
            }

            //stop battle if no population

            yield return new WaitForSeconds(10f);
        }
    }

    //BATTLE EXPEDITION
    ///////////////////
    ///////////////////
    IEnumerator BattleExpedition()
    {
        _isExpeditionCoroutineStarted = true;

        //wait until battle starts
        yield return new WaitForSeconds(10f);

        //RANGED PHASE
        for (int j = 0; j < 1; j++)
        {
            //clear damage and units battle lists
            friendlyExpDmgList = new List<float>(0);
            enemyExpBattleUnitsList = new List<Troop>(0);

            //update friendly ranged units dmg list
            foreach (Troop troop in FriendlyExpTroops.Instance.friendlyExpTroops)
            {
                if (troop.unitCount > 0)
                {
                    foreach (Unit unit in FriendlyTroopsDatabase.Instance.friendlyShooterDatabase)
                    {
                        if (unit.id == troop.unitID)
                        {
                            friendlyExpDmgList.Add(unit.damage * troop.unitCount);
                        }
                    }
                    foreach (Unit unit in FriendlyTroopsDatabase.Instance.friendlyMachineDatabase)
                    {
                        if (unit.id == troop.unitID)
                        {
                            friendlyExpDmgList.Add(unit.damage * troop.unitCount);
                        }
                    }
                }
            }
            //update enemy units battle list
            foreach (Troop troop in EnemyExpTroops.Instance.enemyExpUnits)
            {
                if (troop.unitCount > 0)
                {
                    foreach (Unit unit in EnemyTroopsDatabase.Instance.enemyUnitNeutralDatabase)
                    {
                        if (unit.id == troop.unitID)
                        {
                            enemyExpBattleUnitsList.Add(new Troop(unit.id, troop.unitCount));
                        }
                    }
                    foreach (Unit unit in EnemyTroopsDatabase.Instance.enemyUnitMenaceDatabase)
                    {
                        if (unit.id == troop.unitID)
                        {
                            enemyExpBattleUnitsList.Add(new Troop(unit.id, troop.unitCount));
                        }
                    }
                }
            }

            //find random enemy unit and calculate damage
            for (int i = 0; i < friendlyExpDmgList.Count; i++)
            {
                int x = Random.Range(0, enemyExpBattleUnitsList.Count);
                while (enemyExpBattleUnitsList[x].unitCount <= 0)
                {
                    x = Random.Range(0, enemyExpBattleUnitsList.Count);
                }

                foreach (Troop troop in EnemyExpTroops.Instance.enemyExpUnits)
                {
                    if (troop.unitID == enemyExpBattleUnitsList[x].unitID)
                    {
                        troop.Damage(friendlyDmgList[i], 1);
                    }
                }
            }

            yield return new WaitForSeconds(10f);
        }

        //MAIN BATTLE

        while (true)
        {
            //clear damage and units battle lists at the beginning of turn
            friendlyExpDmgList = new List<float>(0);
            enemyExpDmgList = new List<float>(0);
            friendlyExpBattleUnitsList = new List<Troop>(0);
            enemyExpBattleUnitsList = new List<Troop>(0);

            //update friendly units battle list
            foreach (Troop troop in FriendlyExpTroops.Instance.friendlyExpTroops)
            {
                if (troop.unitCount > 0)
                {
                    //involve only meelee to fight and calculate all damage
                    foreach (Unit unit in FriendlyTroopsDatabase.Instance.friendlyInfantryDatabase)
                    {
                        if (unit.id == troop.unitID)
                        {
                            friendlyExpDmgList.Add(unit.damage * troop.unitCount);
                            friendlyExpBattleUnitsList.Add(new Troop(unit.id, troop.unitCount));
                        }
                    }
                    foreach (Unit unit in FriendlyTroopsDatabase.Instance.friendlyRiderDatabase)
                    {
                        if (unit.id == troop.unitID)
                        {
                            friendlyExpDmgList.Add(unit.damage * troop.unitCount);
                            friendlyExpBattleUnitsList.Add(new Troop(unit.id, troop.unitCount));
                        }
                    }

                    foreach (Unit unit in FriendlyTroopsDatabase.Instance.friendlyShooterDatabase)
                    {
                        if (unit.id == troop.unitID)
                        {
                            friendlyExpDmgList.Add(unit.damage * troop.unitCount);
                        }
                    }
                    foreach (Unit unit in FriendlyTroopsDatabase.Instance.friendlyMachineDatabase)
                    {
                        if (unit.id == troop.unitID)
                        {
                            friendlyExpDmgList.Add(unit.damage * troop.unitCount);
                        }
                    }
                    foreach (Unit unit in FriendlyTroopsDatabase.Instance.friendlySpecialDatabase)
                    {
                        if (unit.id == troop.unitID)
                        {
                            friendlyExpDmgList.Add(unit.damage * troop.unitCount);
                        }
                    }

                    //involve shooters and specials to fight
                    if (friendlyExpBattleUnitsList.Count <= 0)
                    {
                        foreach (Unit unit in FriendlyTroopsDatabase.Instance.friendlyShooterDatabase)
                        {
                            if (unit.id == troop.unitID)
                            {
                                friendlyExpBattleUnitsList.Add(new Troop(unit.id, troop.unitCount));
                            }
                        }
                        foreach (Unit unit in FriendlyTroopsDatabase.Instance.friendlyMachineDatabase)
                        {
                            if (unit.id == troop.unitID)
                            {
                                friendlyExpBattleUnitsList.Add(new Troop(unit.id, troop.unitCount));
                            }
                        }
                        foreach (Unit unit in FriendlyTroopsDatabase.Instance.friendlySpecialDatabase)
                        {
                            if (unit.id == troop.unitID)
                            {
                                friendlyExpBattleUnitsList.Add(new Troop(unit.id, troop.unitCount));
                            }
                        }
                    }
                }
            }
            //update enemy units battle list
            foreach (Troop troop in EnemyExpTroops.Instance.enemyExpUnits)
            {
                if (troop.unitCount > 0)
                {
                    foreach (Unit unit in EnemyTroopsDatabase.Instance.enemyUnitNeutralDatabase)
                    {
                        if (unit.id == troop.unitID)
                        {
                            enemyExpDmgList.Add(unit.damage * troop.unitCount);
                            enemyExpBattleUnitsList.Add(new Troop(unit.id, troop.unitCount));
                        }
                    }
                    foreach (Unit unit in EnemyTroopsDatabase.Instance.enemyUnitMenaceDatabase)
                    {
                        if (unit.id == troop.unitID)
                        {
                            enemyExpDmgList.Add(unit.damage * troop.unitCount);
                            enemyExpBattleUnitsList.Add(new Troop(unit.id, troop.unitCount));
                        }
                    }
                }
            }

            //find random unit and calculate damage
            //friendly damage
            for (int i = 0; i < friendlyExpDmgList.Count; i++)
            {
                int x = Random.Range(0, enemyExpBattleUnitsList.Count);
                while (enemyExpBattleUnitsList[x].unitCount <= 0)
                {
                    x = Random.Range(0, enemyExpBattleUnitsList.Count);
                }

                foreach (Troop troop in EnemyExpTroops.Instance.enemyExpUnits)
                {
                    if (troop.unitID == enemyExpBattleUnitsList[x].unitID)
                    {
                        troop.Damage(friendlyExpDmgList[i], 1);
                    }
                }
            }
            //enemy damage
            if (friendlyExpBattleUnitsList.Count > 0)
            {
                for (int i = 0; i < enemyExpDmgList.Count; i++)
                {
                    int x = Random.Range(0, friendlyExpBattleUnitsList.Count);
                    while (friendlyExpBattleUnitsList[x].unitCount <= 0)
                    {
                        x = Random.Range(0, friendlyExpBattleUnitsList.Count);
                    }

                    foreach (Troop troop in FriendlyExpTroops.Instance.friendlyExpTroops)
                    {
                        if (troop.unitID == friendlyExpBattleUnitsList[x].unitID)
                        {
                            troop.Damage(enemyExpDmgList[i], 0);
                        }
                    }
                }
            }

            //stop battle if no enemy
            if (enemyExpBattleUnitsList.Count <= 0)
            {
                battleExpeditionActive = false;
                _isExpeditionCoroutineStarted = false;

                yield break;
            }

            //stop battle if no friendly troops

            yield return new WaitForSeconds(10f);
        }
    }
}
