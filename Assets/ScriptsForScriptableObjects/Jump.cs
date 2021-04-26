using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "Smejkyy/Jump")]
public class Jump : StateData
{
    public float JumpForce;
    public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        if (animator.GetBool("Jump"))
        {
            characterState.GetCharacterControl(animator).RIGID_BODY.AddForce(Vector3.up * JumpForce);
        }
    }

    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {

    }

    public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        CharacterControl characterControl = characterState.GetCharacterControl(animator);
        if (characterControl.Shoot)
        {
            animator.SetBool("Shoot", true);
        }
        if (characterControl.Shift)
        {
            animator.SetBool("Shift", true);
        }
        else
        {
            animator.SetBool("Shift", false);
        }
    }


}
