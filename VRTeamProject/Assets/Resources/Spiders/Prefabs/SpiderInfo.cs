using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderInfo: MonoBehaviour
{
    public int hp = 100;
    Animator ani;
    mineCartPath script;
    // Start is called before the first frame update
    void Start()
    {
         ani = gameObject.GetComponent<Animator>();
        script = gameObject.GetComponent<mineCartPath>();
        
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

        script.enabled = false;
        ani.SetInteger("hp", 0);
        ani.SetBool("die", true);
        ani.StopPlayback();
        Invoke("Destroys", 2);
    }

    void Destroys()
    {
        Destroy(gameObject);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log($"{other.gameObject.name}");
            ani.SetInteger("attack", ani.GetInteger("attack") + 1);
            script.speed = other.GetComponent<mineCartPath>().speed;
            Invoke("Die", 2);
        }
    }
}
