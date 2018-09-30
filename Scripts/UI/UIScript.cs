using UnityEngine;
using System.Collections;

public class UIScript:MonoBehaviour{

	public Canvas menu;

	void Start(){
	
	}

	void Update(){
	
	}

	public void retry(){
		Lib.run=true;
		menu.enabled=false;
	}
}
