using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {

	string message = "";
	string message1 = "";
	string message2 = "";

	bool NOTgotObject = true;


		void OnTriggerEnter(Collider other) {
			
		if ((other.tag == "CubeCollider") && (gameObject.tag == "Player")) {

			if (NOTgotObject == false ){
				message = "";
				message2 = "";
				message1 = "congrats you've gotten the object .. thank you <3";

			}
			else if(NOTgotObject == true) 
			{
				message = "hi!! welcome to the game. get to the other side to get an object!!";
				message = "";
				message2 = "";
			}

	}
		/*else if ((other.tag == "CubeCollider") && (gameObject.tag == "Player") && (gotObject == true)) {
			//Destroy (other.gameObject);
			message = "";
			message2 = "";
			message1 = "congrats you've gotten the object .. thank you <3";
			
		} */
		else if ((other.tag == "ObjectWanted") && (gameObject.tag == "Player")) {

			message1 = "";
			message = "";
			message2 = "yeah! thats the object, bring it back!!";
			NOTgotObject=false;
			Destroy (other.gameObject);
			
		}


		}

	void OnTriggerExit(Collider other)
	{
		string message = "";
		string message1 = "";
		string message2 = "";

	}

	void OnGUI()
	{
		GUI.Label(new Rect(200, 200, 200, 200), message);
		GUI.Label(new Rect(200, 200, 200, 200), message1);
		GUI.Label(new Rect(200, 200, 200, 200), message2);

	}


}
