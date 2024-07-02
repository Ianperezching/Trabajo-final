using UnityEngine;
using System.Collections;

public class EnemyCombatant : BaseCombatant
{
    public EnemyStats stats;
    private TurnManager turnManager;
    private AnimationController animationController;


    private void Awake()
    {
        animationController = GetComponent<AnimationController>();
    }
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
        TiemAnimation("RecibeDaño 0", true);
        int damageTaken = Mathf.Max(damage - stats.defense, 0);
        stats.currentHealth -= damageTaken;
        if (stats.currentHealth <= 0)
        {
            
            Debug.Log(stats.enemyName + " has been defeated!");
            Destroy(this);
        }
    }

    public void Attack(BaseCombatant target)
    {
        StartCoroutine(TiemAnimation("NormalAtack", true));
        Combatant combatant = (Combatant)target;
       combatant.TakeDamage(stats.attack);

    }

    private IEnumerator TiemAnimation(string Name, bool State)
    {
        animationController.PlayAnimacion(Name, State);
        yield return new WaitForSeconds(2);
        animationController.PlayAnimacion(Name, false);

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
        animationController.PlayAnimacion("Idle", true);
        turnManager.ExecuteEnemyTurn(this);
    }
}