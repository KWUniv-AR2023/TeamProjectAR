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
        userTransform = Camera.main.transform; // 혹은 다른 카메라를 사용할 수 있습니다.
    }

    private void Update()
    {
        if (actionBasedController && actionBasedController.selectAction.action.ReadValue<float>() > 0.5f)
        {
            // 그립 버튼이 눌렸을 때 수행할 동작 작성
            Shoot();
        }
    }

    private void Shoot()
    {
        // 총알이 발사되는 동작을 구현
        Vector3 userPosition = userTransform.position;
    }
}




