using UnityEngine;
using System.Collections;

public class TerrainGenerator:MonoBehaviour{

	public Transform player;
	public GameObject ground;
	GameObject[] grounds=new GameObject[9];

	void Start(){
		int[,] newAxis=getAxis();
		for(int i=0;i<9;i++){
			Vector3 planeAxis=new Vector3(newAxis[i,0],0,newAxis[i,1]);
			grounds[i]=(GameObject)Instantiate(ground,planeAxis,transform.rotation);
		}
	}

	void Update(){
		genGround();
	}

	void genGround(){
		int[,] newAxis=getAxis();
		for(int i=0;i<9;i++){
			if(grounds[i].transform.position!=new Vector3(newAxis[i,0],0,newAxis[i,1])){
				break;
			}
			return;
		}
		//for(int i=0;i<9;i++){Debug.Log(newAxis[i,0].ToString()+" | "+newAxis[i,1].ToString());}
		GameObject[] newGrounds=new GameObject[9];
		for(int i=0;i<9;i++){
			for(int j=0;j<9;j++){
				if(grounds[j]!=null){
					if(grounds[j].transform.position==new Vector3(newAxis[i,0],0,newAxis[i,1])){
						newGrounds[i]=grounds[j];
						grounds[j]=null;
					}
				}
			}
		}
		for(int i=0;i<9;i++){
			if(grounds[i]!=null){
				Destroy(grounds[i]);
			}
			grounds[i]=newGrounds[i];
			if(grounds[i]==null){
				Vector3 planeAxis=new Vector3(newAxis[i,0],0,newAxis[i,1]);
				grounds[i]=(GameObject)Instantiate(ground,planeAxis,transform.rotation);
			}
		}
	}

	int[] playerAxis(){
		return new int[]{(int)(Mathf.Round(player.position.x/1000)*1000),
				 (int)(Mathf.Round(player.position.z/1000)*1000)};
	}

	int[,] getAxis(){
		int[,] axis=new int[9,2];
		int[] center=playerAxis();
		int k=0;
		for(int i=-1000;i<2000;i+=1000){
			for(int j=-1000;j<2000;j+=1000){
				axis[k,0]=center[0]+j;
				axis[k,1]=center[1]+i;
				k++;
			}
		}
		return axis;
	}

	int[,] sort(int[,] raw){
		return null;
	}
}
