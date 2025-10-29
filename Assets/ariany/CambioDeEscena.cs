using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine.SceneManagement;


public class CambioDeEscena : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public string escena;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(escena);
        }
    }
    // Update is called once per frame
    void Update()
    {
        //2 scripts
        //cuando el jugador toque algo cambiar de escena (Ontriggerenter)
        //cuando el jugador toque un globo jugar efecto de particulas (Instantiate)

    }

}
