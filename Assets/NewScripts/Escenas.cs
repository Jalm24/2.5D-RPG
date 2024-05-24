using UnityEngine;
using UnityEngine.SceneManagement;

public class Escenas : MonoBehaviour {
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && this.gameObject.CompareTag("Trap"))
        {
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }
    }
}