using UnityEngine;
using System.Collections;

public class ScreenSize : MonoBehaviour {

	public Transform screenTransform;

	public int screenWidth;
	public int section1, section2, section3, section4, section5, section6;
	public Vector3 bottomBorder;
	public Vector3 topBorder;
	public Vector3 leftBorder;
	public Vector3 rightBorder;


	public float dist;  


	public bool printed;

	// Use this for initialization
	void Start () {


		screenTransform = this.transform;

		dist = (transform.position.y);
		print ("dist is " + dist);

		screenWidth = Screen.width;
		section1 = screenWidth / 6;
		section2 = (int)(screenWidth / 6) * 2;
		section3 = (int)(screenWidth / 6) * 3;
		section4 = (int)(screenWidth / 6) * 4;
		section5 = (int)(screenWidth / 6) * 5;
		section6 = (int)screenWidth;

		printed = false;
	}
	
	// Update is called once per frame
	void Update () {
		bottomBorder = camera.ScreenToWorldPoint(new Vector3(camera.pixelWidth / 2, 0, 0));
		topBorder = camera.ScreenToWorldPoint(new Vector3(camera.pixelWidth / 2, camera.pixelHeight, 0));
		leftBorder = camera.ScreenToWorldPoint(new Vector3(0, camera.pixelHeight / 2, 0));
		rightBorder = camera.ScreenToWorldPoint(new Vector3(camera.pixelWidth, camera.pixelHeight / 2, 0));

		if (!printed) {
			print ("top is " + topBorder.y);
			printed = true;
		}
	
	}
}
