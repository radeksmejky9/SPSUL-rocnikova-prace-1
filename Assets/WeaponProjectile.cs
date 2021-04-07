using UnityEngine;

public class WeaponProjectile : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<DamageDetector>().TakeDamage(20);
    }

}
