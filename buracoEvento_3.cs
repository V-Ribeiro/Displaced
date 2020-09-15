using UnityEngine;
using System.Collections;

public class buracoEvento_3 : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        var script = GameObject.Find("buracoEvento").GetComponent<buracoEvento1>();
        if (other.tag == ("Player"))
        {
            script.situacao = false;
        }
    }
}
