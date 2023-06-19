using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
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
        if(other.transform.tag == "Player")
        {
            var targetScript = other.gameObject.GetComponent<mineCartPath>();
            targetScript.enabled = false;
            Destroy(GameObject.Find("SpiderMaker").gameObject);

            var mob = GameObject.FindGameObjectsWithTag("monster");
            foreach(var m in mob)
            {
                Destroy(m.gameObject);
            }

            gameObject.SetActive(false);

        }
    }
}
