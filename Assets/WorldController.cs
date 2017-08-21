using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;

public class WorldController : MonoBehaviour {

    public GameObject CreaturePrefab;
    public GameObject TreePrefab;
    public int CreatureCount;
    public int TreeCount;
    public float ArenaRadius;
	// Use this for initialization
	void Start () {
        transform.localScale = new Vector3(ArenaRadius*2,ArenaRadius*2,1);
        for (int i = 0; i < CreatureCount; i++)
        {
            Instantiate(CreaturePrefab,Random.insideUnitCircle*(ArenaRadius-10),Quaternion.Euler(0,0,Random.Range(0,360)));
        }
        for (int i = 0; i < TreeCount; i++)
        {
            Instantiate(TreePrefab, Random.insideUnitCircle * (ArenaRadius - 10), Quaternion.Euler(0, 0, Random.Range(0, 360)));
        }
    }
    Vector3 Origin;
    Vector3 Diference;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Origin = MousePos();
        }
        if (Input.GetMouseButton(0))
        {
            Diference = MousePos() - Camera.main.transform.position;
            Camera.main.transform.position = Origin - Diference;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            Camera.main.orthographicSize *= 1.2f;
        }
        else
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            Camera.main.orthographicSize /= 1.2f;
        }
    }
    // return the position of the mouse in world coordinates (helper method)
    Vector3 MousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
