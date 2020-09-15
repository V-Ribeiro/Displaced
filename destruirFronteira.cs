using UnityEngine;
using System.Collections;

public class destruirFronteira : MonoBehaviour {


    //quando os objectos saem da area são destruidos
    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
