using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Primary Weapon Info Important

[CreateAssetMenu(fileName ="Primary_Weapon_Data", menuName = "PrimaryWeaponSO")]
public class PrimaryWeaponSO : ScriptableObject
{
    [Header("Common Values")]
    public float range = 1000.0f;
    public float timeBetweenShots = 0.75f;
    float lastShotTime = 0.0f;
    public int damage = 20;
    public enum WeaponType { RIFLE, SHOTGUN, SMG}
    public WeaponType weaponType;


    public void Started()
    {
        lastShotTime = timeBetweenShots;
    }
    bool CanShoot()//Adding the stats later
    {
        if (Time.time - lastShotTime < timeBetweenShots)
        {
            Debug.Log(Time.time - lastShotTime);
            return false;
        }
        lastShotTime = Time.time;
        return true;
    }

    void ShotBehavior(GameObject hitObject)
    {
        Debug.Log("Call Behavior");
        if (hitObject.GetComponent<TargetManager>() != null)
            hitObject.GetComponent<TargetManager>().HitBehavior(this);
    }

    public void AttemptShot(Transform transform)
    {
        if (CanShoot()) //Choosing hit scan
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hit;
            Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward, Color.red);
            if (Physics.Raycast(ray, out hit, transform.localScale.y + range))
            {
                ShotBehavior(hit.transform.gameObject);
            }
        }
    }

    public void AttemptAltFire()
    {
        if (CanShoot())
        {

        }
    }

}
