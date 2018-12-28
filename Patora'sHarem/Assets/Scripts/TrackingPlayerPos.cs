using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingPlayerPos : MonoBehaviour {
	[SerializeField]private GameObject player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = player.transform.position;
	}
}
