using UnityEngine;
using System.Collections;

public class EnemyPosition : MonoBehaviour {

	public Transform ground;

	void Start () {
		this.transform.position = new Vector3 (Random.Range (5.0f, 18.0f), Random.Range (-8.0f, 8.0f), 0);
		Vector3 enemyPos = this.transform.position;
		ground.transform.position = new Vector3 (enemyPos.x - 10, enemyPos.y - 24, 0);
	}

	public virtual void Run(){
		this.rigidbody2D.velocity = new Vector2 (7.5f, 0);
	}

}
