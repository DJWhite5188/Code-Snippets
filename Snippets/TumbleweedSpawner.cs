using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;




public class TumbleweedSpawner : MonoBehaviour
{
    private float nextSpawn;
    public float spawnDelay = 10f;
    public GameObject Target;
    public float timeToDespawn;
    public float tumbleSpeed;
    public bool isCorral;
    public bool isCyber;
    public GameObject OkCorralObstacle;
    public GameObject CyberObstacle;

    [Header("CyberCityOptions")]
    public bool xLock;
    public bool zLock;
    public bool yLock;
    
    


    void Awake()
    {
        if(SceneManager.GetActiveScene().name == "A-OK-Corrall")
        {
            isCorral = true;
            isCyber = false;
        }
        if (SceneManager.GetActiveScene().name == "CyberCity")
        {
            isCorral = false;
            isCyber = true;
        }

    }
    private void Update()
    {
        if (isCorral == true)
        {
            isCyber = false;
            if (Time.time >= nextSpawn)
            {
                SpawnTumbleweed();
            }
        }

        if (isCyber == true)
        {
            isCorral = false;
            if (Time.time >= nextSpawn)
            {
                SpawnCyberObstacle();

            }
        }
    }

    private void SpawnTumbleweed()
    {
        nextSpawn = Time.time + spawnDelay;
        GameObject tumbleWeed = Instantiate(OkCorralObstacle, transform.position, transform.rotation);
        tumbleWeed.transform.SetParent(this.transform, true);
        tumbleWeed.GetComponent<SlowdownObstacle>().target = Target;
        tumbleWeed.GetComponent<SlowdownObstacle>().enabled = true;
    }

    private void SpawnCyberObstacle()
    {
        nextSpawn = Time.time + spawnDelay;
        GameObject obstacle = Instantiate(CyberObstacle, transform.position, Target.transform.rotation);
        obstacle.transform.SetParent(this.transform, true);
       
        if(xLock == true)
        {
            obstacle.GetComponent<Rigidbody>().constraints |= RigidbodyConstraints.FreezePositionX;
            
        }
        if (yLock == true)
        {
            obstacle.GetComponent<Rigidbody>().constraints |= RigidbodyConstraints.FreezePositionY;
        }
        if (zLock == true)
        {
            obstacle.GetComponent<Rigidbody>().constraints |= RigidbodyConstraints.FreezePositionZ;
        }
        


        obstacle.GetComponent<CyberObstacle>().target = Target;
        obstacle.GetComponent<CyberObstacle>().enabled = true;

    }


}
