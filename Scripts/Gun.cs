using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	public float angle;
	public Vector2 wind;
	public Vector3 target;
	public Vector3 startPos;
	public Vector3 bulletDirection;
	public Transform enemyPos;
	public Rigidbody2D Bullet;
	public Rigidbody2D BulletClone;
	public BulletMovement bulletSetUp;
	public TextMesh windText;
	public SpriteRenderer windSprite;
	public Sprite wind1;
	public Sprite wind2;
	public Sprite wind3;
	public Sprite wind4;
	public Sprite wind5;


	void Start(){
		wind.y = Random.Range (0.0f, 0.5f);
		//Debug.Log(wind);
		windText.text = "Wind "; //+ wind.y.ToString ("0.0"); 
		if (wind.y > 0.4f) {
			windSprite.sprite = wind5;
		}else if(wind.y > 0.3f){
			windSprite.sprite = wind4;
		}else if(wind.y > 0.2f){
			windSprite.sprite = wind3;
		}else if(wind.y > 0.1f){
			windSprite.sprite = wind2;
		}else{
			windSprite.sprite = wind1;
		}
	}

	public virtual void Shoot(Vector2 shotPos){

		startPos = transform.position;
//		if(Application.platform == RuntimePlatform.Android){
//			target = Camera.main.ScreenToWorldPoint(touchPos);
//		}else{
//			target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//		}
		target = Camera.main.ScreenToWorldPoint(shotPos);
		bulletDirection = target - startPos;
		bulletDirection = bulletDirection.normalized;

		angle = Vector2.Angle (this.transform.localPosition, enemyPos.position);
		Quaternion bulletRotate;
		if(enemyPos.transform.position.y > this.transform.position.y){
			bulletRotate = Quaternion.Euler (new Vector3 (0, 0, angle - 30));
		}else{
			bulletRotate = Quaternion.Euler (new Vector3 (0, 0, angle - 60));
		}
		bulletSetUp.SetUp (bulletDirection, wind);
		BulletClone = (Rigidbody2D)Instantiate (Bullet, startPos, bulletRotate);

	}


}
