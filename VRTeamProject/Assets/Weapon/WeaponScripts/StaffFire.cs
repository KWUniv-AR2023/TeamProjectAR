using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffFire : MonoBehaviour
{
    public XRController rightHandController;
    //public Transform rightControllerTransform;

    public Transform bulletImpact; // �ü��� ���� ���� ���� ����Ʈ
    ParticleSystem bulletEffect; // ��ƼŬ�ý��� Effect;
    AudioSource bulletAudio; // ����Ʈ ����

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
