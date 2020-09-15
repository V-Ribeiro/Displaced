using UnityEngine;
using System.Collections;

public class IfritDisparar : MonoBehaviour {

    public float fireRate;
    private float nextFire;
    public GameObject tiro;
    public GameObject tiroSpawn;
    public static System.Random ran = new System.Random();
    private int tipoDeAtaque;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        var danger = this.GetComponent<inimigoAI>();
        var ifritAnim = this.GetComponentInChildren<Animator>();

        if (danger.rage == true && Time.time > nextFire){
            nextFire = Time.time + fireRate;

            Instantiate(tiro, tiroSpawn.transform.position, tiroSpawn.transform.rotation);

            tipoDeAtaque = ran.Next(1, 3);

            ifritAnim.SetInteger("attack", tipoDeAtaque);
        }
    }
}
