using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	public int enemyHp;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void Damege(){
		enemyHp -= 1;
		if(enemyHp <= 0){
			Dead();
		}
	}
	void Damege(int damege){
		enemyHp -= damege;
		if(enemyHp <= 0){
			Dead();
		}
	}
	virtual protected void Dead(){
		
	}
}
