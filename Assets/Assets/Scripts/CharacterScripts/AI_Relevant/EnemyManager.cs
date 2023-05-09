using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public CharInfo charInfo;

    public void CalculateDamage(PrimaryWeaponSO weaponSO)
    {
        charInfo.health -= weaponSO.damage;
        Debug.Log(charInfo.health);
    }
}
