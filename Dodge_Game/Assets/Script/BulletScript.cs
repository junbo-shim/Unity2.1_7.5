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
        Debug.Log("트리거 : 총알이 무엇인가와 부딪혔다.");
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
    //    Debug.Log("콜라이더 : 총알이 무엇인가와 부딪혔다.");
    //}



    // Update is called once per frame
    void Update()
    {
        
    }
}
