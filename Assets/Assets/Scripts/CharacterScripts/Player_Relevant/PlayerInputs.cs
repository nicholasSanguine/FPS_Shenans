using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    public CharInfo charInfo;
    public WeaponInfo weaponInfo; //Convert to SO soon
    public Rigidbody rigidbody;

    #region Movement Relevant Info
    [Header("Mobility Settings")]
    Vector3 moveDir;
    public float groundedLine = 0.05f;
    public float mouseSensitivity = 1.0f;
    Vector2 mouseDir;
    float xRot, yRot;
    bool Grounded()//Minor upgrade to this would be using it to shift a bool each frame. For now it gets called only on spacebar pressed but in the future more may use it
    {
        Ray ray = new Ray(this.transform.position, -transform.up);
        RaycastHit hit;
        //Debug.DrawRay(this.transform.position,-transform.up, Color.red);
        if (Physics.Raycast(ray, out hit, this.transform.localScale.y + groundedLine))
        {
            //Debug.Log("Player Grounded");
            return true;
        }
        return false;
    }
    
    void SetMovementDirection()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Grounded())
        {
            rigidbody.velocity += new Vector3(0, charInfo.jumpForce);
            Debug.Log("Player Jump");
        }
        if (Input.GetKey(KeyCode.W))
        {
            moveDir += transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDir -= transform.right;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDir -= transform.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDir += transform.right;
        }
    }

    void MovePlayer()
    {
        if (moveDir != Vector3.zero)
        {
            rigidbody.MovePosition(transform.position + moveDir.normalized * charInfo.moveSpeed * Time.deltaTime);
        }
    }
    void RotatePlayer()
    {
        mouseDir = new Vector2(Input.GetAxis("Mouse Y") * -1.0f, Input.GetAxis("Mouse X"));
        xRot += mouseDir.x * mouseSensitivity;
        yRot += mouseDir.y * mouseSensitivity;
        xRot = Mathf.Clamp(xRot, -90.0f, 90.0f);
        Camera.main.transform.rotation = Quaternion.Euler(xRot, yRot, 0.0f);
        transform.rotation = Quaternion.Euler(0, yRot, 0);
    }
    #endregion
   
    #region Weapon/Ability Info
    void CombatInput()
    {
        if(Input.GetKey(KeyCode.Mouse0)) 
        {
            weaponInfo.AttemptShot();//Don't intend on adding a stun of some kind. Statuses would be added to charInfo
        }
        if (Input.GetKey(KeyCode.Mouse1))
        { 
            weaponInfo.AttemptAltFire();//Don't think it'll be adsing for most
        }
    }

    #endregion

    void Start()
    {
        //Little bit of security in case we don't plug it in.
        if(charInfo == null) 
            charInfo = this.GetComponent<CharInfo>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDir = Vector3.zero;
        SetMovementDirection();
        CombatInput();
        RotatePlayer();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

}
