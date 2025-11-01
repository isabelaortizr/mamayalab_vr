
using UnityEngine; 

public class Inicializar : MonoBehaviour
{
    void Start()
    {
        if (SoundManager.Instance != null)
        {
            // INICIA EL AUDIO PRINCIPAL DE LA PRESENTACI�N
            SoundManager.Instance.PlayAudioPresentacion();

            float duracionReal = SoundManager.Instance.audioPresentacion.length;
            Invoke("IniciarMusica", duracionReal);
        }
        else
        {
            Debug.LogError("El SoundManager no se ha encontrado. Verifica que est� en la escena.");
        }
    }

    void IniciarMusica()
    {
        if (SoundManager.Instance != null)
        {
            SoundManager.Instance.PlayMusicaDeFondo();
        }
    }
}