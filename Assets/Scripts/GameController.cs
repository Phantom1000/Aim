using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject targetPrefab;
    [SerializeField] Text countText;
    public GameObject target;
    int count = -1;
    // Start is called before the first frame update
    void Start()
    {
        CreateTarget();
    }
    public void CreateTarget()
    {
        target = Instantiate(targetPrefab, new Vector3(Random.Range(-20, 20), 2, -35), Quaternion.Euler(4, 4, 0));
        countText.text = "Счет: " + ++count;
    }
}
