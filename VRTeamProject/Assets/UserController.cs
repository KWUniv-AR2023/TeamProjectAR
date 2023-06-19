using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserController : MonoBehaviour
{
    public int hp = 100;

    mineCartPath script;

    // Start is called before the first frame update
    void Start()
    {
        script = gameObject.GetComponent<mineCartPath>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "monster")
        {
            script.speed -= 0.01f;
            hp -= 1;
            // Destroy(other.gameObject);
        }
    }

}
