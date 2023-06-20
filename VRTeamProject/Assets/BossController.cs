using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public int maxHp = 1000;
    public int hp;

    Animator animator;
    mineCartPath script;

    float AniSpeed(float speed)
    {
        return speed / 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
        animator = GetComponent<Animator>();
        script = GetComponent<mineCartPath>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hp <= 0 && script.enabled)
        {
            Die();

        }
    }

    void Die()
    {
        animator.SetBool("Die", true);
        GameObject.FindWithTag("Player").GetComponent<mineCartPath>().enabled = false;

        script.enabled = false;
        Destroy(GameObject.Find("SpiderMaker").gameObject);
        Destroy(gameObject, 3f);
    }
    

    public void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            var targetScript = other.gameObject.GetComponent<mineCartPath>();
            targetScript.enabled = false;
            Destroy(GameObject.Find("SpiderMaker").gameObject);

            gameObject.SetActive(false);

        }
    }
}
