using UnityEngine;
using System.Collections;

public class enemyAttack : MonoBehaviour
{

    public int timeBetweenAttacks = 100;
    public bool playerInRange;
    float timer;
    GameObject player;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter(Collider other)
    {
        // Detectar o jogador
        if (other.gameObject == player)
        {
            playerInRange = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        // Isto serve para fugir dos inimigos
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // alterar o tempo do timer
        //timer += Time.deltaTime;

        timeBetweenAttacks -= 1;

        // se o jogador estiver perto e as condições forem correctas ele ataca
        var inimigoScript = this.transform.parent.gameObject.GetComponent<inimigoAI>();
        if (timeBetweenAttacks < 0 && playerInRange == true && inimigoScript.rage == true )
        {
            // ... attack.
            Attack();
        }

    }

    void Attack()
    {

        var playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<playerHealth>();
        var componenteMae = this.transform.parent.gameObject;
        var golemAnim = componenteMae.GetComponentInChildren<Animator>();

        // Reset do tempo
        timeBetweenAttacks = 100;

        //O miguel escreveu mal attack mas nem me incomodei a corrigir
        golemAnim.Play("atack");

        // Isto apenas serve para a varivel nõ ficar abaixo de 0
        if (playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(7);
        }
    }
}
