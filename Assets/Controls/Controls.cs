﻿using UnityEngine;

public class Controls : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            InputManager.Instance.Jump = true;
        }
        else
        {
            InputManager.Instance.Jump = false;
        }

        if (!(Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A)))
        {
            if (Input.GetKey(KeyCode.D))
            {
                InputManager.Instance.Right = true;
            }
            else
            {
                InputManager.Instance.Right = false;
            }

            if (Input.GetKey(KeyCode.A))
            {
                InputManager.Instance.Left = true;
            }
            else
            {
                InputManager.Instance.Left = false;
            }
        }


    }
}
