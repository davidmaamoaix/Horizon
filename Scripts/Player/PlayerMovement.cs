using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerMovement:MonoBehaviour{

	public ObstacleManager obs;
	public Image deathFade;
	public Image gemImg;
	public Score score;
	float camTilt=0;
	float momentum=0;
	float gemAlpha;
	bool fade;
	bool gem;

	void Start(){
		gemAlpha=-0.3f;
		gem=false;
		fade=false;
		Lib.run=false;
		Lib.pause=false;
	}

	void Update(){
		gemImg.color=new Color(gemImg.color.r,gemImg.color.g,gemImg.color.b,0.3f-Mathf.Abs(gemAlpha));
		if(Input.GetKeyDown("space")&&Lib.run){
			Lib.pause=!Lib.pause;
		}
		if(fade){
			deathFade.color=new Color(deathFade.color.r,deathFade.color.g,deathFade.color.b,
					deathFade.color.a+0.025f);
			if(deathFade.color.a>=1){
				Application.LoadLevel(Application.loadedLevel);
			}
		}
		if(Lib.run&&!Lib.pause){
			gemUpdate();
			anim();
			move();
		}
	}

	void gemUpdate(){
		if(gem){
			gemAlpha+=0.075f;
			if(gemAlpha>=0.3f){
				gemAlpha=-0.3f;
				gem=false;
			}
		}
	}

	void anim(){
		float input=Input.GetAxisRaw("Horizontal");
		if(input!=0){
			camTilt-=input/4;
			if(input/Mathf.Abs(input)==camTilt/Mathf.Abs(camTilt)) camTilt*=0.975f;
			if(camTilt<-15) camTilt=-15;
			if(camTilt>15) camTilt=15;
		}else{
			camTilt*=0.95f;
			if(Mathf.Abs(camTilt)<0.5f) camTilt=0;
		}
		transform.eulerAngles=new Vector3(0,0,360+camTilt);
	}

	void move(){
		float input=Input.GetAxisRaw("Horizontal");
		if(input!=0){
			momentum+=input/5;
			if(momentum<-3) momentum=-3;
			if(momentum>3) momentum=3;
		}else{
			momentum*=0.98f;
			if(Mathf.Abs(momentum)<0.2f) momentum=0;
		}
		transform.position=new Vector3(transform.position.x+momentum,3,transform.position.z+10);
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag=="Gem"){
			obs.obstacles.Remove(other.gameObject);
			Destroy(other.gameObject);
			score.multiplier+=0.2f;
			score.score+=Mathf.RoundToInt(100*score.multiplier);
			gem=true;
		}else{
			death();
		}
	}

	void death(){
		Lib.run=false;
		fade=true;
		score.updateHighscore();
	}
}
