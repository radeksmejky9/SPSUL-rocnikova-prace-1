﻿using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "Smejkyy/Land")]
public class Land : StateData
{
    public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        animator.SetBool("Jump", false);
    }

    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {

    }

    public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        CharacterControl characterControl = characterState.GetCharacterControl(animator);

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
