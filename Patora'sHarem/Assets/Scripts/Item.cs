using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	protected virtual void AddPlayerStatus(Player p){

	}
	private void OnCollisionEnter(Collision other) {
		Debug.Log("get!");
		if(other.collider.tag == "Player"){
			AddPlayerStatus(other.gameObject.GetComponent<Player>());
			Destroy(this.gameObject);
		}
	}
}
