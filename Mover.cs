using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

    public float speed;

    // Use this for initialization
    void Start() {



        Rigidbody rigido = GetComponent<Rigidbody>();

        if (rigido.tag == ("balas")) {

        rigido.velocity = transform.forward * speed;

        }

        if (rigido.tag == ("balasInimigo"))
        {
            float step = speed * Time.deltaTime;
            var playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
            transform.position = Vector3.MoveTowards(transform.position, playerPos, step);

        }

    }

    void Update()
    {

        Rigidbody rigido = GetComponent<Rigidbody>();
        

    }
}
