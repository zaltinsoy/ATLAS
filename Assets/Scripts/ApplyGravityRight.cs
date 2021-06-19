using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyGravityRight : MonoBehaviour
{
    public Particle particleObje2;
    // Start is called before the first frame update
    void Start()
    {
        particleObje2 = GetComponent<Particle>();
    }

    // Update is called once per frame
    void Update()
    {
        particleObje2 = Particle.AddForce(new Vector3d(0, 0, 10), particleObje2);
    }
}
