using UnityEngine;
using System.Collections;

public class ActivarHabla : MonoBehaviour
{
    public Animator npcAnimator;

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Activa la animación de Hablar
            npcAnimator.SetBool("IsTalking", true);

            // Inicia una Corrutina para que el NPC hable por un tiempo fijo
            StartCoroutine(TerminarDeHablar(5f));
        }
    }

    IEnumerator TerminarDeHablar(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);

        npcAnimator.SetBool("IsTalking", false);
    }
}
