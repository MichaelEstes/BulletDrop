using UnityEngine;
using System.Collections;

public class PlayerPosition : MonoBehaviour {

	void Start () {
		this.transform.position = new Vector3 (-15, Random.Range (-8.0f, 6.0f), 0);
	}
	
}
