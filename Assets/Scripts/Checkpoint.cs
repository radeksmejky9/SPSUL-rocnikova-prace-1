using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Teleport teleport;
    public GameObject checkpoint;
    private void OnTriggerEnter(Collider other)
    {
        teleport.checkpoint = this.checkpoint;
    }
}
