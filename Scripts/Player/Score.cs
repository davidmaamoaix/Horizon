using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;

public class Score:MonoBehaviour{

	public int score;
	public float multiplier;
	public Text hsText;
	public Text scoreText;
	public Text multiplierText;

	string fileName="HorizonHighScore.txt";

	void Start(){
		if(!File.Exists(fileName)){
			Lib.hs=0;
		}else{
			StreamReader file=File.OpenText(fileName);
			string saveFile=file.ReadLine();
			file.Close();
			if(saveFile==null){
				Lib.hs=0;
			}else if(!int.TryParse(System.Text.Encoding.UTF8.GetString(
				System.Convert.FromBase64String(saveFile)),out Lib.hs)){
				Lib.hs=0;
			}
		}
		score=0;
		multiplier=1;
		scoreText.text="0";
		hsText.text=Lib.hs.ToString();
		multiplierText.text="x1";
	}

	void Update(){
		if(Lib.run&&!Lib.pause){
			score+=Mathf.RoundToInt(1*multiplier);
			scoreText.text=score.ToString();
			multiplierText.text="x"+multiplier.ToString();
		}
	}

	public void updateHighscore(){
		if(score>Lib.hs){
			Lib.hs=score;
		}
		File.WriteAllText(fileName,
			System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(Lib.hs.ToString())));
	}
}
