using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public Combatant[] playerCombatants;
    public EnemyCombatant[] enemyCombatants;
    public CombatantUI[] combatantUIs; 
    public MyPriorityQueue<BaseCombatant> priorityQueue = new MyPriorityQueue<BaseCombatant>();

    private void Start()
    {
        for (int i = 0; i < playerCombatants.Length; i++)
        {
            Combatant playerCombatant = playerCombatants[i];
            priorityQueue.PriorityEnqueue(playerCombatant, playerCombatant.GetSpeed());
            combatantUIs[i].Initialize(this, playerCombatant);
        }
        for (int i = 0; i < enemyCombatants.Length; i++)
        {
            EnemyCombatant enemyCombatant = enemyCombatants[i];
            priorityQueue.PriorityEnqueue(enemyCombatant, enemyCombatant.GetSpeed());
        }

        StartTurn();
    }

    private void StartTurn()
    {
        if (!priorityQueue.IsEmpty())
        {
            BaseCombatant currentCombatant = priorityQueue.PriorityDequeue();
            Debug.Log("It's " + currentCombatant.GetName() + "'s turn!");
            currentCombatant.StartTurn(this);
        }
    }

    public void ShowPlayerOptions(Combatant player)
    {
        HideAllUI();
        int index = System.Array.IndexOf(playerCombatants, player);
        if (index >= 0 && index < combatantUIs.Length)
        {
            combatantUIs[index].Show();
        }
    }

    public void ExecuteEnemyTurn(EnemyCombatant enemy)
    {
        int targetIndex = Random.Range(0, playerCombatants.Length);
        Combatant target = playerCombatants[targetIndex];
        enemy.Attack(target);
        EndTurn(enemy);
    }

    public void EndTurn(BaseCombatant combatant)
    {
        priorityQueue.PriorityEnqueue(combatant, combatant.GetSpeed() -2);
        StartTurn();
    }

    private void HideAllUI()
    {
        for (int i = 0; i < combatantUIs.Length; i++)
        {
            combatantUIs[i].Hide();
        }
    }
}