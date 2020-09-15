using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace UnityStandardAssets.Characters.ThirdPerson
{

    public class moneyScript : MonoBehaviour
    {
        public Text textBox;

        void OnTriggerEnter(Collider other)
        {
            var script = GameObject.FindGameObjectWithTag("Player").GetComponent<ThirdPersonUserControl>();
            if (other.tag == ("Player"))
            {
                var asdas = GameObject.FindGameObjectWithTag("tocadorAudio").GetComponent<AudioSource>();
                asdas.Play();
                script.riqueza += 1;
                textBox.text = "" + script.riqueza;
                Destroy(this.gameObject);
            }
        }
    }
}
