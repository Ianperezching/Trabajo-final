using UnityEngine;

public class BaseCombatant : MonoBehaviour
{
    public virtual int GetSpeed()
    {
        return 0;
    }
    public virtual string GetName() 
    {
        return string.Empty;
    }
    public virtual void StartTurn(TurnManager turnManager)
    {

    }
}
