using UnityEngine;
using System.Collections;

public class Gem:MonoBehaviour{

	void Start(){
	
	}

	void Update(){
		gameObject.transform.eulerAngles=new Vector3(0,gameObject.transform.eulerAngles.y+3,0);
	}
}
