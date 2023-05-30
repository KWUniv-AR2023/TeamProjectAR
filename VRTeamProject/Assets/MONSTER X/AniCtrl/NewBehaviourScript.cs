using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        int h = animator.GetInteger("hp");
        if(h != 0)
            animator.SetInteger("hp", h - 1);
        if(h == 0)
        {
            animator.SetBool("die", true);
        }
    }
}
