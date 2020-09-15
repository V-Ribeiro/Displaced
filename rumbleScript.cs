using UnityEngine;
using System.Collections;

public class rumbleScript : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        var script = GameObject.FindGameObjectWithTag("textoPrincipal").GetComponent<textoScript>();
        if (other.tag == ("Player"))
        {
            script.rumbleSound();
        }
    }
}
