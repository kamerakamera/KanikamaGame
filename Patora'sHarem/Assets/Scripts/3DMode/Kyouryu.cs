using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kyouryu : Enemy {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	override protected void Dead(){
		Destroy(this.gameObject);
	}
}
