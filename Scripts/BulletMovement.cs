using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {

	public float speed = 10;
	public float maxScale = 1;
	public Vector2 target;
	public Vector2 wind;
	public Vector2 gravity;
	public Vector3 enemyPos;
	public Vector3 startScale = new Vector2 (0.25f, 0.25f);
	public Vector3 scale = new Vector2(0.005f,0.005f);
	public Transform targetRotate;
	public CheckMissed check;

	void Start () {
		if(this.gameObject.name == "Bullet(Clone)"){
			gravity.y = -0.01f;
			this.transform.localScale = startScale;
			this.rigidbody2D.velocity = (target + wind) * speed;
		}
	}
	
	void Update () {
		if(this.gameObject.name == "Bullet(Clone)"){
			this.rigidbody2D.velocity = this.rigidbody2D.velocity + gravity;
			gravity.y -= 0.0001f;
			if(this.transform.localScale.y < maxScale){
				this.transform.localScale += scale;
			}
			if(this.transform.position.x > 21 || this.transform.position.y < -11){
				check.CheckMiss();
				Destroy(this.gameObject);
			}
		}
	}

	public virtual void SetUp(Vector3 getTarget, Vector2 getWind){
		target = getTarget;
		wind = getWind;
		Start ();
	}
}
