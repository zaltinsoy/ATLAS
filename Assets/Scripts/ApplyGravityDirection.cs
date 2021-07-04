using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyGravityDirection : MonoBehaviour
{
    public Particle particleObje2;
    public int gravDirection;
    private int gravForce;

    // Start is called before the first frame update
    void Start()
    {
        particleObje2 = GetComponent<Particle>();
        gravForce = 60;
}

    // Update is called once per frame
    void Update()
    {
        if (gravDirection == 5)
        {
            particleObje2 = Particle.AddForce(new Vector3d(0, gravForce, 0), particleObje2);
        }
        else if (gravDirection == 9)
        {
            particleObje2 = Particle.AddForce(new Vector3d(0, -gravForce, 0), particleObje2);
        }
        else if (gravDirection == 4)
        {
            particleObje2 = Particle.AddForce(new Vector3d(0, 0, gravForce), particleObje2);
        }
        else if (gravDirection == 6)
        {
            particleObje2 = Particle.AddForce(new Vector3d(0, 0, -gravForce), particleObje2);
        }

        else if (gravDirection == 8)
        {
            particleObje2 = Particle.AddForce(new Vector3d(gravForce, 0, 0), particleObje2);
        }
        else if (gravDirection == 2)
        {
            particleObje2 = Particle.AddForce(new Vector3d(-gravForce, 0, 0), particleObje2);
        }

        else if (gravDirection == 7)
        {
            particleObje2.acceleration = new Vector3d(0, 0, 0);
            particleObje2.velocity = new Vector3d(0, 0, 0);
        }


    }
}
