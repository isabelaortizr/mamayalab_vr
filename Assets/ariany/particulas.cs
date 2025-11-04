using UnityEngine;

public class particulas : MonoBehaviour
{
    public GameObject efectoParticulas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mano"))
        {
            // La lú‹ea clave para solucionar el error CS0104:
            UnityEngine.Debug.Log("¡TRIGGER DE PARTÍCULAS ACTIVADO!");

            GameObject efecto = Instantiate(efectoParticulas, transform.position, transform.rotation);

            ParticleSystem ps = efecto.GetComponent<ParticleSystem>();

            if (ps != null)
            {
                ps.Play();
            }

            this.enabled = false;
        }
    }
}