using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DamageDetector : MonoBehaviour
{
    CharacterControl control;
    [SerializeField]
    public Slider slider;
    public float hp;
    public TextMeshProUGUI text;

    private void Awake()
    {
        control = GetComponent<CharacterControl>();
    }

    private void Update()
    {
        slider.value = hp;
        text.text = hp + "";
        if (this.hp < 0 && control.animator.GetBool("Dead") == false)
        {
            control.animator.SetBool("Dead", true);
            this.gameObject.transform.root.gameObject.GetComponent<BoxCollider>().size = new Vector3(0.03682822f, 0.01f, 0.05451269f);
            this.gameObject.transform.root.gameObject.GetComponent<BoxCollider>().center = new Vector3(0.82f, 0.01f, 1f);
        }
    }


    public void TakeDamage(int amount)
    {
        if (this.hp - amount <= 0)
        {
            control.animator.SetBool("Dead", true);
            this.gameObject.transform.root.gameObject.GetComponent<BoxCollider>().size = new Vector3(0.03682822f, 0.01f, 0.05451269f);
            this.gameObject.transform.root.gameObject.GetComponent<BoxCollider>().center = new Vector3(0.82f, 0.01f, 1f);

            // SceneManager.LoadScene(0);
        }
        this.hp -= amount;
    }
}
