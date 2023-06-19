using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Gun : MonoBehaviour
{
    private ActionBasedController actionBasedController;
    private Transform userTransform;


    private void Start()
    {
        actionBasedController = GetComponent<ActionBasedController>();
        userTransform = Camera.main.transform; // Ȥ�� �ٸ� ī�޶� ����� �� �ֽ��ϴ�.
    }

    private void Update()
    {
        if (actionBasedController && actionBasedController.selectAction.action.ReadValue<float>() > 0.5f)
        {
            // �׸� ��ư�� ������ �� ������ ���� �ۼ�
            Shoot();
        }
    }

    private void Shoot()
    {
        // �Ѿ��� �߻�Ǵ� ������ ����
        Vector3 userPosition = userTransform.position;
    }
}




