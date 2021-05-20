using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{

    public List<GameObject> list;

    private void OnTriggerEnter(Collider other)
    {
        foreach (var sphere in list)
        {
            sphere.AddComponent<Rigidbody>();
            sphere.GetComponent<Rigidbody>().mass = 0.01f;
        }
    }
}
