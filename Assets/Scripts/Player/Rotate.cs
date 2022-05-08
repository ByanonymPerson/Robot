using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
        Vector3 pos;
        Camera main;
 
 
 
    // Start is called before the first frame update
    private void Start()
    {
        main = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
         Flip();
         pos = main.WorldToScreenPoint(transform.position);
    }

    void Flip(){
         if(Input.mousePosition.x < pos.x)
         {
             transform.localRotation = Quaternion.Euler(0 , 180 , 0);
         }

         if(Input.mousePosition.x > pos.x)
         {
             transform.localRotation = Quaternion.Euler(0 , 0 , 0);
         }
    }
}
