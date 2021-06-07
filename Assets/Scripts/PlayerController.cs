using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 rotation = Vector3.zero;
    public float speed = 2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotation.y += Input.GetAxis("Mouse X");
        rotation.x += -Input.GetAxis("Mouse Y");
        transform.eulerAngles = (Vector3)rotation * speed;

        transform.Translate(Vector3.forward * Input.GetAxis("Vertical"));
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal"));

        //fake aþaðý komutu
        /*
        if (transform.position.y < 0)
        {
            transform.Translate.y
        }
        */


    }
}

