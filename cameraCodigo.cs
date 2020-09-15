using UnityEngine;
using System.Collections;

public class cameraCodigo : MonoBehaviour {

    public GameObject player;

    private Vector3 diferenca;

    public float mouseSensitivity = 100.0f;
    public float clampAngle = 40.0f;

    private float rotY = 0.0f; // rotation around the up/y axis
    private float rotX = 0.0f; // rotation around the right/x axis


    // Use this for initialization
    void Start () {

        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;


        // calcula a diferença entra o jogador e a câmara 
        diferenca = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {

        //muda a posição da camara para ser igual á do jogador + a diferença
        transform.position = player.transform.position + diferenca;

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");

        rotY += mouseX * mouseSensitivity * Time.deltaTime;
        rotX += mouseY * mouseSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;

    }


}
