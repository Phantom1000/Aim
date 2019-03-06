using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreController : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject target;
    void OnTriggerEnter(Collider other) {
        if (other.gameObject == target)
        {
            Destroy(other.gameObject);
            gameManager.GetComponent<GameController>().CreateTarget();
        }
    }
}
