using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject Player;
    private void OnTriggerEnter(Collider other)
    {
        Player.transform.position = teleportTarget.transform.position;
        SceneManager.LoadScene(0);
    }
}
