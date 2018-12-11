using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManeger : MonoBehaviour {
	[SerializeField] private Text uiText;
	private float textUpdateInterval = 0.1f,textUpdateTime = 0;
	private string currentText;
	private int textCount = -1;
	// Use this for initialization
	void Start () {
		GetNextText();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0) && currentText.Length <= textCount){
			GetNextText();
		}
		if(currentText.Length > textCount){
			textCount = (int)((Time.time - textUpdateTime)/textUpdateInterval);
			uiText.text = currentText.Substring(0,textCount);
		}
		else{
			Debug.Log("hoge");
		}
	}


	void GetNextText(){
		currentText = "パトラちゃんすこすこ";
		textCount = 0;
		textUpdateTime = Time.time;
	}
}
