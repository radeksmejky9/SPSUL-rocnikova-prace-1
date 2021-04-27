using UnityEngine;

public class WeaponProjectileAI : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other == GameObject.FindGameObjectWithTag("MainCharacter").GetComponent<BoxCollider>())
        {
            other.GetComponent<DamageDetector>().TakeDamage(20);
            Destroy(gameObject);
        }
        else
        {
            if (!other.CompareTag("Enemy"))
                Destroy(gameObject);

        }


    }


}
