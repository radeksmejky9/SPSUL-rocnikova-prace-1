using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "Smejkyy/Shoot")]
public class Shoot : StateData
{
    public GameObject projectile;
    public float fireRate;
    float nextFire;
    public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        nextFire = Time.time + fireRate;
    }

    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
    }

    public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {


        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            ShootProj(characterState, animator, stateInfo);
        }
        if (!characterState.GetCharacterControl(animator).Shoot)
            animator.SetBool("Shoot", false);

    }
    private void ShootProj(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        Transform gun = characterState.GetCharacterControl(animator).transform.Find("gun");
        Transform transform = characterState.GetCharacterControl(animator).GetComponent<BoxCollider>().transform;
        Vector3 t = new Vector3(gun.transform.transform.position.x, gun.transform.position.y, gun.transform.position.z);
        Rigidbody rb = Instantiate(projectile, t, Quaternion.identity).GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 0.07f, ForceMode.Impulse);

    }




}
