﻿using UnityEngine;
using System.Collections;

public class click_then_move : MonoBehaviour {
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
}