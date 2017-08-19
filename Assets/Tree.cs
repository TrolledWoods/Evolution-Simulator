using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour {

    public GameObject Branch;
    List<GameObject> Branches = new List<GameObject>();
    int FoodPerBranch = 3;
    float AreaPerBranch = 5;
    float EnergyPerFood = 100;
    // Use this for initialization
    void Start()
    {
        int amount = Random.Range(3, 7);
        float a = 360 / amount;
        for (int i = 0; i < amount; i++)
        {
            Branches.Add(Instantiate(Branch, transform.position, Quaternion.Euler(0, 0, a * i + Random.Range(-a / 3, a / 3)), transform));
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
