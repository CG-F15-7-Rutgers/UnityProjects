using UnityEngine;
using System.Collections;

public class Tranistions : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void gotoS1() {
        Application.LoadLevel("ThreeChoice");
    }
    public void gotoS2() {
        Application.LoadLevel("Part 2");
    }
    public void gotoS3() {
        Application.LoadLevel("Part 3");
    }
    public void goto1A() {
        Application.LoadLevel("Part 1");
    }
    public void goto2A() {

    }
    public void goto3A() {

    }
}
