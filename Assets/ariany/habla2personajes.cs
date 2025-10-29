using UnityEngine;
using System.Collections;
using System.Collections.Generic; 
public class habla2personajes : MonoBehaviour
{
    // Lista para arrastrar a ambos personajes (NPC 1 y NPC 2)
    public List<Animator> npcAnimators;

    // El resto del código usa la etiqueta "Player" para que el jugador la active
    private const string TALKING_PARAM = "IsTalking";

    private void OnTriggerEnter(Collider other)
    {
        // Solo se activa si el JUGADOR (u otro objeto con Tag "Player") entra
        if (other.CompareTag("Player"))
        {
            foreach (Animator anim in npcAnimators)
            {
                if (anim != null)
                {
                    anim.SetBool(TALKING_PARAM, true);
                }
            }
            // Desactiva el Trigger para que la conversación no se reinicie
            GetComponent<Collider>().enabled = false;

            StartCoroutine(TerminarDeHablar(5f)); // Hablan por 5 segundos
        }
    }

    IEnumerator TerminarDeHablar(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);

        foreach (Animator anim in npcAnimators)
        {
            if (anim != null)
            {
                anim.SetBool(TALKING_PARAM, false);
            }
        }
        // Reactiva el Trigger
        GetComponent<Collider>().enabled = true;
    }
}

