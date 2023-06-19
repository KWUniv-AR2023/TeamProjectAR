using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffFire : MonoBehaviour
{
    public XRController rightHandController;
    //public Transform rightControllerTransform;

    public Transform bulletImpact; // 시선이 닿을 곳에 생길 이펙트
    ParticleSystem bulletEffect; // 파티클시스템 Effect;
    AudioSource bulletAudio; // 이펙트 사운드

    // Start is called before the first frame update
    void Start()
    {
        bulletEffect = bulletImpact.GetComponent<ParticleSystem>();
        bulletAudio = bulletImpact.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Fire()
}
