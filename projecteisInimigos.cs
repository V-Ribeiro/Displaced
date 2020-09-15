using UnityEngine;
using System.Collections;

public class projecteisInimigos : MonoBehaviour {

    public Transform jogador;
    public float ProjectileSpeed = 20;
    GameObject player;


    private Transform myTransform;

    void Awake()
    {
        myTransform = transform;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        jogador = player.transform;
        // isto roda o tiro para o jogador
        myTransform.LookAt(jogador);
    }

    // Update is called once per frame
    void Update()
    {
        float amtToMove = ProjectileSpeed * Time.deltaTime;
        // translate projectile in its forward direction:
        myTransform.Translate(Vector3.forward * amtToMove);
    }


}
