using UnityEngine;

public class EnemyDamageDetector : MonoBehaviour
{
    CharacterControl control;
    [SerializeField]
    public float hp;

    private void Awake()
    {
        control = GetComponent<CharacterControl>();
    }

    private void Update()
    {

        if (this.hp <= 0 && control.animator.GetBool("Dead") == false)
        {
            control.animator.SetBool("Dead", true);
            this.gameObject.transform.root.gameObject.GetComponent<BoxCollider>().isTrigger = true;
            this.gameObject.transform.root.gameObject.GetComponent<Rigidbody>().freezeRotation = true;

        }
    }


    public void TakeDamage(int amount)
    {
        if (this.hp - amount <= 0)
        {
            control.animator.SetBool("Dead", true);
            this.gameObject.transform.root.gameObject.GetComponent<BoxCollider>().isTrigger = true;
            this.gameObject.transform.root.gameObject.GetComponent<Rigidbody>().freezeRotation = true;
        }
        else
        {
            this.hp -= amount;
        }
    }
}
