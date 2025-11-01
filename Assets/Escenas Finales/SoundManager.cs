
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance;
    private AudioSource musicSource;

    [Header("Clips de Audio de Presentación y Fondo")]
    //ARRASTRAR
    public AudioClip audioPresentacion;
    public AudioClip musicaDeFondo;
    public AudioClip audioFinalPresentacion;
    public AudioClip introduccionNarrada; 


    void Awake()
    {

        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        musicSource = GetComponent<AudioSource>();
        musicSource.playOnAwake = false;
        musicSource.loop = false;
    }


    public void PlayAudioPresentacion()
    {
        if (audioPresentacion != null)
        {
            //detener audio previo
            musicSource.Stop();
            musicSource.loop = false;
            musicSource.clip = audioPresentacion;
            musicSource.Play();
            Debug.Log("Reproduciendo Audio de Presentación.");
        }
        else
        {
            UnityEngine.Debug.LogWarning("El clip 'audioPresentacion' no está asignado en el Inspector.");
        }
    }


    public void PlayMusicaDeFondo()
    {
        if (musicaDeFondo != null)
        {
            musicSource.Stop();
            musicSource.clip = musicaDeFondo;
            musicSource.loop = true; // La música de fondo debe repetirse
            musicSource.Play();
            Debug.Log("Reproduciendo Música de Fondo.");
        }
    }


    public void PlayAudioFinal()
    {
        if (audioFinalPresentacion != null)
        {
            musicSource.loop = false;
            // PlayOneShot para que el clip de fondo pueda seguir reproduciéndose
            musicSource.PlayOneShot(audioFinalPresentacion);
        }
    }

    public void PlayIntroduccionNarrada()
    {
        if (introduccionNarrada != null)
        {
            // PlayOneShot para reproducir el clip sin cambiar el musicSource principal
            musicSource.PlayOneShot(introduccionNarrada);

            Debug.Log("Reproduciendo Introducción Narrada.");
        }
    }


    public void StopGlobalAudio()
    {
        musicSource.Stop();
    }
}