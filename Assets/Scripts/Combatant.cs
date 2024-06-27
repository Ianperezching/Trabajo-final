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
            Debug.Log(stats.characterName + " has been defeated!");
        }
    }

    public void Attack(Combatant target)
    {
        target.TakeDamage(stats.attack);
    }

    public void SpecialAttack(Combatant[] enemies)
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].TakeDamage(stats.attack);
        }
    }

    public void Heal(Combatant target)
    {
        target.stats.currentHealth = Mathf.Min(target.stats.health, target.stats.currentHealth + stats.attack);
        Debug.Log(stats.characterName + " healed " + target.stats.characterName);
    }

    public void SpeedBoost(Combatant target)
    {
        target.stats.speed += stats.attack;
        Debug.Log(stats.characterName + " boosted speed of " + target.stats.characterName);
    }

    public int GetSpeed()
    {
        return stats.speed;
    }

    public string GetName()
    {
        return stats.characterName;
    }

    public void StartTurn(TurnManager turnManager)
    {
        turnManager.ShowPlayerOptions(this);
    }
}