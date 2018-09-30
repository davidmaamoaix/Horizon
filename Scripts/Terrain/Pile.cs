using UnityEngine;
using System.Collections;

public class Pile:MonoBehaviour{

	void Start(){
		gameObject.transform.eulerAngles=new Vector3(0,Random.Range(0f,360f),0);
	}

	void Update(){
	
	}
}
