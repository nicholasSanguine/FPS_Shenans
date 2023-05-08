using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInfo : MonoBehaviour
{
    public float range = 10000.0f;

    bool CanShoot()//Default true, adding the stats later
    {
        return true;
    }

    void ShotBehavior(GameObject hitObject)
    {
        Debug.Log("Call Behavior");
    }

    public void AttemptShot()
    {
        if(CanShoot()) //Choosing hit scan
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hit;
            Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward, Color.red);
            if (Physics.Raycast(ray, out hit, this.transform.localScale.y + range))
            {
                ShotBehavior(hit.transform.gameObject);
            }
        }
    }

    public void AttemptAltFire()
    {
        if(CanShoot())
        { 
        
        }
    }
}
