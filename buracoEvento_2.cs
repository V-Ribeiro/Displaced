using UnityEngine;
using System.Collections;

public class buracoEvento_2 : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        var script = GameObject.FindGameObjectWithTag("textoPrincipal").GetComponent<textoScript>();
        var script2 = GameObject.Find("buracoEvento").GetComponent<buracoEvento1>();
        var playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<playerHealth>();
        if (other.tag == ("Player") && script2.situacao == true)
        {
            script.eventoBuraco2();
            script2.situacao = false;
            playerHealth.TakeDamage(12);
        }
    }
}