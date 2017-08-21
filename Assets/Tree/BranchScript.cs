using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchScript : MonoBehaviour {
    public float Energy;
    public float foodEnergy;
    public GameObject Leaf;
    public SpriteRenderer EnergySprite;
    public GameObject EnergyObject;
    // Use this for initialization
    void Awake () {
        EnergySprite = EnergyObject.GetComponent<SpriteRenderer>();
	}
    public void SpawnFood(GameObject Food)
    {
        Energy = 0;
        Vector2 SpawnPos = (Vector2)Leaf.transform.position+(Leaf.transform.lossyScale.x-Food.transform.lossyScale.x)*Random.insideUnitCircle/2;
        Instantiate(Food,SpawnPos,Quaternion.Euler(0,0,Random.Range(0,360)));
    }
	
	// Update is called once per frame
	void Update () {
		if(Energy>0)
        {
            EnergySprite.enabled = true;
            float s = Energy / foodEnergy;
            EnergyObject.transform.localScale = new Vector3(s,s,1);
        }
        else
        {
            EnergySprite.enabled = false;
        }
	}
}
