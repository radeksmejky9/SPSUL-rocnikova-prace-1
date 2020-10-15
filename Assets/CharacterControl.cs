using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public float Speed;
    public Animator animator;

    void Start()
    {

    }


    void Update()
    {

        if (InputManager.Instance.Right || InputManager.Instance.Left || InputManager.Instance.Jump)
        {
            if (InputManager.Instance.Right)
            {
                this.gameObject.transform.Translate(Vector3.forward * Speed * Time.deltaTime);
                this.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                animator.SetBool("Move", true);
            }

            if (InputManager.Instance.Left)
            {
                this.gameObject.transform.Translate(Vector3.forward * Speed * Time.deltaTime);
                this.gameObject.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                animator.SetBool("Move", true);
            }

        }
        else
        {
            animator.SetBool("Move", false);

        }
    }

}
