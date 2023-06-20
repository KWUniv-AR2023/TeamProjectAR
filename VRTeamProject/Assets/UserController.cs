using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserController : MonoBehaviour
{
    public int maxHp = 30;
    public int hp = 30;

    mineCartPath script;

    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
        script = gameObject.GetComponent<mineCartPath>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "monster" && !other.gameObject.GetComponent<SpiderInfo>().touch)
        {
            other.gameObject.GetComponent<SpiderInfo>().touch = true;
            script.speed -= 0.05f;
            hp -= 1;
            // Destroy(other.gameObject);
        }
    }

}
