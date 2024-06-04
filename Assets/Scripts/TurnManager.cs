using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public List<Combatant> playerCombatants = new List<Combatant>();
    public List<EnemyCombatant> enemyCombatants = new List<EnemyCombatant>();

    private int currentTurnIndex = 0;

    private void Start()
    {
        var allCombatants = new List<object>();
        allCombatants.AddRange(playerCombatants);
        allCombatants.AddRange(enemyCombatants);
        //allCombatants = allCombatants.OrderByDescending(c => GetSpeed(c)).ToList();

        StartTurn(allCombatants);
    }

    private int GetSpeed(object combatant)
    {
        if (combatant is Combatant)
            return ((Combatant)combatant).stats.speed;
        else if (combatant is EnemyCombatant)
            return ((EnemyCombatant)combatant).stats.speed;
        return 0;
    }

    private void StartTurn(List<object> allCombatants)
    {
        if (allCombatants.Count > 0)
        {
            var currentCombatant = allCombatants[currentTurnIndex];
            if (currentCombatant is Combatant)
            {
                Combatant player = (Combatant)currentCombatant;
                Debug.Log("It's " + player.stats.characterName + "'s turn!");
            }
            else if (currentCombatant is EnemyCombatant)
            {
                EnemyCombatant enemy = (EnemyCombatant)currentCombatant;
                Debug.Log("It's " + enemy.stats.enemyName + "'s turn!");
            }
        }
    }

    public void EndTurn(List<object> allCombatants)
    {
        currentTurnIndex = (currentTurnIndex + 1) % allCombatants.Count;
        StartTurn(allCombatants);
    }

}
