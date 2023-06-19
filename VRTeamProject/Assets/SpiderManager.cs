using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class SpiderManager : MonoBehaviour
{
    float GameTime = 0;
    GameObject prefab;
    GameObject current;

    int railParent;
    int railChild;

    // Start is called before the first frame update
    void Start()
    {
        prefab = Resources.Load("Spiders/Prefabs/Black Widow") as GameObject;
        current = gameObject;
        mineCartPath src = GameObject.FindWithTag("Player").GetComponent<mineCartPath>();

        railParent = src.currentRailParent;
        railChild = src.currentRailChild;

    }
    
    void Make()
    {
        GameObject obj = Instantiate(prefab);// Resources.Load("Spiders/Prefabs/Black Widow"));
        obj.SetActive(false);
        // rail script copy
        obj.AddComponent<mineCartPath>();
        obj.tag = "monster";
        // mineCartPath
        {
            mineCartPath script = obj.GetComponent<mineCartPath>();
            mineCartPath src = GameObject.FindWithTag("Player").GetComponent<mineCartPath>();
            script.railObject = new List<PathObject>(src.railObject);
            //script.currentRailParent = railParent;
            //script.currentRailChild = railChild;

            //railParent = src.currentRailParent;
            //railChild = src.currentRailChild;


            script.offset = new Vector3(
                UnityEngine.Random.Range(0,1f),
                UnityEngine.Random.Range(0,2f),
                UnityEngine.Random.Range(0,1f)
            );
            script.speed = src.speed - 1f;
            script.maxSpeed = src.maxSpeed+1f;
            script.minSpeed = src.minSpeed+1f;

            script.degree = 90f;
            script.obj = obj;
            script.AutoPositionSet = false;

            GameObject rail = src.GetCurrentRailObject();
            Vector3 path = rail.transform.position;

            path.y -= 20;
            obj.transform.position = path;

            script.currentRailParent = src.currentRailParent;
            script.currentRailChild = src.currentRailChild;

            current = obj;
        }

        current.SetActive(true);
        //src.Invoke("Update", 1);
    }

    // Update is called once per frame
    void Update()
    {
        GameTime += Time.deltaTime;
        if(GameTime > UnityEngine.Random.Range(1200,1600) * Time.deltaTime)
        {
            Make();
            GameTime = 0;
        }
    }
}
