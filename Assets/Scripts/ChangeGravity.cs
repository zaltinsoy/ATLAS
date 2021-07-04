using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGravity : MonoBehaviour
{
    public Particle particleObje;
    public int gravDirection;
    private int gravForce;
    public string dirType;
    void Start()
    {
        particleObje = GetComponent<Particle>();
        gravForce = 80;
    }

    // Update is called once per frame
    void Update()
    {
        if (dirType == "ver" || dirType == "all")
        {

            if (gravDirection == 5)
            {
                particleObje = Particle.AddForce(new Vector3d(0, gravForce, 0), particleObje);
            }
            else if (gravDirection == 9)
            {
                particleObje = Particle.AddForce(new Vector3d(0, -gravForce, 0), particleObje);
            }
        }
        if (dirType == "hor" || dirType == "all")
        {
            if (gravDirection == 4)
            {
                particleObje = Particle.AddForce(new Vector3d(0, 0, gravForce), particleObje);
            }
            else if (gravDirection == 6)
            {
                particleObje = Particle.AddForce(new Vector3d(0, 0, -gravForce), particleObje);
            }

            else if (gravDirection == 8)
            {
                particleObje = Particle.AddForce(new Vector3d(gravForce, 0, 0), particleObje);
            }
            else if (gravDirection == 2)
            {
                particleObje = Particle.AddForce(new Vector3d(-gravForce, 0, 0), particleObje);
            }

        }

        if (gravDirection == 7)
        {
            particleObje.acceleration = new Vector3d(0, 0, 0);
            particleObje.velocity = new Vector3d(0, 0, 0);
        }

    }
}
