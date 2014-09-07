using UnityEngine;
using System.Collections;

public class EnemyCollision : MonoBehaviour {

	public Vector2 hitPos;
	public Transform bullet;
	public Quaternion bloodRotation;
	public ParticleSystem blood;
	public string objectName;
	public bool coll = false;
	public Score score;

	void Start(){
		blood.enableEmission = false;
	}

	void OnTriggerEnter2D(Collider2D collider) {
			if(this.gameObject.name == "Head"){
				score.Headshot();
			}else{
				score.Bodyshot();
			}
			hitPos = collider.transform.position;
			float angle = Vector2.Angle (this.transform.position, hitPos);
			angle -= 60;
			bloodRotation = Quaternion.Euler( new Vector3(angle,270,0));
			blood.transform.rotation = bloodRotation;
			blood.transform.position = collider.transform.localPosition;
			blood.enableEmission = true;
			coll = true;
	}
}
