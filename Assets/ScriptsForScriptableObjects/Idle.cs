using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "Smejkyy/Idle")]
public class Idle : StateData
{
    public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {

    }

    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {

    }

    public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        CharacterControl characterControl = characterState.GetCharacterControl(animator);

        if (characterControl.Jump)
        {
            animator.SetBool("Jump", true);
        }

        if (characterControl.RunLeft)
        {
            characterControl.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            if (!FrontCheck(characterControl))
            {
                animator.SetBool("Run", true);
            }
        }
        if (characterControl.RunRight)
        {
            characterControl.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            if (!FrontCheck(characterControl))
            {
                animator.SetBool("Run", true);
            }
        }

        if (characterControl.Shift)
        {
            animator.SetBool("Shift", true);
        }
        if (characterControl.Shoot)
        {
            animator.SetBool("Shoot", true);
        }
    }


    bool FrontCheck(CharacterControl control)
    {
        foreach (GameObject o in control.FrontColliders)
        {
            Debug.DrawRay(o.transform.position, control.transform.forward * 0.7f, Color.red);
            RaycastHit hit;
            if (Physics.Raycast(o.transform.position, control.transform.forward, out hit, 0.1f))
            {
                return true;
            }
        }
        return false;
    }

}
