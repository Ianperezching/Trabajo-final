using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombatant : MonoBehaviour
{
    public EnemyStats stats;

    private void Start()
    {
        stats.currentHealth = stats.health;
    }

    public void TakeDamage(int damage)
    {
        int damageTaken = Mathf.Max(damage - stats.defense, 0);
        stats.currentHealth -= damageTaken;
        if (stats.currentHealth <= 0)
        {
            Debug.Log(stats.enemyName + " has been defeated!");
        }
    }

    public void Attack(Combatant target)
    {
        target.TakeDamage(stats.attack);
    }

    public int GetSpeed()
    {
        return stats.speed;
    }

    public string GetName()
    {
        return stats.enemyName;
    }

    public void StartTurn(TurnManager turnManager)
    {
        turnManager.ExecuteEnemyTurn(this);
    }
}