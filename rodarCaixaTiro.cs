using UnityEngine;
using System.Collections;

public class rodarCaixaTiro : MonoBehaviour
{

    public float horizontalSpeed = 20.0F;
    public float verticalSpeed = 20.0F;

    //isto agora roda o jogador por questões de jogablidade, e o nome do script fica assim por questões de conveniencia

    void Update()
    {

        //rodar o cursor
        if (Time.timeScale == 1)
        {
            float h = horizontalSpeed * Input.GetAxis("Mouse X");
            float v = verticalSpeed * Input.GetAxis("Mouse Y");
            transform.Rotate(-v, h, 0);
        }


        //reset ao angulo de tiro

        /*
        if (Input.GetMouseButton(2))
        {
            transform.localRotation = Quaternion.identity;
        }
        */
    }
}
