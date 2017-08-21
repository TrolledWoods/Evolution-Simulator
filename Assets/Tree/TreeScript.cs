using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour {
    public GameObject EnergyObject;
    public GameObject BranchPrefab;
    public GameObject FoodPrefab;
    public GameObject EnergyBuffer;
    GameObject[] Branches;
    BranchScript[] Scripts;
    float AreaPerBranch = 5;
    float EnergyPerFood = 200;
    float EnergyRadius;
    float EnergyRadiusPerBranch = 1.5f;
    float EnergyRadiusBase = 4;
    float LifeTime;
    float LifeTimeMax = 180;//seconds
    float Energy;
    float CurrentMaxEnergy;
    float EnergyGainMultiplier=1;
    int currentBranch;
    //this happens before start
    void Awake()
    {
        int amount = Random.Range(3, 7);
        float a = 360 / amount;
        Branches = new GameObject[amount];
        Scripts = new BranchScript[amount];
        for (int i = 0; i < amount; i++)
        {
            Branches[i]=(Instantiate(BranchPrefab, transform.position, Quaternion.Euler(0, 0, a * i + Random.Range(-a / 3, a / 3)), transform));
            Scripts[i] = Branches[i].GetComponent<BranchScript>();
            Scripts[i].foodEnergy = EnergyPerFood;
        }
        EnergyRadius = EnergyRadiusBase + EnergyRadiusPerBranch * amount;
        EnergyObject.GetComponent<SpriteRenderer>().transform.localScale = new Vector3(EnergyRadius * 2 / transform.lossyScale.x, EnergyRadius * 2 / transform.lossyScale.y, 1);
    }
    // Use this for initialization
    void Start()
    {
        GameObject[] OtherTrees = GameObject.FindGameObjectsWithTag("Tree");
        foreach (GameObject G in OtherTrees)
        {
            if(G!=transform.gameObject)
            {
                TreeScript OtherScript = G.GetComponent<TreeScript>();
                float dist = (transform.position - G.transform.position).magnitude;
                if (dist< OtherScript.EnergyRadius + EnergyRadius)//if their energy circles are touching
                {
                    EnergyObject.GetComponent<SpriteRenderer>().color=new Color(1,0,1,0.1f);
                    EnergyGainMultiplier *= 1 - (getCoveredArea(EnergyRadius, OtherScript.EnergyRadius, dist) / (Mathf.PI * (EnergyRadius * EnergyRadius)))/2;
                }
            }
        }
        currentBranch = Random.Range(0,Branches.Length);
        Energy = EnergyPerFood;
        Color C = FoodPrefab.GetComponent<SpriteRenderer>().color;
        EnergyBuffer.GetComponent<SpriteRenderer>().color = new Color(C.r, C.g, C.b, 0.5f);
        foreach (BranchScript B in Scripts)
        {
            B.EnergySprite.color = new Color(C.r, C.g, C.b, 0.5f);
        }
    }
    float getCoveredArea(float Rad1,float Rad2,float Dist)
    {
        if(Dist<Mathf.Abs(Rad1-Rad2))//one is inside the other
        {
            float R = Mathf.Min(Rad1, Rad2);
            return R * R;
        }
        float D1 = (Dist*Dist+Rad1*Rad1-Rad2*Rad2)/(2*Dist);//from object 1 to intersect line
        float D2 = Dist - D1;//from object 2 to intersect line
        float A = getChordArea(Rad1, D1) + getChordArea(Rad2, D2);
        return A;
    }
    float getChordArea(float Rad,float Dist)
    {
        return Rad*Rad*(float)System.Math.Acos(Dist/Rad)-Dist*Mathf.Sqrt(Rad*Rad-Dist*Dist);
    }
    // Update is called once per frame
    void Update ()
    {
        Energy += addEnergy();
        Energy -= removeBaseEnergy();
        Energy -= removeFoodEnergy();
        CurrentMaxEnergy = Mathf.Max(CurrentMaxEnergy,Energy);
        float s = Energy/CurrentMaxEnergy;
        EnergyBuffer.transform.localScale=new Vector3(s,s,1);
        if(Energy<0)
        {
            Destroy(gameObject);
        }
        LifeTime+=Time.deltaTime;
        if(Scripts[currentBranch].Energy>EnergyPerFood)
        {
            Scripts[currentBranch].SpawnFood(FoodPrefab);
            int c = Random.Range(0, Branches.Length-1);
            if (c >= currentBranch)
                c++;
            currentBranch = c;
        }
	}
    float addEnergy()
    {
        float L = LifeTime / LifeTimeMax;
        return 1*(1-(L*L))*(1+Branches.Length/20.0f)*EnergyGainMultiplier;
    }
    float removeBaseEnergy()
    {
        return 0.9f * (1+EnergyGainMultiplier)/2;
    }
    float removeFoodEnergy()
    {
        float E = Mathf.Max(Energy-EnergyPerFood,0)*0.01f;
        Scripts[currentBranch].Energy += E;
        return E;
    }
}
