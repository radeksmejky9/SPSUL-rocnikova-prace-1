using UnityEngine;

public class ManualInput : MonoBehaviour
{
    private CharacterControl characterControl;
    private void Awake()
    {
        characterControl = this.gameObject.GetComponent<CharacterControl>();
    }
    void Start()
    {

    }

    void Update()
    {
        if (InputManager.Instance.Left)
        {
            characterControl.RunLeft = true;
        }
        else
        {
            characterControl.RunLeft = false;
        }

        if (InputManager.Instance.Right)
        {
            characterControl.RunRight = true;
        }
        else
        {
            characterControl.RunRight = false;
        }

        if (InputManager.Instance.Jump)
        {
            characterControl.Jump = true;
        }
        else
        {
            characterControl.Jump = false;
        }

        if (InputManager.Instance.Shift)
        {
            characterControl.Shift = true;
        }
        else
        {
            characterControl.Shift = false;
        }
        if (InputManager.Instance.Shoot)
        {
            characterControl.Shoot = true;
        }
        else
        {
            characterControl.Shoot = false;
        }
    }
}
