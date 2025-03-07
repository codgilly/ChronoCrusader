using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dashing : MonoBehaviour
{
    private CharacterController characterController;

    public float dashCount = 0;
    public float maxDashCount = 2;
    public float dashLength = 7.5f;
    public float dashSpeed = 30;
    public float dashTime = 3;
    public float dashCoolDown = 1.5f;
    public float dashTimmer;

    public Image dash1;
    public Image dash2;

    public Color dashColor;
    public Color dashColorDark;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();

        dashTimmer = dashCoolDown;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashCount < maxDashCount)
        {

            StartCoroutine(DashCorutine());
        }
        if (dashCount > 0)
        {
            DashReset();
        }
        else
        {
            dashCount = 0;
        }

        if (dashCount == 1 || dashCount == 2)
        {
            dashTimmer -= Time.deltaTime;
        }

        if(dashCount == 1)
        {
            dash1.color = dashColorDark;
            dash2.color = dashColor;
        }

        if( dashCount == 2)
        {
            dash2.color = dashColorDark;
        }

        if (dashCount == 0)
        {
            dash1.color = dashColor;
            dash2.color = dashColor;
        }
    }

    private IEnumerator DashCorutine()
    {
       
        dashCount++;
        float startTime = Time.time;
        while (startTime + dashTime > Time.time)
        {
            Vector3 moveDirection = transform.forward * dashLength;
            characterController.Move(moveDirection * Time.deltaTime * dashSpeed);
            yield break;
        }
    }

    void DashReset()
    {
        if(dashTimmer <= 0)
        {
            dashCount -= 1;
            dashTimmer = dashCoolDown;
            //return;
        }
       
    }


}
