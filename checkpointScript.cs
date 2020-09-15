using UnityEngine;
using System.Collections;

public class checkpointScript : MonoBehaviour {

    private Vector3 posicao;

	// Use this for initialization
	void Start () {

        posicao = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == ("Player"))
        {
            var jogador = GameObject.FindGameObjectWithTag("Player").GetComponent<playerHealth>();
            var particulas = this.gameObject.GetComponentInChildren<ParticleSystem>();
            particulas.Stop();
            jogador.currentCheckPoint = posicao;
        }
    }
}
