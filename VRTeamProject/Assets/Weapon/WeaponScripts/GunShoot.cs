using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GunShoot : MonoBehaviour
{
    private ActionBasedController actionBasedController;
    private Transform rightControllerTransform;
    //public GameObject bulletFacotry; // 총알이 생성되는 장소
    //public Transform firePosition; // 총알을 생성하여 위치시키는 장소

    public Transform bulletImpact; // 시선이 닿을 곳에 생길 이펙트
    ParticleSystem bulletEffect; // 파티클시스템 Effect;
    AudioSource bulletAudio; // 이펙트 사운드


    private void Start()
    {
        actionBasedController = GetComponent<ActionBasedController>();
        rightControllerTransform = actionBasedController.transform;
        //firePosition = Camera.main.transform; // 혹은 다른 카메라를 사용할 수 있습니다.
        bulletEffect = bulletImpact.GetComponent<ParticleSystem>();
        bulletAudio = bulletImpact.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (actionBasedController && actionBasedController.selectAction.action.ReadValue<float>() > 0.5f)
        {
            bulletAudio.Stop();
            bulletAudio.Play();
            // 그립 버튼이 눌렸을 때 수행할 동작 작성
            Vector3 controllerForward = rightControllerTransform.TransformDirection(Vector3.forward);
            Ray ray = new Ray(rightControllerTransform.position, controllerForward);

            RaycastHit hitinfo = new RaycastHit(); // Ray가 닿는 위치에 대한 정보를 담는 그릇


            if (Physics.Raycast(ray, out hitinfo))
            {
                //시선이 닿은 지점에 파편이 튀도록
                bulletEffect.Stop();
                bulletEffect.Play();

                bulletImpact.forward = hitinfo.normal;
                bulletImpact.position = hitinfo.point;

            }
        }
    }
}




