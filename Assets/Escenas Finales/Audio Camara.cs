using UnityEngine;
using System.Collections.Generic;

public class AudioCamara : MonoBehaviour
{
    [Header("Configuraci�n de Audio")]
    [Tooltip("Arrastra aqu� los clips de audio (MP3/WAV) en orden de reproducci�n. Debe ser de tama�o 10.")]
    public List<AudioClip> clipsDeAudio;

    private AudioSource audioSource;
    private int indiceAudioActual = 0; // Lleva la cuenta del audio que sigue

    void Awake()
    {
       
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

   
    public void ReproducirSiguienteAudio()
    {
    
        if (clipsDeAudio.Count == 0)
        {
            UnityEngine.Debug.LogWarning("La lista de clips de audio est� vac�a. No se puede reproducir.");
            return;
        }

        if (indiceAudioActual >= clipsDeAudio.Count)
        {
            UnityEngine.Debug.Log("Fin del recorrido de audios. Se reprodujeron todos los clips.");
            return;
        }

        
        AudioClip clipActual = clipsDeAudio[indiceAudioActual];

        
        audioSource.PlayOneShot(clipActual);

      
        UnityEngine.Debug.Log($"Reproduciendo audio {indiceAudioActual + 1}: {clipActual.name}");

        // Avanza al siguiente �ndice para la pr�xima llamada
        indiceAudioActual++;
    }
}
