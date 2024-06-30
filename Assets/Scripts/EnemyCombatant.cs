using UnityEngine;

public class EnemyCombatant : BaseCombatant
{
    public EnemyStats stats;
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
            Debug.Log(stats.enemyName + " has been defeated!");
        }
    }

    public void Attack(BaseCombatant target)
    {
        if (target is Combatant)
        {
            Combatant combatant = (Combatant)target;
            combatant.TakeDamage(stats.attack);
        }
    }

    public override int GetSpeed()
    {
        return stats.speed;
    }

    public override string GetName()
    {
        return stats.enemyName;
    }

    public override void StartTurn(TurnManager turnManager)
    {
        turnManager.ExecuteEnemyTurn(this);
    }
}