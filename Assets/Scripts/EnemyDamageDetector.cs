using UnityEngine;
using UnityEngine.AI;

public class EnemyDamageDetector : MonoBehaviour
{
    CharacterControl control;
    [SerializeField]
    public float hp;
    public GameObject gun;

    private void Awake()
    {
        control = GetComponent<CharacterControl>();
    }

    private void Update()
    {

    }


    public void TakeDamage(int amount)
    {
        if (this.hp - amount <= 0)
        {
            control.animator.SetBool("Dead", true);
            Destroy(gameObject.transform.root.gameObject.GetComponent<BoxCollider>());
            gameObject.GetComponent<NavMeshAgent>().enabled = false;
        }
        else
        {
            this.hp -= amount;
        }
    }

}
