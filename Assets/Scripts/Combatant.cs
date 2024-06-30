using UnityEngine;

public class Combatant : BaseCombatant
{
    public CharacterStats stats;
    private TurnManager turnManager;

    private void Start()
    {
        stats.currentHealth = stats.health;
    }

    public void SetTurnManager(TurnManager manager)
    {
        turnManager = manager;
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

    public void Attack(BaseCombatant target)
    {
        if (target is Combatant)
        {
            Combatant combatant = (Combatant)target;
            combatant.TakeDamage(stats.attack);
        }
        else if (target is EnemyCombatant)
        {
            EnemyCombatant enemy = (EnemyCombatant)target;
            enemy.TakeDamage(stats.attack);
        }
    }

    public void SpecialAttack(BaseCombatant[] enemies)
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] is EnemyCombatant)
            {
                EnemyCombatant enemyCombatant = (EnemyCombatant)enemies[i];
                enemyCombatant.TakeDamage(stats.attack);
            }
        }
    }

    public void Heal(BaseCombatant target)
    {
        if (target is Combatant)
        {
            Combatant combatant = (Combatant)target;
            combatant.stats.currentHealth = Mathf.Min(combatant.stats.health, combatant.stats.currentHealth + stats.attack);
            Debug.Log(stats.characterName + " healed " + combatant.stats.characterName);
        }
    }

    public void SpeedBoost(BaseCombatant target)
    {
        if (target is Combatant)
        {
            Combatant combatant = (Combatant)target;
            combatant.stats.speed += stats.attack;
            Debug.Log(stats.characterName + " boosted speed of " + combatant.stats.characterName);
        }
    }

    public override int GetSpeed()
    {
        return stats.speed;
    }

    public override string GetName()
    {
        return stats.characterName;
    }

    public override void StartTurn(TurnManager turnManager)
    {
        turnManager.ShowPlayerOptions(this);
    }
}