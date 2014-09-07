using UnityEngine;
using System.Collections;

public class CameraSetup : MonoBehaviour {


	void Start () {
		this.camera.aspect = 16f/9f;
		Screen.orientation = ScreenOrientation.Landscape;
	}
}
