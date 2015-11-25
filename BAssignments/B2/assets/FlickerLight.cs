using UnityEngine;
using System.Collections;

public class FlickerLight : MonoBehaviour {

	public float lerpTime = 0.5f;
	private float i = 0;
	
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown(KeyCode.W))    {
		
			
			i+= Time.deltaTime;
		}
		
	}
}
