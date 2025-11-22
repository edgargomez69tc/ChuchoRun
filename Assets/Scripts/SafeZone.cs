using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour
{
    private GameObject checkPoint;
  

    // Start is called before the first frame update
    void Start()
    {
        checkPoint = GameObject.FindGameObjectWithTag("checkPoint");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            collision.transform.position = checkPoint.transform.position;
            
        }
    }
}
