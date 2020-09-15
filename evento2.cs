using UnityEngine;
using System.Collections;

public class evento2 : MonoBehaviour {

    // Use this for initialization
    void OnTriggerEnter(Collider other)
    {
        var script = GameObject.FindGameObjectWithTag("textoPrincipal").GetComponent<textoScript>();
        if (other.tag == ("Player"))
        {
            script.ifritMorto();
        }
    }
}
