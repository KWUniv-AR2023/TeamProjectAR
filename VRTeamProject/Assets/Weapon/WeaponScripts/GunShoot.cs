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

    public Transform bulletImpact; // �ü��� ���� ���� ���� ����Ʈ
    ParticleSystem bulletEffect; // ��ƼŬ�ý��� Effect;
    AudioSource bulletAudio; // ����Ʈ ����

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
            // �׸� ��ư�� ������ �� ������ ���� �ۼ�

            //Vector3 controllerPosition = rightHandController.transform.position;
            //Vector3 controllerForward = rightHandController.transform.forward;

            //Ray ray = new Ray(rightHandController.transform.position, rightHandController.transform.forward);

            RaycastHit hitinfo; // Ray�� ��� ��ġ�� ���� ������ ��� �׸�

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
            // Raycast ��� �� ������ �ڵ�
        }

        if (Physics.Raycast(controllerPosition, controllerForward, out hitinfo))
            //if (Physics.Raycast(ray, out hitinfo))
            {
            //�ü��� ���� ������ ������ Ƣ����
            Debug.Log("ray");
                bulletEffect.Stop();
                bulletEffect.Play();

                bulletImpact.transform.forward = hitinfo.normal;
                bulletImpact.transform.position = hitinfo.point;

            }
    }
}
