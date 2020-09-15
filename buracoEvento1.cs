using UnityEngine;
using System.Collections;

public class buracoEvento1 : MonoBehaviour {

    public bool situacao = true;

    void OnTriggerEnter(Collider other)
    {
        var script = GameObject.FindGameObjectWithTag("textoPrincipal").GetComponent<textoScript>();
        if (other.tag == ("Player"))
        {
            situacao = true;
            script.eventoBuraco1();
        }
    }
}
