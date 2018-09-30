using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObstacleManager:MonoBehaviour{

	public Transform player;
	public GameObject[] models;
	public List<GameObject> obstacles;

	void Start(){
		obstacles=new List<GameObject>();
	}

	void Update(){
		if(Lib.run&&!Lib.pause){
			genObs();
		}
	}

	void genObs(){
		if(Random.Range(0,3)!=0){
			for(int i=0;i<obstacles.Count;i++){
				if(Mathf.Abs(obstacles[i].transform.position.x-player.position.x)>1500||
					Mathf.Abs(obstacles[i].transform.position.z-player.position.z)>1500){
					Destroy(obstacles[i]);
					obstacles.RemoveAt(i);
					i--;
				}
			}
			if(obstacles.Count<500){
				GameObject newObs=(GameObject)Instantiate(models[Random.Range(0,10)],
					new Vector3(player.position.x+Random.Range(-1500f,1500f),0,player.position.z+1450),
					gameObject.transform.rotation);
				obstacles.Add(newObs);
			}
		}
	}
}
