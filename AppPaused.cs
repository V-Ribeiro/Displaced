using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AppPaused : MonoBehaviour
{
    public Image pauseIm;
    bool tempo = false;

    // Pause simples, apenas altera a escala de tempo do jogo para 0 ou 1
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            tempo = !tempo;
        }

        if (tempo == true)
        {
            Time.timeScale = 0;
            pauseIm.enabled = true;
        }

        else
        {
            Time.timeScale = 1;
            pauseIm.enabled = false;
        }
        }
    }
