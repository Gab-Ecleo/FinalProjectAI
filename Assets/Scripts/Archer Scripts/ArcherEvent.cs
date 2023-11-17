using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherEvent : MonoBehaviour
{
    NewAiBehaviour newAiBehaviour;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        newAiBehaviour = GetComponentInParent<NewAiBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShootArrow()
    {

        GameObject arrowFX = Instantiate(newAiBehaviour.Arrow, newAiBehaviour.spawnArcherFX.position, newAiBehaviour.spawnArcherFX.rotation);
        Rigidbody bulletRigidbody = arrowFX.AddComponent<Rigidbody>();

        if (newAiBehaviour.gameObject.tag == "Team2")
            arrowFX.tag = "Team2_Projectile";
        else if (newAiBehaviour.gameObject.tag == "Team1")
            arrowFX.tag = "Team1_Projectile";
        
        
        bulletRigidbody.AddForce(transform.forward * speed, ForceMode.Impulse);
    }
}
