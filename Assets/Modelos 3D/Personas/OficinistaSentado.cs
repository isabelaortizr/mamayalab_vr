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

    void Start()
    {
        animador = GetComponent<Animator>();

        if (animador == null)
        {
      
            UnityEngine.Debug.LogError("El personaje sentado necesita un componente Animator.");
            enabled = false;
            return;
        }

        StartCoroutine(CicloDeCharla());
    }

    IEnumerator CicloDeCharla()
    {
        while (true)
        {
            float tiempoDeEsperaActual = UnityEngine.Random.Range(2f, tiempoMaximoDeEspera);
            animador.SetBool(PARAM_IS_TALKING, false);
            yield return new WaitForSeconds(tiempoDeEsperaActual);

         
            float tiempoDeCharlaActual = UnityEngine.Random.Range(1f, tiempoMaximoDeCharla);
            animador.SetBool(PARAM_IS_TALKING, true);
            yield return new WaitForSeconds(tiempoDeCharlaActual);
        }
    }
}