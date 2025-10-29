using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using System;
//using System.Diagnostics;

public class NPC_script: MonoBehaviour
{
    [Header("Configuración de Movimiento")]
    [Tooltip("El rango máximo desde el punto de inicio para elegir un destino.")]
    public float rangoDeBusqueda = 15f;

    [Tooltip("Tiempo de espera entre la elección de nuevos destinos (Cada X tiempo).")]
    public float tiempoDeEspera = 5f;

    [Tooltip("Distancia que el agente debe alcanzar para considerar que llegó.")]
    public float distanciaDeLlegada = 0.5f;

    private NavMeshAgent agente;
    private Vector3 posicionInicial;

    // (Fragmento del script NPC_script.cs)



    void Start()
    {
        agente = GetComponent<NavMeshAgent>();

        // 🔹 Verifica si el NPC está sobre el NavMesh
        if (!agente.isOnNavMesh)
        {
            // Trata de ubicarlo en el punto válido más cercano (Tu lógica de corrección de aterrizaje)
            if (NavMesh.SamplePosition(transform.position, out NavMeshHit hit, 5f, NavMesh.AllAreas))
            {
                transform.position = hit.position;
                agente.Warp(hit.position);
                UnityEngine.Debug.Log("✅ NPC recolocado automáticamente sobre el NavMesh.");
            }
            else
            {
                UnityEngine.Debug.LogError("❌ NPC fuera del NavMesh y no se encontró punto válido cercano.");
            }
        }
        // Si ya está en la malla, se inicializa sin Warp.

        // Ahora sí guardamos su posición real sobre la malla
        posicionInicial = transform.position;

        // 💡 PASO CRÍTICO: FORZAR EL PRIMER MOVIMIENTO INMEDIATO
        // -----------------------------------------------------------
        Vector3 primerDestino = BuscarPuntoAleatorio();

        if (agente.isOnNavMesh)
        {
            agente.SetDestination(primerDestino); // Le damos la primera orden de movimiento.
            agente.angularSpeed = 720f; // Aseguramos el giro rápido al inicio.
        }
        // -----------------------------------------------------------

        // Inicia la rutina de movimiento
        StartCoroutine(MoverAleatoriamente());
    }
    IEnumerator MoverAleatoriamente()
    {
        while (true)
        {
            // 1. Elegir un destino
            Vector3 nuevoDestino = BuscarPuntoAleatorio();

            if (agente.isOnNavMesh)
            {
                agente.SetDestination(nuevoDestino);
            }

            // 2. Esperar hasta que el agente esté CERCANO al destino
            // Espera hasta que tenga un camino válido y la distancia restante sea mayor a la distanciaDeLlegada
            yield return new WaitUntil(() => agente.pathPending == false && agente.remainingDistance > distanciaDeLlegada);

            // 3. Esperar a que la distancia restante sea mínima (ha frenado y llegado)
            yield return new WaitUntil(() => agente.remainingDistance <= agente.stoppingDistance + 0.1f);

            // 4. PAUSA. El personaje se detiene, la animación de 'parado' se activa
            yield return new WaitForSeconds(tiempoDeEspera);
        }
    }

    /// Busca un punto aleatorio VÁLIDO en el NavMesh dentro del rango
    Vector3 BuscarPuntoAleatorio()
    {
        // Genera una dirección aleatoria dentro de una esfera imaginaria
        // Usamos UnityEngine.Random para evitar el error de ambigüedad
        Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * rangoDeBusqueda;
        randomDirection += posicionInicial;

        NavMeshHit hit;

        // NavMesh.SamplePosition comprueba si el punto aleatorio está en el área azul del NavMesh
        if (NavMesh.SamplePosition(randomDirection, out hit, rangoDeBusqueda, NavMesh.AllAreas))
        {
            return hit.position;
        }

        // Si no encuentra un punto válido, devuelve la posición actual 
        return transform.position;
    }
}
