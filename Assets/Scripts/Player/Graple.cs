using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graple : MonoBehaviour
{
    // Start is called before the first frame update
    private LineRenderer LineRender;
    private Vector3 grapplePoint;
    public LayerMask IsGrappleable;
    public Transform RayGunTip,camera,player;
    public float maxDistance = 100f;
    private SpringJoint joint;

    private void Awake() {
        LineRender = GetComponent<LineRenderer>();
    }


    
    // Update is called once per frame
    private void Update(){
        if(Input.GetMouseButtonDown(0)){
            StartGrapple();
        }
           else if (Input.GetMouseButtonUp(0)){
                StopGrapple();       
        }
                 
    }

     private void LateUpdate() {
         DrawRope();        
    }

    void StartGrapple(){
        RaycastHit hit;
        if (Physics.Raycast(camera.position,camera.forward,out hit,maxDistance,IsGrappleable)){
             grapplePoint = hit.point;
             joint = player.gameObject.AddComponent<SpringJoint>();
             joint.autoConfigureConnectedAnchor = false;
             joint.connectedAnchor = grapplePoint ;

             float distanceFromPoint = Vector3.Distance (player.position, grapplePoint);

             joint.maxDistance = distanceFromPoint * 0.8f;
             joint.minDistance = distanceFromPoint * 0.25f;

             joint.spring = 4.5f;
             joint.damper = 7f;
             joint.massScale = 4.5F;
        }
    }

    void DrawRope(){
        LineRender.SetPosition(0,RayGunTip.position);
        LineRender.SetPosition(1,grapplePoint);
    }

    void StopGrapple(){

    }
}
