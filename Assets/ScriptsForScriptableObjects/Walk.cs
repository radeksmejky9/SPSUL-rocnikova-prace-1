﻿using UnityEngine;

[CreateAssetMenu(fileName = "NewState", menuName = "Smejkyy/Walk")]

public class Walk : StateData
{
    public AnimationCurve Graph;
    public float Speed;
    public float Distance;

    public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {

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
        if (FrontCheck(characterControl))
        {
            animator.SetBool("Run", false);
        }

        if (!characterControl.RunRight && !characterControl.RunLeft)
        {
            animator.SetBool("Run", false);
            return;
        }
        if (characterControl.RunRight && characterControl.RunLeft)
        {
            animator.SetBool("Run", false);
            return;
        }
        if (characterControl.Jump)
        {
            animator.SetBool("Jump", true);
        }

        if (characterControl.Shift)
        {
            animator.SetBool("Shift", true);
        }


        if (characterControl.RunLeft)
        {
            characterControl.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            if (!FrontCheck(characterControl))
            {
                characterControl.transform.Translate(Vector3.forward * Graph.Evaluate(stateInfo.normalizedTime) * Speed * Time.deltaTime);
            }
        }
        if (characterControl.RunRight)
        {
            characterControl.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            if (!FrontCheck(characterControl))
            {
                characterControl.transform.Translate(Vector3.forward * Graph.Evaluate(stateInfo.normalizedTime) * Speed * Time.deltaTime);
            }
        }

    }

    bool FrontCheck(CharacterControl control)
    {
        foreach (GameObject o in control.FrontColliders)
        {
            Debug.DrawRay(o.transform.position, control.transform.forward * 0.7f, Color.red);
            RaycastHit hit;
            if (Physics.Raycast(o.transform.position, control.transform.forward, out hit, Distance))
            {
                return true;
            }
        }
        return false;
    }
}
