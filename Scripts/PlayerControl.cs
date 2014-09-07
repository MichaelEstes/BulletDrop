using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public int ammo;
	public Vector2 touchPos;
	public Gun gun;
	public Animator sniperAnimation;
	public Touch touch;
	public bool touchControls = false;

	void Start () {
		ammo = 1;
	}

	void Update ()
	{
		if(Application.platform == RuntimePlatform.Android){
			touch = Input.GetTouch (0);
			touchControls = true;
		}
		if(touchControls){
			if(touch.phase == TouchPhase.Began)
			{
				//touchPos = touch.position;
				if(ammo > 0){
					gun.Shoot(touch.position);
					sniperAnimation.SetTrigger("Shot");
					ammo -= 1;
				}
			}
		}else{
			if(Input.GetButtonDown("Fire1"))
			{
				if(ammo > 0){
					gun.Shoot(Input.mousePosition);
					sniperAnimation.SetTrigger("Shot");
					ammo -= 1;
				}
			}if (Input.GetKeyDown(KeyCode.Escape)){
				Application.Quit();
			}
		}
	}
}
