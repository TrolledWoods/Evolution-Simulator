using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;

public class WorldController : MonoBehaviour {

    public Object CreaturePrefab;
    public int CreatureCount;

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

        GameObject T = (GameObject)GameObject.Instantiate(CreaturePrefab, Position, Quaternion.identity);
        Creatures.Add(new Creature(T));

    }
}
