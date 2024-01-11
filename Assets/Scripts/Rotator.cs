using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Rotator : MonoBehaviour
{
    [SerializeField][Range(-360, 360)] float angle;
//    [SerializeField][Range(2, 20)] float speed = 5;

    // Update is called once per frame
    void Update()
    {
        //transform.rotation *= Quaternion.AngleAxis(angle * Time.deltaTime, Vector3.up);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            //transform.position += transform.forward * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.rotation *= Quaternion.AngleAxis(-1 * angle * Time.deltaTime, Vector3.up);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation *= Quaternion.AngleAxis(angle * Time.deltaTime, Vector3.up);
        }
    }
}
