using UnityEngine;
using System.Collections;

public class evento4 : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        var jogador = GameObject.FindGameObjectWithTag("Player").GetComponent<playerHealth>();
        if (other.tag == ("Player"))
        {
            jogador.goPoint();
            jogador.TakeDamage(10);
        }
    }
}
