using UnityEngine;
using System.Collections;

public class IntroText : MonoBehaviour {

	public float timer = 0;
	public float maxTime = 2.5f;
	public TextMesh instructionText;
	public Touch touch;

	void Update () {

		if(timer < maxTime){
			timer += 1 * Time.deltaTime;
		}else{
			instructionText.text = "Tap to continue";
		}
		if(Application.platform == RuntimePlatform.Android){
			touch = Input.GetTouch (0);
			if(touch.phase == TouchPhase.Began){
				Application.LoadLevel(1);
			}
		}else{
			if(Input.GetButtonDown("Fire1")){
			Application.LoadLevel(1);
			}
		}if (Input.GetKeyDown(KeyCode.Escape)){
			Application.Quit();
		}
	}
}
