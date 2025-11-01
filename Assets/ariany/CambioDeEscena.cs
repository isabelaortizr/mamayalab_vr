using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine.SceneManagement;


public class CambioDeEscena : MonoBehaviour
{
    public string escena;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(escena);
        }
    }

    void CambioForzado()
    {
        SceneManager.LoadScene(escena);
    }

}
