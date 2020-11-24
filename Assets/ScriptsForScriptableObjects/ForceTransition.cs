using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "Smejkyy/ForceTransition")]
public class ForceTransition : StateData
{
    [Range(0.01f, 1f)]
    public float TransitionTiming;
    public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {

    }

    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {

    }

    public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        if (stateInfo.normalizedTime >= TransitionTiming)
        {
            animator.SetBool("ForceTransition", true);
        }

    }


}
