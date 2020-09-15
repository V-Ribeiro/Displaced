using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class golemDor : MonoBehaviour
    {

        public AudioClip dor1;
        public AudioClip dor2;
        public AudioClip dor3;
        public AudioClip dor4;


        private AudioSource audio1;
        private AudioSource audio2;
        private AudioSource audio3;
        private AudioSource audio4;


        public int valorBolt;
        public int valorFire;
        public int valorRock;

        public static System.Random ran = new System.Random();
        private int somParaTocar;

        //isto destroi as balas

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
            audio1 = AddAudio(dor1, false, false, 0.3f);
            audio2 = AddAudio(dor2, false, false, 0.3f);
            audio3 = AddAudio(dor3, false, false, 0.3f);
            audio4 = AddAudio(dor4, false, false, 0.3f);
        }

        void OnTriggerEnter(Collider other)
        {
            var inimigoMain = this.GetComponentInParent<inimigoAI>();
            if (other.tag == ("balas") && (inimigoMain.rage == true || inimigoMain.garantia == true))
            {
                Destroy(other.gameObject);

                //escolher o som para tocar

                somParaTocar = ran.Next(1, 5);

                if (somParaTocar == 1)
                {
                    audio1.Play();
                }

                if (somParaTocar == 2)
                {
                    audio2.Play();
                }

                if (somParaTocar == 3)
                {
                    audio3.Play();
                }

                if (somParaTocar == 4)
                {
                    audio4.Play();
                }

            }

            //referencia ao outro script
            // GameObject currEnemy = GameObject.Find("enemy"); obsoleto, a linha abaixo funciona melhor

            //var healthScript = GameObject.FindGameObjectWithTag("enemy").GetComponent<inimigoHealth>();
            //var inimigoValor = GameObject.FindGameObjectWithTag("enemy").GetComponent<inimigoAI>();

            //demorei literalmente duas horas a esquecer as linhas de cima e passar a ir buscar o parentObject
            var healthScript = this.transform.parent.gameObject.GetComponent<inimigoHealth>();
            var inimigoValor = this.transform.parent.gameObject.GetComponent<inimigoAI>();

            //verificar tipo de tiro e retirar Health
            if (other.name == ("bolt(Clone)"))
            {
                healthScript.currentHealth -= valorBolt;
                inimigoValor.rage = true;

                if (healthScript.currentHealth < 1) {
                    inimigoValor.rage = false;
                    //inimigoValor.enabled = false;
                }

            }

            if (other.name == ("fireball(Clone)"))
            {
                healthScript.currentHealth -= valorFire;
                inimigoValor.rage = true;

                if (healthScript.currentHealth < 1)
                {
                    inimigoValor.rage = false;
                    //inimigoValor.enabled = false;
                }
            }
            if (other.name == ("rockPower(Clone)"))
            {
                healthScript.currentHealth -= valorRock;
                inimigoValor.rage = true;

                if (healthScript.currentHealth < 1)
                {
                    inimigoValor.rage = false;
                }
            }
        }
    }
}