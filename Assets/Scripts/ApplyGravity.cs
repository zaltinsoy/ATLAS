using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyGravity : MonoBehaviour
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
        particleObje = Particle.AddForce(new Vector3d(0, -10, 0), particleObje);
        //Vector3d a= Vector3d.normalize(particleObje.position);
     //  / Debug.Log("x" + a.x);
       // Debug.Log("y" + a.y);
       // Debug.Log("z" + a.z);
    }
}
