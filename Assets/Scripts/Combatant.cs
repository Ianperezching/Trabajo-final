using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combatant : MonoBehaviour
{
    public CharacterStats stats;

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
            // Handle character death
            Debug.Log(stats.characterName + " has been defeated!");
        }
    }

    public void Attack(Combatant target)
    {
        target.TakeDamage(stats.attack);
    }
}
