using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	[SerializeField]private Rigidbody rb;
	[SerializeField]private int shotpower;
	// Use this for initialization
	void Start () {
		Move();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Move(){
		rb.velocity = (transform.forward + new Vector3(0,0.4f,0))* shotpower;
		//rb.AddForce(transform.forward * shotpower);
	}
}
