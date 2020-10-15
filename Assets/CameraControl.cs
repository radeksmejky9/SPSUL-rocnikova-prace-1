using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float Speed;

    void Start()
    {

    }


    void Update()
    {

        if (InputManager.Instance.Right)
        {
            this.gameObject.transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        }

        if (InputManager.Instance.Left)
        {
            this.gameObject.transform.Translate(Vector3.forward * Speed * Time.deltaTime);

        }


    }

}
