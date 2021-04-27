using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject Player;
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(0);
    }
}
