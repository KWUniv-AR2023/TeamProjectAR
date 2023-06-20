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
                    CollisionWithBoss(other.gameObject);
                    break;
            }



            Destroy(gameObject);
        }
    }

    private void CollisionWithMonster(GameObject obj)
    {
        var script = obj.GetComponent<SpiderInfo>();
        script.hp = script.hp - 34;
    }


    private void CollisionWithBoss(GameObject obj)
    {
        var info = obj.GetComponent<BossController>();
        var script = obj.GetComponent<mineCartPath>();
        info.hp = info.hp - 25;
        script.speed -= 0.1f;
    }

}
