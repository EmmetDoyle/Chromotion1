using UnityEngine;
using System.Collections;

public class MoveBlock : MonoBehaviour {


	public Transform blockTransform;
	public SpriteRenderer blockRender;
	public bool begun;
	public float r, g, b;
	public bool passed;
	public bool matched;

	// Use this for initialization
	void Start () {
		blockTransform = this.transform;
		blockRender = gameObject.GetComponent<SpriteRenderer> ();

		Vector3 screenPos = GameObject.Find("MainCamera").GetComponent<Camera>().WorldToScreenPoint(blockTransform.position);
		screenPos.y = 0;


		begun = false;
		passed = false;
		r = 0f;
		g = 0.5f;
		b = 1f;

		blockRender.color = new Color (r, g, b, 1);
	}
	
	// Update is called once per frame
	void Update () {
		if (!begun) {
			blockTransform.position = new Vector3 (blockTransform.position.x, GameObject.Find ("MainCamera").GetComponent<ScreenSize> ().bottomBorder.y, blockTransform.position.z);
			begun = true;
		}

		//move block from bottom to top and repeat
		if (blockTransform.position.y > GameObject.Find ("MainCamera").GetComponent<ScreenSize> ().topBorder.y) {
			ColorPicker();
			blockRender.color = new Color (r, g, b, 1);
			passed = false;
			blockTransform.position = new Vector3 (blockTransform.position.x, GameObject.Find ("MainCamera").GetComponent<ScreenSize> ().bottomBorder.y, blockTransform.position.z);
		} else {
			blockTransform.position = new Vector3 (blockTransform.position.x, (blockTransform.position.y + 0.022f), blockTransform.position.z);
		}

		//compare color of ball to colour of block
		if (GameObject.Find ("Ball").GetComponent<MoveBall> ().r > r - 0.1 && GameObject.Find ("Ball").GetComponent<MoveBall> ().r < r + 0.1) {
			if (GameObject.Find ("Ball").GetComponent<MoveBall> ().g > g - 0.1 && GameObject.Find ("Ball").GetComponent<MoveBall> ().g < g + 0.1) {
				if (GameObject.Find ("Ball").GetComponent<MoveBall> ().b > b - 0.1 && GameObject.Find ("Ball").GetComponent<MoveBall> ().b < b + 0.1) {
					matched = true;
				}
				else {
					matched = false;
				}
			}
			else
			{
				matched = false;
		
			}
		}
		else {
			matched = false;
		}

		if (matched == true && GameObject.Find ("Hole").GetComponent<holePlacement> ().matched == true) {
			passed = true;
		}
	}

	void ColorPicker ()
	{
		Color result;
		int choice;
		float rand;

		choice = Random.Range ((int)0, (int)5);
		rand = Random.Range (0, 1000);

		switch (choice) {
		case 0:
				r = rand / 1000; 
				g = 1; 
				b = 0;
			break;

		case 1:
				r = rand / 1000; 
			    g = 0; 
			    b = 1;
			break;

		case 2:
			    r = 1; 
				g = rand / 1000; 
			    b = 0;
			break;

		case 3: 
				r = 0;
				g = rand / 1000;
			    b = 1;
			break;

		case 4:
			    r = 1;
			    g = 0;
				b = rand / 1000;
			break;

		case 5:
			    r = 0;
			    g = 1;
				b = rand / 1000;
			break;

		}

	}

}
