using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    [SerializeField] float speed;
    Vector3 beginPoint;
    Vector3 endPoint;
    // Start is called before the first frame update
    void Start()
    {
        beginPoint = new Vector3(20, transform.position.y, transform.position.z);
        endPoint = new Vector3(-20, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((speed > 0 && Vector3.Distance(transform.position, beginPoint) < 3)
        || (speed < 0 && Vector3.Distance(transform.position, endPoint) < 3)) speed = -speed;
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + speed,
            transform.position.y, transform.position.z), Time.fixedDeltaTime);
    }
}
