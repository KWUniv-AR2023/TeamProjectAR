using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    bool isDetect = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!isDetect) // bullet
        {
            isDetect = true;
            switch (other.transform.tag)
            {
                case "monster":
                    CollisionWithMonster(other.gameObject);

                    break;
                case "boss":

                    break;
            }



            Destroy(gameObject);
        }
    }

    private void CollisionWithMonster(GameObject obj)
    {
        var script = gameObject.GetComponent<SpiderInfo>();
        script.hp = script.hp - 34;
    }


    private void CollisionWithBoss(GameObject obj)
    {

    }

}
