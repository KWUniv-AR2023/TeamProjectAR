using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
//using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class GunShoot : MonoBehaviour
{
    public XRController rightHandController;
    //public Transform rightControllerTransform;

    public Transform bulletImpact; // 시선이 닿을 곳에 생길 이펙트
    ParticleSystem bulletEffect; // 파티클시스템 Effect;
    AudioSource bulletAudio; // 이펙트 사운드

    private void Start()
    {
        rightHandController = GetComponent<XRController>();
        //rightControllerTransform = xrController.transform;

        bulletEffect = bulletImpact.GetComponent<ParticleSystem>();
        bulletAudio = bulletImpact.GetComponent<AudioSource>();
    }

    private void Update()
    {

    }

    public void Shoot()
    {
        //Debug.Log("Shoot");
            //bulletAudio.Stop();
            //bulletAudio.Play();
            // 그립 버튼이 눌렸을 때 수행할 동작 작성

            //Vector3 controllerPosition = rightHandController.transform.position;
            //Vector3 controllerForward = rightHandController.transform.forward;

            //Ray ray = new Ray(rightHandController.transform.position, rightHandController.transform.forward);

            RaycastHit hitinfo; // Ray가 닿는 위치에 대한 정보를 담는 그릇

        if (rightHandController == null || rightHandController.inputDevice == null)
        {
            Debug.Log("Right hand controller or input device is not set.");
            return;
        }

        Vector3 controllerPosition = Vector3.zero;
        Vector3 controllerForward = Vector3.forward;

        if (rightHandController.inputDevice.TryGetFeatureValue(CommonUsages.devicePosition, out controllerPosition) &&
            rightHandController.inputDevice.TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion controllerRotation))
        {
            controllerForward = controllerRotation * Vector3.forward;
            // Raycast 사용 등 나머지 코드
        }

        if (Physics.Raycast(controllerPosition, controllerForward, out hitinfo))
            //if (Physics.Raycast(ray, out hitinfo))
            {
            //시선이 닿은 지점에 파편이 튀도록
            Debug.Log("ray");
                bulletEffect.Stop();
                bulletEffect.Play();

                bulletImpact.transform.forward = hitinfo.normal;
                bulletImpact.transform.position = hitinfo.point;

            }
    }
}
