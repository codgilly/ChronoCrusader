using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingGun : MonoBehaviour
{

    public float grappleSpeed = 50f;

    public float grappleRaycastDistance = 100f;

    public LayerMask grappleLayers;

    public Transform camera;

    public Transform player;

    public Transform target;

    public bool grappling = false;

    public Vector3 grapplingPoint;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StopGrapple();
            shootGrapplingGun();
        }

    }

    void FixedUpdate()
    {
        if (grappling)
            StartGrapple(grapplingPoint);
    }

    void StartGrapple(Vector3 newPos)
    {

        Vector3 moveVector = newPos - player.position;
        player.GetComponent<CharacterController>().Move(moveVector * grappleSpeed * Time.deltaTime);

        float distanceBetweenPlayerAndGraplePoint = Vector3.Distance(player.position, grapplingPoint);
        if (distanceBetweenPlayerAndGraplePoint <= 3.9f)
        {
            StopGrapple();
        }

    }

    void StopGrapple()
    {
        grappling = false;
    }

    void shootGrapplingGun()
    {

        RaycastHit hit;


        if (Physics.Raycast(camera.position, camera.forward, out hit, grappleRaycastDistance, grappleLayers))
        {
            Debug.DrawLine(camera.position, hit.point, Color.red);

            //hit an object that is grappable
            //now grapple
            grappling = true;
            grapplingPoint = hit.point;

        }

    }

}