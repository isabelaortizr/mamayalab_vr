using UnityEngine;
using System.Collections;

public class OficinistaSentado : MonoBehaviour
{
    [Tooltip("Tiempo de pausa entre que el NPC empieza a hablar y se detiene.")]
    public float tiempoMaximoDeCharla = 4f;

    [Tooltip("Tiempo de pausa entre el final del habla y el inicio de la siguiente.")]
    public float tiempoMaximoDeEspera = 5f;

    private Animator animador;
    private const string PARAM_IS_TALKING = "IsTalking";

    // Variable para almacenar el índice de la capa TalkingLayer
    private int talkingLayerIndex;

    void Start()
    {
        animador = GetComponent<Animator>();

        if (animador == null)
        {
            UnityEngine.Debug.LogError("El personaje sentado necesita un componente Animator.");
            enabled = false;
            return;
        }

        // Obtener el índice de la capa TalkingLayer (debe llamarse "TalkingLayer" en el Animator)
        talkingLayerIndex = animador.GetLayerIndex("TalkingLayer");

        if (talkingLayerIndex < 0)
        {
            UnityEngine.Debug.LogError("ERROR: No se encontró la capa 'TalkingLayer' en el Animator. Verifica el nombre.");
            enabled = false;
            return;
        }

        // Desactivar la capa al inicio para asegurar que el personaje está quieto
        animador.SetLayerWeight(talkingLayerIndex, 0f);

        StartCoroutine(CicloDeCharla());
    }

    IEnumerator CicloDeCharla()
    {
        while (true)
        {
            // 1. PERIODO DE ESPERA (Callado/Escuchando)
            float tiempoDeEsperaActual = UnityEngine.Random.Range(2f, tiempoMaximoDeEspera);

            // DESACTIVA EL HABLA y BAJA EL PESO DE LA CAPA (peso de la máscara a 0)
            animador.SetBool(PARAM_IS_TALKING, false);
            animador.SetLayerWeight(talkingLayerIndex, 0f);

            yield return new WaitForSeconds(tiempoDeEsperaActual);

            // 2. PERIODO DE HABLA
            float tiempoDeCharlaActual = UnityEngine.Random.Range(1f, tiempoMaximoDeCharla);

            // ACTIVA EL HABLA y SUBE EL PESO DE LA CAPA (peso de la máscara a 1)
            animador.SetLayerWeight(talkingLayerIndex, 1f);
            animador.SetBool(PARAM_IS_TALKING, true);

            yield return new WaitForSeconds(tiempoDeCharlaActual);
        }
    }
}