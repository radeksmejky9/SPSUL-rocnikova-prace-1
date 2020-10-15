using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingCube : MonoBehaviour
{
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (InputManager.Instance.Right)
        {
            this.gameObject.transform.Translate(Vector3.forward * Speed * Time.deltaTime);
            this.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        if (InputManager.Instance.Left)
        {
            this.gameObject.transform.Translate(Vector3.forward * Speed * Time.deltaTime);
            this.gameObject.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }
}
