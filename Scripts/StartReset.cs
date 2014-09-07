using UnityEngine;
using System.Collections;

public class StartReset : MonoBehaviour {



	public virtual void Reset(){
		Application.LoadLevel (1);
	}
}
