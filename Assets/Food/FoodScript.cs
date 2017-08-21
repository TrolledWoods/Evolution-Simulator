using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().angularVelocity = Random.Range(-90,90);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
