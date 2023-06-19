using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GunShoot : MonoBehaviour
{
    private ActionBasedController actionBasedController;
    private Transform rightControllerTransform;
    //public GameObject bulletFacotry; // �Ѿ��� �����Ǵ� ���
    //public Transform firePosition; // �Ѿ��� �����Ͽ� ��ġ��Ű�� ���

    public Transform bulletImpact; // �ü��� ���� ���� ���� ����Ʈ
    ParticleSystem bulletEffect; // ��ƼŬ�ý��� Effect;
    AudioSource bulletAudio; // ����Ʈ ����


    private void Start()
    {
        actionBasedController = GetComponent<ActionBasedController>();
        rightControllerTransform = actionBasedController.transform;
        //firePosition = Camera.main.transform; // Ȥ�� �ٸ� ī�޶� ����� �� �ֽ��ϴ�.
        bulletEffect = bulletImpact.GetComponent<ParticleSystem>();
        bulletAudio = bulletImpact.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (actionBasedController && actionBasedController.selectAction.action.ReadValue<float>() > 0.5f)
        {
            bulletAudio.Stop();
            bulletAudio.Play();
            // �׸� ��ư�� ������ �� ������ ���� �ۼ�
            Vector3 controllerForward = rightControllerTransform.TransformDirection(Vector3.forward);
            Ray ray = new Ray(rightControllerTransform.position, controllerForward);

            RaycastHit hitinfo = new RaycastHit(); // Ray�� ��� ��ġ�� ���� ������ ��� �׸�


            if (Physics.Raycast(ray, out hitinfo))
            {
                //�ü��� ���� ������ ������ Ƣ����
                bulletEffect.Stop();
                bulletEffect.Play();

                bulletImpact.forward = hitinfo.normal;
                bulletImpact.position = hitinfo.point;

            }
        }
    }
}




