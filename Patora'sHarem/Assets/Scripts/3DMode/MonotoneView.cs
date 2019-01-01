using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonotoneView : MonoBehaviour {
	public Material monotone;
	public Material _default;
	public Player player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnRenderImage(RenderTexture src,RenderTexture dest){
		if(player.GetIsAvoid()){
			Graphics.Blit(src,dest,monotone);
		}else{
			Graphics.Blit(src,dest,_default);
		}
		
	}
}
