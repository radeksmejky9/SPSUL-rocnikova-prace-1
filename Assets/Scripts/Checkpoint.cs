using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Teleport teleport;
    public Material material;

    private void OnTriggerEnter(Collider other)
    {
        teleport.checkpoint = gameObject;
        gameObject.GetComponent<MeshRenderer>().material = material;
    }
}
