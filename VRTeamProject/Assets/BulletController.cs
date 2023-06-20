using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    Vector3 direction;
    GameObject head;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3);
        head = gameObject.transform.Find("UCP45 Bullet Head").gameObject;
        var body = gameObject.transform.Find("45ACP Bullet_Casing");

        direction = head.transform.position - body.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        head.transform.position += direction * 6;
    }



}
