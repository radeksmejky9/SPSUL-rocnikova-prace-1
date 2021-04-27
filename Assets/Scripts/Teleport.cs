using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject player;
    public GameObject checkpoint;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.root.gameObject == player)
        {
            player.transform.position = checkpoint.transform.position;
            player.GetComponent<DamageDetector>().TakeDamage(25);
        }

    }
}
