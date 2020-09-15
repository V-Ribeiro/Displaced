using UnityEngine;
using System.Collections;

public class movimento : MonoBehaviour {

	public float speed;

	private Rigidbody rb;

	void Start () { 
		rb = GetComponent<Rigidbody> ();
	}

	void FixedUpdate () {
		float moverHorizontal = Input.GetAxis ("Horizontal"); 
		float moverVertical = Input.GetAxis ("Vertical"); 

		Vector3 movement = new Vector3 (moverHorizontal, 0.0f, moverVertical);

		rb.AddForce (movement * speed); 
	}
}
