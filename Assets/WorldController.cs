using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;

public class WorldController : MonoBehaviour {

    public GameObject CreaturePrefab;
    public GameObject TreePrefab;

    public int CreatureCount;
    public static System.Random Rnd = new System.Random();
    List<Creature> Creatures;

	// Use this for initialization
	void Start () {
        Creatures = new List<Creature>();
        for (int i = 0; i < CreatureCount; i++)
        {
            SpawnCreature(new Vector3(0, 0, 0));
        }
	}
	
	// Update is called once per frame
	void Update () {
	}

    void SpawnCreature(Vector3 Position){

        //GameObject T = Instantiate(CreaturePrefab, Position, Quaternion.identity);
    }
}
