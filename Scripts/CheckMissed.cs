using UnityEngine;
using System.Collections;

public class CheckMissed : MonoBehaviour {

	public EnemyCollision head;
	public EnemyCollision body;
	public Score score;

	public virtual void CheckMiss(){
		if (!head.coll && !body.coll){
			score.Miss ();
		}
	}
}
