using UnityEngine;
using UnityEngine.SceneManagement;

public class Cambio : MonoBehaviour
{
    public string escenaACargar;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Mano")
        {
            SceneManager.LoadScene(escenaACargar);
        }
    }
}