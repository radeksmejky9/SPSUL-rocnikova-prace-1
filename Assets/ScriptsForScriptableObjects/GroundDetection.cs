using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "Smejkyy/GroundDetection")]
public class GroundDetection : StateData
{
    public float Distance;
    public float checkTime;
    public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {

    }

    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {

    }

    public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        CharacterControl control = characterState.GetCharacterControl(animator);


        if (IsGrounded(control))
        {
            animator.SetBool("Grounded", true);

        }
        else
        {
            animator.SetBool("Grounded", false);
        }

    }

    bool IsGrounded(CharacterControl control)
    {
        if (control.RIGID_BODY.velocity.y > -0.01f && control.RIGID_BODY.velocity.y < 0.01f)
        {
            return true;
        }
        foreach (GameObject o in control.BottomColliders)
        {
            Debug.DrawRay(o.transform.position, -Vector3.up * 0.7f, Color.red);
            RaycastHit hit;
            if (Physics.Raycast(o.transform.position, -Vector3.up, out hit, Distance))
            {
                return true;
            }
        }
        return false;
    }


}
