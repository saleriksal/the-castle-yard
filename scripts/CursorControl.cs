using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorControl : MonoBehaviour
{
    public Vector3 target;
   

    private void Update()
    {
        MouseMovement1();


    }


    public void MouseMovement1()
    {
        target = Input.mousePosition;
        Vector3 mousePosWorld = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, target.y, transform.position.z - Camera.main.transform.position.z));

        Vector3 direction = (mousePosWorld - transform.position).normalized;

        //this fix the wrong way rotation
        direction.y = 0;

        Quaternion targetRotation = Quaternion.LookRotation(direction);

        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
        transform.rotation = Quaternion.Euler(0, targetRotation.eulerAngles.y, 0);

        //transform.up = target - new Vector3(transform.position.x, 0, transform.position.z);
    }

    public void MouseMovement2()
    {
        target = Input.mousePosition;
        Vector3 mousePosWorld = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, target.y, transform.position.z - Camera.main.transform.position.z));

        Vector3 direction = (mousePosWorld - transform.position).normalized;


        direction.y = 0;

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        //transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotation.eulerAngles.y, 1f * Time.deltaTime);
        transform.Rotate(targetRotation.eulerAngles);
       // transform.rotation = Quaternion.Euler(0, targetRotation.eulerAngles.y, 0);

     
    }




}
