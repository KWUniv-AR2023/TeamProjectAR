using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GunShoot : MonoBehaviour
{
    private XRController xrController;
    private Transform rightControllerTransform;

    public Transform bulletImpact; // 시선이 닿을 곳에 생길 이펙트
    ParticleSystem bulletEffect; // 파티클시스템 Effect;
    AudioSource bulletAudio; // 이펙트 사운드

    private void Start()
    {
        xrController = GetComponent<XRController>();
        rightControllerTransform = xrController.transform;
        


        bulletEffect = bulletImpact.GetComponent<ParticleSystem>();
        bulletAudio = bulletImpact.GetComponent<AudioSource>();
    }

    private void Update()
    {
        
    }

    public void Shoot()
    {
        bulletAudio.Stop();
        bulletAudio.Play();
        // 그립 버튼이 눌렸을 때 수행할 동작 작성

        Vector3 controllerPosition = rightControllerTransform.position;
        Vector3 controllerForward = rightControllerTransform.forward;

        Ray ray = new Ray(controllerPosition, controllerForward);

        RaycastHit hitinfo = new RaycastHit(); // Ray가 닿는 위치에 대한 정보를 담는 그릇


        if (Physics.Raycast(ray, out hitinfo))
        {
            //시선이 닿은 지점에 파편이 튀도록
            bulletEffect.Stop();
            bulletEffect.Play();

            bulletImpact.transform.forward = hitinfo.normal;
            bulletImpact.transform.position = hitinfo.point;

        }
    }

    
}