using UnityEngine;
using System.Collections;
using UnityEngine.AI; 

public class NPC : MonoBehaviour
{
    [Header("Configuración del NPC")]

    [Tooltip("El rango máximo desde el punto de inicio para elegir un destino.")]
    public float rangoDeBusqueda = 15f;

    [Tooltip("Tiempo de espera entre la elección de nuevos destinos (Cada X tiempo).")]
    public float tiempoDeEspera = 5f;

    private NavMeshAgent agente; 
    private Vector3 posicionInicial;

    void Start()
    {
        
        agente = GetComponent<NavMeshAgent>();

       
        posicionInicial = transform.position;

        StartCoroutine(MoverAleatoriamente());
    }

    
    IEnumerator MoverAleatoriamente()
    {
        while (true)
        {
            //destino
            Vector3 nuevoDestino = BuscarPuntoAleatorio();

            // 2. Le decimos al NavMeshAgent que vaya a ese punto
            // Él se encarga de calcular la ruta y esquivar obstáculos
            if (agente.isOnNavMesh) // Asegurarse de que el agente esté en la malla
            {
                agente.SetDestination(nuevoDestino);
            }

            // 3. Pausa. Esto es lo que genera el efecto de "cada X tiempo"
            yield return new WaitForSeconds(tiempoDeEspera);
        }
    }


    /// Busca un punto aleatorio VÁLIDO en el NavMesh dentro del rango
    
    Vector3 BuscarPuntoAleatorio()
    {
        // Genera una dirección aleatoria dentro de una esfera imaginaria
        Vector3 randomDirection = Random.insideUnitSphere * rangoDeBusqueda;
        randomDirection += posicionInicial;

        NavMeshHit hit;

        // NavMesh.SamplePosition comprueba si el punto aleatorio está en el área azul del NavMesh
        if (NavMesh.SamplePosition(randomDirection, out hit, rangoDeBusqueda, NavMesh.AllAreas))
        {
            return hit.position; 
        }

        // Si no encuentra un punto válido, devuelve la posición actual para que el NPC se quede quieto
        return transform.position;
    }
}
