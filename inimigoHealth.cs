using System;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using System.Collections;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets.Characters.ThirdPerson
{

    public class inimigoHealth : MonoBehaviour
    {

        public const int maxHealth = 100;
        public int currentHealth = maxHealth;
        public AudioClip morrer;

        private AudioSource audio5;
        public static System.Random ran = new System.Random();
        public int probabilidade;
        public int probabilidade2;
        public int saude;
        public int numFogo;
        public int numPedra;
        private bool mortoImediato = true;


        public AudioSource AddAudio(AudioClip clip, bool loop, bool playAwake, float vol)
        {

            AudioSource newAudio = gameObject.AddComponent<AudioSource>();

            newAudio.clip = clip;
            newAudio.loop = loop;
            newAudio.playOnAwake = playAwake;
            newAudio.volume = vol;

            return newAudio;

        }

        void Awake()
        {
            audio5 = AddAudio(morrer, false, false, 0.3f);
            //definir os valores aleatorios
            probabilidade = ran.Next(1, 6);
            probabilidade2 = ran.Next(1, 6);
            saude = ran.Next(15);
            numFogo = ran.Next(3);
            numPedra= ran.Next(3);
        }

        public void Update()
        {
            //script simples, se o hp for menor que 0 apaga o objecto
            var playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<playerHealth>();
            var playerShots = GameObject.FindGameObjectWithTag("Player").GetComponent<ThirdPersonUserControl>();
            var ifritAnim = this.GetComponentInChildren<Animator>();
            //var golemAnim = this.GetComponentInChildren<Animator>();

            var goParent = this.transform.parent.gameObject;
            var dsds = goParent.GetComponentInChildren<inimigoAI>();

            if (currentHealth <= 0 && mortoImediato == true)
            {
                audio5.Play();
                var particulas = this.gameObject.GetComponentInChildren<ParticleSystem>();
                var colisao = this.gameObject.GetComponentInChildren<CapsuleCollider>();
                dsds.estaMorto = true;
                colisao.enabled = false;

                if (this.name == ("Ifrit") || this.name == ("Ifrit(Clone)"))
                {
                    particulas.Stop();
                    ifritAnim.Play("death");

                }

                if (this.name == ("enemy") || this.name == ("enemy(Clone)"))
                {
                    ifritAnim.Play("Default Take");
                    
                }

                if (this.name == ("magnumOpus"))
                {
                        SceneManager.LoadScene(0);
                }

                //ifritAnim.SetBool("dead", true);
                //Destroy(this.gameObject);

                //calcular a probabilidade de ganhar saude ou poderes
                if (probabilidade >= 4)
                {
                    playerHealth.gainHealth(saude);
                }
                if (probabilidade2 >= 4)
                {
                    playerShots.numeroFogo += numFogo;
                    playerShots.numeroRochas += numPedra;
                    playerShots.mostrarTiros();
                }
                mortoImediato = false;
            }
        }
    }
}