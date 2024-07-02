using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayAnimacion(string Name,bool State)
    {
        animator.SetBool(Name, State);
    }

}