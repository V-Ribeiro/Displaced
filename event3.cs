using UnityEngine;
using System.Collections;

public class event3 : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        var script = GameObject.FindGameObjectWithTag("textoPrincipal").GetComponent<textoScript>();
        if (other.tag == ("Player"))
        {
            script.escolhaCaminho();
        }
    }
}
