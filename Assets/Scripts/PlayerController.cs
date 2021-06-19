using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Particle playerObje;
    // Start is called before the first frame update
    Vector3 rotation = Vector3.zero;
    public float speed = 2;
    public float playerSpeed = 30;
    void Start()
    {
        playerObje = GetComponent<Particle>();
    }

    // Update is called once per frame
    void Update()
    {
        rotation.y += Input.GetAxis("Mouse X");
        rotation.x += -Input.GetAxis("Mouse Y");
        transform.eulerAngles = (Vector3)rotation * speed;


       // transform.Translate(Vector3.forward * Input.GetAxis("Vertical"));
       // transform.Translate(Vector3.right * Input.GetAxis("Horizontal"));
        
        playerObje = Particle.AddForce(Input.GetAxis("Vertical") *new Vector3d(0, 0, 30), playerObje);
        //playerObje.position = Vector3d.getPosition(transform.position);


        //fake aþaðý komutu
        /*
        if (transform.position.y < 0)
        {
            transform.Translate.y
        }
        */


    }
}

