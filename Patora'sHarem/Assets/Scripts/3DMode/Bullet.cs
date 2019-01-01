using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	[SerializeField]private Rigidbody rb;
	[SerializeField]private int shotpower;
	[SerializeField]private GameObject hitParticle;
	private int hitCount;
	// Use this for initialization
	void Start () {
		hitCount = 0;
		Move();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Move(){
		rb.velocity = (transform.forward + new Vector3(0,0.25f,0))* shotpower;
	}

	private void OnCollisionEnter(Collision other) {
		if(other.collider.tag == "Enemy"){
			//敵にDamege処理
		}
		if(other.collider.tag != "Player" && other.collider.tag != "Bullet"){
			hitCount++;
		}
		if(hitCount >= 3){
			Destroy(this.gameObject);
			Instantiate(hitParticle,transform.position,Quaternion.identity);
		}
	}
}
