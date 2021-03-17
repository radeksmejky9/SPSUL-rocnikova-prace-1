using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject player;
    public GameObject checkpoint;

    private void OnTriggerEnter(Collider other)
    {
        player.transform.position = checkpoint.transform.position;

    }
}
