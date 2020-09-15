using UnityEngine;
using System.Collections;

public class enemyManager : MonoBehaviour
{
    public GameObject enemy;       


    void Start()
    {
        // fazer a instancia no local onde foi criado o gestor
        //alterei isto para serem filhos do gestor, facilita-me o codigo nos outros scripts
       GameObject novofoe = Instantiate(enemy, this.transform.position, this.transform.rotation) as GameObject;
        novofoe.transform.parent = transform;
    }
}