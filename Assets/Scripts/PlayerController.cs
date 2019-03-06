using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float velocity;
    [SerializeField] GameObject spawn;
    [SerializeField] GameObject corePrefab;
    [SerializeField] GameObject gameManager;
    [SerializeField] float reload = 0;

    void Update() {
        reload += Time.deltaTime;
        Vector3 targetPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
        targetRotation = Quaternion.Euler(targetRotation.eulerAngles.x - 55, targetRotation.eulerAngles.y*10, targetRotation.eulerAngles.z);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
        //transform.LookAt(targetPoint);
        if (Input.GetMouseButtonDown(0) && (reload >= 1))
        {
            GameObject core = Instantiate(corePrefab, spawn.transform.position, spawn.transform.rotation);
            core.GetComponent<Rigidbody>().AddForce(spawn.transform.up * velocity, ForceMode.Impulse);
            core.GetComponent<CoreController>().target = gameManager.GetComponent<GameController>().target;
            core.GetComponent<CoreController>().gameManager = gameManager;
            Destroy(core, 5);
            reload = 0;
        }
    }
}
