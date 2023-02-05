using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDetection : MonoBehaviour
{
   public GameObject target = null;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<LeftLine>())
        {
            target = GameObject.FindGameObjectWithTag("Left");
        }
        else if(collision.gameObject.GetComponent<RightLine>())
        {
            target = GameObject.FindGameObjectWithTag("Right");
        }
        else if (collision.gameObject.GetComponent<CenterLiner>())
        {
            target = GameObject.FindGameObjectWithTag("Mid");
        }
    }
}
