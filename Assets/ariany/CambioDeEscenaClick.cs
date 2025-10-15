using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioDeEscenaClick : MonoBehaviour
{
    [Header("Nombre exacto de la escena a cargar")]
    public string nombreEscena; // Escribe el nombre exacto de la escena destino

    void OnMouseDown()
    {
        Debug.Log("Puerta clickeada, cambiando de escena...");
        SceneManager.LoadScene(nombreEscena);
    }
}