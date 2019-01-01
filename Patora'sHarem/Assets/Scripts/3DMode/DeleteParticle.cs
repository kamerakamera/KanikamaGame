using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteParticle : MonoBehaviour {
	[SerializeField]float deleteTime;
	// Use this for initialization
	void Start () {
		Destroy(gameObject,deleteTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
