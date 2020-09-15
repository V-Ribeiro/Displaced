using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class textoScript : MonoBehaviour {

    public Text textBox;
    float timeLeft = 190.0f;
    private bool evento1 = false;
    private bool evento2 = true;
    private bool evento3 = true;
    private bool evento4 = true;
    private bool evento5 = true;
    private bool evento6 = true;
    private bool evento7 = true;

    // Use this for initialization
    void Start () {
        textBox.text = "Well. I'll worry on how to get out of here later. For now I'll focus on getting to the bottom of these tremors.";
    }
	
	// Update is called once per frame
	void Update () {

        // coisas para o texto
        timeLeft -= 1;

        if (timeLeft == 0)
        {
            textBox.text = "";
        }

        var inimigos = GameObject.FindGameObjectsWithTag("enemy");
        var este = inimigos.Length;

        for (var i = 0; i < este; i++)
        {
            var temp = inimigos[i].GetComponent<inimigoAI>();
            var anim = inimigos[i].GetComponentInChildren<Animator>();

            if (temp.rage == true && evento1 == false)
            {
                evento1 = true;
                timeLeft = 220.0f;
                textBox.text = "A golem? Maybe there are more. Could they be the source of the tremors?";
                if (timeLeft == 0)
                {
                    textBox.text = "";
                }
            }
        }
    }

   public void primeiroEvento ()
    {
        if (evento2 == true)
        {
            timeLeft = 200.0f;
            textBox.text = "No harm done. I can get back up and try again.";
            if (timeLeft == 0)
            {
                textBox.text = "";
            }
            evento2 = false;
        }

    }

    public void ifritMorto()
    {
        if (evento3 == true)
        {
            timeLeft = 230.0f;
            textBox.text = "Dead Ifrits. They must have gotten stuck out here when the cave flooded.";
            if (timeLeft == 0)
            {
                textBox.text = "";
            }
            evento3 = false;
        }

    }

    public void escolhaCaminho()
    {
        if (evento4 == true)
        {
            timeLeft = 190.0f;
            textBox.text = "Two paths? Seems like I have a choice to make.";
            if (timeLeft == 0)
            {
                textBox.text = "";
            }
            evento4 = false;
            }

    }

    public void eventoBuraco1()
    {
        if (evento5 == true)
        {
            timeLeft = 220.0f;
            textBox.text = "That hole looks deep. I should be careful going down.";
            if (timeLeft == 0)
            {
                textBox.text = "";
            }
            evento5 = false;
        }
    }

    public void eventoBuraco2()
    {
        if (evento6 == true)
        {
            timeLeft = 150.0f;
            textBox.text = "OOF. Guess I should follow my own advice.";
            if (timeLeft == 0)
            {
                textBox.text = "";
            }
            evento6 = false;
        }
    }

    public void rumbleSound()
    {
        if (evento7 == true)
        {
            timeLeft = 130.0f;
            textBox.text = "What is that sound...?";
            if (timeLeft == 0)
            {
                textBox.text = "";
            }
            evento7 = false;
        }
    }

}
