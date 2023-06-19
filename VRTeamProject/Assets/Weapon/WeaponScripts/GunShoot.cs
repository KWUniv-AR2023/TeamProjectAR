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

    public Transform bulletImpact; // �ü��� ���� ���� ���� ����Ʈ
    ParticleSystem bulletEffect; // ��ƼŬ�ý��� Effect;
    AudioSource bulletAudio; // ����Ʈ ����

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
        // �׸� ��ư�� ������ �� ������ ���� �ۼ�

        Vector3 controllerPosition = rightControllerTransform.position;
        Vector3 controllerForward = rightControllerTransform.forward;

        Ray ray = new Ray(controllerPosition, controllerForward);

        RaycastHit hitinfo = new RaycastHit(); // Ray�� ��� ��ġ�� ���� ������ ��� �׸�


        if (Physics.Raycast(ray, out hitinfo))
        {
            //�ü��� ���� ������ ������ Ƣ����
            bulletEffect.Stop();
            bulletEffect.Play();

            bulletImpact.transform.forward = hitinfo.normal;
            bulletImpact.transform.position = hitinfo.point;

        }
    }

    
}