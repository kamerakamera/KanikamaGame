using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KanikamaPurin : Item {
	[SerializeField]private int recoverHp;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	override protected void AddPlayerStatus(Player p){
		p.Hp += recoverHp;
	}
}
