using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public Combatant[] playerCombatants;
    public EnemyCombatant[] enemyCombatants;
    private MyPriorityQueue<Combatant> priorityQueue = new MyPriorityQueue<Combatant>();

    private void Start()
    {
        for (int i = 0; i < playerCombatants.Length; i++)
        {
            priorityQueue.PriorityEnqueue(playerCombatants[i], playerCombatants[i].GetSpeed());
        }
        for (int i = 0; i < enemyCombatants.Length; i++)
        {
           // priorityQueue.PriorityEnqueue(enemyCombatants[i], enemyCombatants[i].GetSpeed());
        }

        StartTurn();
    }

    private void StartTurn()
    {
        if (!priorityQueue.IsEmpty())
        {
            Combatant currentCombatant = priorityQueue.PriorityDequeue();
            Debug.Log("It's " + currentCombatant.GetName() + "'s turn!");
            currentCombatant.StartTurn(this);
        }
    }

    public void ShowPlayerOptions(Combatant player)
    {
        // Aquí se mostraría la UI con botones para las opciones de ataque
        Debug.Log("1: Normal Attack  2: Special Attack");

        // Ejemplo de opciones manuales (en lugar de UI real)
        int choice = Random.Range(1, 3);
        if (choice == 1)
        {
           // player.Attack(enemyCombatants[0]);
        }
        else if (choice == 2)
        {
            Combatant[] enemies = new Combatant[enemyCombatants.Length];
            for (int i = 0; i < enemyCombatants.Length; i++)
            {
                //enemies[i] = enemyCombatants[i];
            }
            player.SpecialAttack(enemies);
        }

        EndTurn(player);
    }

    public void ExecuteEnemyTurn(EnemyCombatant enemy)
    {
        Combatant target = playerCombatants[Random.Range(0, playerCombatants.Length)];
        enemy.Attack(target);
        EndTurn(enemy);
    }

    private void EndTurn(Combatant combatant)
    {
        priorityQueue.PriorityEnqueue(combatant, combatant.GetSpeed());
        StartTurn();
    }

    private void EndTurn(EnemyCombatant enemy)
    {
       // priorityQueue.PriorityEnqueue(enemy, enemy.GetSpeed());
        StartTurn();
    }
}