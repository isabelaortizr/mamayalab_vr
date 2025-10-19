using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class particulas : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public GameObject efectoParticulas;

        private void OnTriggerEnter(Collider other)
        {
        if (other.CompareTag("Player"))
        {
            GameObject efecto = Instantiate(efectoParticulas, transform.position, transform.rotation);
            Destroy(efecto, 2f);
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
