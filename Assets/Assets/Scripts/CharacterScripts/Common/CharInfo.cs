using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharInfo : MonoBehaviour
{
    [Header("Movement Data")]
    public float moveSpeed = 3.0f;
    public float jumpForce = 10.0f,  sprintMod = 2.0f;
    public float gravity = 9.8f, airMod = 0.25f;//Tune in air movement more later

    public float health = 100.0f;

}
