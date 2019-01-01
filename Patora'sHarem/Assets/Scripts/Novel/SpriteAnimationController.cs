using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimationController : MonoBehaviour {
	[SerializeField]private Animator animator;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetAnimationBool(string boolName){
		animator.SetBool(boolName,true);
	}
}
