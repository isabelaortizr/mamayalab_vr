using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;

public class NPCAnimator : MonoBehaviour
{
    private NavMeshAgent agente;
    private Animator animador;

    
    private const string PARAM_IS_WALKING = "IsWalking";

    // Opcional: para alternar entre diferentes animaciones de "Parado" (idle)
    // private const string PARAM_IDLE_INDEX = "IdleIndex"; 

    void Start()
    {
        // Obtener los dos componentes esenciales
        agente = GetComponent<NavMeshAgent>();
        animador = GetComponent<Animator>();

        if (agente == null || animador == null)
        {
            // Línea corregida: especificamos que es el Debug de Unity
            UnityEngine.Debug.LogError("Error: Faltan componentes NavMeshAgent o Animator en el NPC.");
            enabled = false; // Desactiva el script si falta algo
        }
    }

    void Update()
    {
        // 1. Obtener la velocidad actual del NavMeshAge      
        float velocidad = agente.velocity.magnitude;

        // 2. Determinar si el NPC está "caminando     
        bool estaCaminando = velocidad > 0.1f;

        // 3. Establecer el parámetro booleano en el Animator
        animador.SetBool(PARAM_IS_WALKING, estaCaminando);
    }
}