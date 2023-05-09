using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public enum ObjectType { TARGET, PLAYER, ENEMY }
    public ObjectType objectType;

    /*Regardless of type, when we hit there will be some behaviors. Mostly UI oriented.*/
    void CommonBehavior()
    {
        Debug.Log("Common_Hit");
    }
    //Some stuff may need to be called on the target (maybe changing colors)
    void TargetBehavior()
    {
        Debug.Log("Target_Hit");
    }

    //Something
    void EnemyBehavior(PrimaryWeaponSO weaponSO) 
    {
        this.gameObject.GetComponent<EnemyManager>().CalculateDamage(weaponSO);
    }
    //Maybe simplify to weaponso later?
    public void HitBehavior(PrimaryWeaponSO weaponSO)
    {
        CommonBehavior();
        if(objectType== ObjectType.ENEMY) 
        {
            EnemyBehavior(weaponSO); 
        }
        if (objectType == ObjectType.TARGET)
        {
            TargetBehavior();
        }
    }
}
