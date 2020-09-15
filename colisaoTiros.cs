using UnityEngine;
using System.Collections;

public class colisaoTiros : MonoBehaviour {

    //public GameObject balas;

    //duvido que isto funcione direito, o codigo comentado é caso eu queira fazer alterações
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("balas") || other.tag == ("balasInimigo"))
        {
            Destroy(other.gameObject);
            //Destroy(balas);
        }
    }

}
