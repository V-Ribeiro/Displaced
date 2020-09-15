// Patrol.cs
using UnityEngine;
using System.Collections;


public class inimigoAI : MonoBehaviour
{
    private Transform myTransform;
    //public bool perigo = false;
    public bool rage = false;
    public bool garantia = true;
    public bool estaMorto = false;

    // public Transform playerComponente; isto fica aqui caso torne a ser necessário

    void Awake()
    {
        myTransform = transform;
    }

    void OnTriggerEnter(Collider other)

    {
        //A cada update vai alterar a posição da navmesh para ser igual á do player (versão 2, a 1ª so funcionava para um inimgo, esta é universal)

        if (other.tag == ("Player") && garantia == true) {
            this.rage = true;
        }
    }

    void Update()
    {

        if (this.rage == true )
        {
            var playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
            var golemAnim = this.GetComponentInChildren<Animator>();

            //garantia serve para garantir que o inimigo morre sem ser apagado 
            this.garantia = false;
            GetComponent<NavMeshAgent>().enabled = true;
            GetComponent<NavMeshAgent>().destination = playerPos;

            if (this.name == ("enemy") || this.name == ("enemy(Clone)"))
            {
                var codigoAtaque = this.GetComponentInChildren<enemyAttack>();
                if (codigoAtaque.playerInRange == false)
                {
                    golemAnim.Play("walk");
                }
            }

            if (this.name == ("Ifrit") || this.name == ("Ifrit(Clone)"))
            {
                golemAnim.SetBool("rage", rage);
                myTransform.LookAt(playerPos);
            }
        } else
        {
            GetComponent<NavMeshAgent>().enabled = false;
        }
    }
}