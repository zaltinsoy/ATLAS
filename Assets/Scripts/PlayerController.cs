using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using System.IO;

public class PlayerController : MonoBehaviour
{
    private Particle playerObje;
    Vector3 rotation = Vector3.zero;
    public float speed = 2;
    public float playerSpeed = 30;
    private float a;
    private float b;
    private float c;
    private float d;
    private Vector3d rot;
    private Vector3d rot2;
    private float ver;
    private float hor;
    void Start()
    {
        playerObje = GetComponent<Particle>();
    }

    // Update is called once per frame
    void Update()
    {
        rotation.y += Input.GetAxis("Mouse X");
        rotation.x += -Input.GetAxis("Mouse Y");
        transform.eulerAngles = (Vector3)rotation * speed; //rotation of the character

        a = Mathf.Cos(Mathf.Deg2Rad * (transform.eulerAngles.y - 45)) + Mathf.Sin(Mathf.Deg2Rad * (transform.eulerAngles.y - 45));
        c = Mathf.Cos(Mathf.Deg2Rad * (transform.eulerAngles.y - 45)) - Mathf.Sin(Mathf.Deg2Rad * (transform.eulerAngles.y - 45));
        rot = new Vector3d(a, 0, c);
        rot = Vector3d.normalize(rot);

        b = Mathf.Cos(Mathf.Deg2Rad * (transform.eulerAngles.y + 45)) + Mathf.Sin(Mathf.Deg2Rad * (transform.eulerAngles.y + 45));
        d = Mathf.Cos(Mathf.Deg2Rad * (transform.eulerAngles.y + 45)) - Mathf.Sin(Mathf.Deg2Rad * (transform.eulerAngles.y + 45));
        rot2 = new Vector3d(b, 0, d);
        rot2 = Vector3d.normalize(rot2);



        if (Input.GetAxis("Vertical") != 0)
        {
            ver = Input.GetAxis("Vertical");
            playerObje = Particle.MovePlayer(Time.deltaTime * ver * 20 * rot, playerObje);

        }
        if (Input.GetAxis("Horizontal") != 0)
        {
            hor = Input.GetAxis("Horizontal");

            playerObje = Particle.MovePlayer(Time.deltaTime * hor * 20 * rot2, playerObje);

        }

        if (Input.GetAxis("Horizontal") == 0)
        {
            playerObje = Particle.StopForce(Input.GetAxis("Horizontal") * 20 * rot2, playerObje);
        }

        if (playerObje.position.y < 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerObje = Particle.AddForce(new Vector3d(10, 0, 0), playerObje);
        }




    }
}

