using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = default;
    private Rigidbody rigid = default;


    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.velocity = transform.forward * speed;


        Destroy(gameObject, 2.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Ʈ���� : �Ѿ��� �����ΰ��� �ε�����.");
        if (other.tag.Equals("Player")) 
        {
            PlayerController playerController = other.GetComponent<PlayerController>();

            if(playerController != null) 
            {
                playerController.Die();
            }
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("�ݶ��̴� : �Ѿ��� �����ΰ��� �ε�����.");
    //}



    // Update is called once per frame
    void Update()
    {
        
    }
}
