using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimationManeger : MonoBehaviour {
	[SerializeField]int eventAmount;
	[SerializeField]string[] eventName;
	[SerializeField]int[] eventLine;
	int actionCount;
	[SerializeField]SpriteAnimationController spriteAnimationController;

	// Use this for initialization
	void Start () {
		actionCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ExecuteAnimation(int textLineNum){
		foreach(int num in eventLine){
			if(num == textLineNum){
				spriteAnimationController.SetAnimationBool(eventName[actionCount]);
				actionCount++;
			}
		}
	}
}
