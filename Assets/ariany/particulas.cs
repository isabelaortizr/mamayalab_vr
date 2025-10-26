using UnityEngine;

public class particulas : MonoBehaviour
{
    public GameObject efectoParticulas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // La l�nea clave para solucionar el error CS0104:
            UnityEngine.Debug.Log("�TRIGGER DE PART�CULAS ACTIVADO!");

            GameObject efecto = Instantiate(efectoParticulas, transform.position, transform.rotation);

            ParticleSystem ps = efecto.GetComponent<ParticleSystem>();

            if (ps != null)
            {
                ps.Play();
                Destroy(efecto, ps.main.duration);
            }

            this.enabled = false;
        }
    }
}