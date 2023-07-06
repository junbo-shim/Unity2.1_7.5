using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigid = default;
    public float speed = default;
    public float rotSpeed = default;
    public GameObject dieEffect = default;
    // Start is called before the first frame update
    void Start()
    {
        playerRigid = GetComponent<Rigidbody>();

        playerRigid = null;

        Debug.Assert(playerRigid != null);

        if(playerRigid == null) 
        {
            Debug.LogError("에러가 나용");
        }
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * rotSpeed * Time.deltaTime;
        float zSpeed = zInput * speed * Time.deltaTime;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);

        playerRigid.velocity = newVelocity;


        // 다른 이동 함수
        //playerRigid.MovePosition(playerRigid.position + transform.forward * zSpeed);
        //playerRigid.MoveRotation(playerRigid.rotation * Quaternion.Euler(Vector3.up * xSpeed));

 

    }       // Update()

    public void Die()
    {
        GameObject effect = Instantiate(dieEffect, this.transform.position,this.transform.rotation);
        Destroy(effect, 1.0f);


        gameObject.SetActive(false);

        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.EndGame();

    }


}       // PlayerController


