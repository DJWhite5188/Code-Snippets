using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public bool isMainstreamWorld;
    public bool isHipsterWorld;
    public int numMainstream;
    public int numHipster;
    public int numPeople;
    public int random;
    public float changeDelay=0.0f;
    public static WorldManager Instance;
    public GameObject[] People;
    static public WorldManager Get()
    {
        return Instance;
    }

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        

    }

    // Update is called once per frame
    void Update()
    {
        
        numMainstream = GameObject.FindGameObjectsWithTag("Mainstream").Length;
        numHipster = GameObject.FindGameObjectsWithTag("Hipster").Length;
      
        if(numMainstream > numHipster)
        {
            isMainstreamWorld = true;
            isHipsterWorld = false;
        }
        if(numMainstream < numHipster)
        {
            isHipsterWorld = true;
          isMainstreamWorld = false;
        }


        People = GameObject.FindGameObjectsWithTag("Hipster");

        if (numHipster == numPeople)
        {
            changeDelay += 0.1f;
            if (changeDelay >= 10.0f)
            {
                foreach (GameObject p in People)
                {
                    p.gameObject.tag = "Mainstream";
                    p.gameObject.GetComponent<HipsterOrMainstream>().isMainstream = true;
                    p.gameObject.GetComponent<HipsterOrMainstream>().isHipster = false;
                    People[Random.Range(0, People.Length)].gameObject.tag = "Hipster";
                }
            }
        }
        
    }
   
}