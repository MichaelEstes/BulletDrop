using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public float timer;
	public float maxTime = 1.5f;
	public static int score = 0;
	public static int highScore;
	public int missedCount = 0;
	public Vector3 maxScale = new Vector3(0.7f, 0.7f,0);
	public Vector3 addScale = new Vector3 (0.001f, 0.001f, 0);
	public Vector3 startScale = new Vector3 (0.01f, 0.01f, 0);
	public TextMesh scoreText;
	public TextMesh shotText;
	public TextMesh enemyText;
	public bool gotHeadShot;
	public bool gotBodyShot;
	public bool missed;
	public bool targetEscaped = false;
	public StartReset reset;
	public EnemyPosition enemyPos;
	public PlayerControl player;

	void Start(){
		scoreText.text = "Score: " + score.ToString ();
		shotText.text = "";
		shotText.transform.localScale = startScale;
		gotHeadShot = false;
		gotBodyShot = false;
		missed = false;
		timer = 0;
	}
	
	void Update () {
		if(gotHeadShot && gotBodyShot){
			shotText.text = "SPINAL TAP";
			if(shotText.transform.localScale.y < maxScale.y){
				shotText.transform.localScale += addScale;
			}
		}else if(gotBodyShot){
			shotText.text = "BODYSHOT";
			if(shotText.transform.localScale.y < maxScale.y){
				shotText.transform.localScale += addScale;
			}
		}else if(gotHeadShot){
			shotText.text = "HEADSHOT";
			if(shotText.transform.localScale.y < maxScale.y){
				shotText.transform.localScale += addScale;
			}
		}
		if(missed){
			if(missedCount < 2){
				shotText.text = "MISSED";
			}else{
				shotText.text = "TARGET ESCAPED";
				score = 0;
				targetEscaped = true;
				enemyPos.Run();
			}
			enemyText.text = "!";
			if(shotText.transform.localScale.y < maxScale.y){
				shotText.transform.localScale += addScale;
			}
		}
		if(shotText.transform.localScale.y >= maxScale.y){
			timer += 1 * Time.deltaTime;
			if(timer >= maxTime){
				timer = 0;
				if(targetEscaped){
					reset.Reset();
				}else if(!gotHeadShot && !gotBodyShot){
					player.ammo += 1;
					Start();
				}else{
					reset.Reset();
				}
			}
		}
	}

	void UpdateText(){
		scoreText.text = "Score: " + score.ToString ();
	}

	public virtual void Headshot(){
		score += 100;
		if(score > highScore){
			highScore = score;
		}
		UpdateText ();
		gotHeadShot = true;
	}

	public virtual void Bodyshot(){
		score += 50;
		if(score > highScore){
			highScore = score;
		}
		UpdateText ();
		gotBodyShot = true;
	}

	public virtual void Miss(){
		missed = true;
		missedCount += 1;
	}
}
