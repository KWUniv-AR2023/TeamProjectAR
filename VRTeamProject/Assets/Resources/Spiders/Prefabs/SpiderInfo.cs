using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderInfo: MonoBehaviour
{
    public int hp = 100;
    Animator ani;
    // Start is called before the first frame update
    void Start()
    {
         ani = gameObject.GetComponent<Animator>();
        Debug.Log(gameObject.name);
        
    }

    // Update is called once per frame
    void Update()
    {
        ani.SetInteger("hp", hp);
        if(hp == 0)
        {
            Die();
        }

    }

    void Die()
    {
        Animator ani = gameObject.GetComponent<Animator>();

        ani.SetInteger("hp", 0);
        
        Destroy(gameObject);
    }

}
