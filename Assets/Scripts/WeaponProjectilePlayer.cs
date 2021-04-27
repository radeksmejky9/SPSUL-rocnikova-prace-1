using UnityEngine;

public class WeaponProjectilePlayer : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyDamageDetector>().TakeDamage(20);
            Destroy(gameObject);
        }
        else
        {
            if (!other.CompareTag("MainCamera") || !other.CompareTag("MainCharacter"))
                Destroy(gameObject);
        }


    }



}
