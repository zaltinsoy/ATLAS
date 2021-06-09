using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyGravityUp : MonoBehaviour
{
    public Particle particleObje;
    // Start is called before the first frame update
    void Start()
    {
        particleObje = GetComponent<Particle>();
    }

    // Update is called once per frame
    void Update()
    {
        particleObje = Particle.AddForce(new Vector3d(0, 0.1, 0), particleObje);
    }
}
