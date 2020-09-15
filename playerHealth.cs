using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playerHealth : MonoBehaviour {

    public const int maxHealth = 100;
    public int currentHealth = maxHealth;
    public Vector3 currentCheckPoint;
    public Slider healthBar;
    GameObject tiroIfrit;

    public AudioClip morrer;
    public AudioClip dor2;
    public AudioClip dor3;
    public AudioClip dor4;
    public AudioClip dor5;

    public static System.Random ran = new System.Random();

    private AudioSource audio2;
    private AudioSource audio3;
    private AudioSource audio4;
    private AudioSource audio5;
    private AudioSource audio6;

    private int somParaTocar;

    public AudioSource AddAudio(AudioClip clip, bool loop, bool playAwake, float vol)
    {

        AudioSource newAudio = gameObject.AddComponent<AudioSource>();

        newAudio.clip = clip;
        newAudio.loop = loop;
        newAudio.playOnAwake = playAwake;
        newAudio.volume = vol;

        return newAudio;

    }

    void Start ()
    {
        audio2 = AddAudio(morrer, false, false, 0.5f);
        audio3 = AddAudio(dor2, false, false, 0.5f);
        audio4 = AddAudio(dor3, false, false, 0.5f);
        audio5 = AddAudio(dor4, false, false, 0.5f);
        audio6 = AddAudio(dor5, false, false, 0.5f);
        healthBar.value = currentHealth;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("balasInimigo"))
        {
            Destroy(other.gameObject);
            TakeDamage(15);
        }
    }

    public void TakeDamage(int ammount)
    {
        currentHealth -= ammount;

        somParaTocar = ran.Next(1, 5);

        if (somParaTocar == 1)
        {
            audio3.Play();
        }

        if (somParaTocar == 2)
        {
            audio4.Play();
        }

        if (somParaTocar == 3)
        {
            audio5.Play();
        }

        if (somParaTocar == 4)
        {
            audio6.Play();
        }

        if (currentHealth <= 0)
        {

            var inimigos = GameObject.FindGameObjectsWithTag("enemy");
            var este = inimigos.Length;
            
            //este ciclo serve para acalmar os inimigos
            for (var i = 0; i < este; i++)
            {
                var temp = inimigos[i].GetComponent<inimigoAI>();
                var anim = inimigos[i].GetComponentInChildren<Animator>();

                if (temp.estaMorto == false)
                {
                    temp.rage = false;
                    temp.garantia = true;
                    anim.Play("idle");
                    anim.SetInteger("attack", 0);
                } else
                {
                    anim.Play("death");
                }
            }
            currentHealth = 50;
            Debug.Log("Dead");
            audio2.Play();
            this.transform.position = currentCheckPoint;
            goPoint();
        }
        healthBar.value = currentHealth;
    }

    public void gainHealth(int ammount)
    {
        this.gameObject.GetComponent<ParticleSystem>().Play();

        currentHealth += ammount;

        if (currentHealth > 100)
        {
            currentHealth = 100;
        }
        healthBar.value = currentHealth;
    }

    public void goPoint()
    {
        this.transform.position = currentCheckPoint;
    }
}
