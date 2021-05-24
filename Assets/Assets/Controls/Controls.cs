using UnityEngine;

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

        if (Input.GetKey(KeyCode.LeftShift))
        {
            InputManager.Instance.Shift = true;
        }
        else
        {
            InputManager.Instance.Shift = false;
        }


        if (Input.GetKey(KeyCode.E))
        {
            InputManager.Instance.Shoot = true;
        }
        else
        {
            InputManager.Instance.Shoot = false;
        }
    }
}
