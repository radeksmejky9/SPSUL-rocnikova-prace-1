using UnityEngine;

public class rock : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other == GameObject.FindGameObjectWithTag("MainCharacter").GetComponent<BoxCollider>())
        {
            other.GetComponent<DamageDetector>().TakeDamage(3);
        }
    }
}
