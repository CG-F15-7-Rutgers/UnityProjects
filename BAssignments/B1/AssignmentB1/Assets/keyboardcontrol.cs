using UnityEngine;
using System.Collections;

//public float speed = 5.0f;

public class keyboardcontrol : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		// Update is called once per frame

	}
	

	void Update()
	{
		if(Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate(new Vector3(5 * Time.deltaTime,0,0));
		}
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Translate(new Vector3(-5 * Time.deltaTime,0,0));
		}
		if(Input.GetKey(KeyCode.DownArrow))
		{
			transform.Translate(new Vector3(0,-5 * Time.deltaTime,0));
		}
		if(Input.GetKey(KeyCode.UpArrow))
		{
			transform.Translate(new Vector3(0,5 * Time.deltaTime,0));
		}
	}
}
