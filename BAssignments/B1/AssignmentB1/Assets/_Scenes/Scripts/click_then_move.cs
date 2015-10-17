using UnityEngine;
using System.Collections;

public class click_then_move : MonoBehaviour {

    private bool selected = false;
    private NavMeshAgent agent;
    private Vector3 MoveTo;
    private bool move = false;

    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (selected && move)
        {
            agent.SetDestination(MoveTo);
            move = false;
        }
        if (selected)
        {
           // gameObject.GetComponent<Renderer>.material.color = Color.white;
        }
    }

    void Select(int x)
    {
        selected = true;
        // Debug.Log("Selected");
    }

    void Deselect(int x)
    {
        selected = false;
        // Debug.Log("Deselected");
    }

    void Destination(Vector3 d)
    {
        MoveTo = d;
        move = true;
    }

    /*
    // Old Script
	private NavMeshAgent agent;
	void Start() {
		agent = GetComponent<NavMeshAgent>();
	}
	void Update() {
		RaycastHit hit;
		if (Input.GetMouseButtonDown(0)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
				agent.SetDestination(hit.point);
			
		}
	}
    */
}