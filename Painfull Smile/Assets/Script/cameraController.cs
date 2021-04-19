using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    [SerializeField] private GameObject ship;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ship){
        transform.position = Vector3.Lerp(transform.position, new Vector3(ship.transform.position.x, ship.transform.position.y, transform.position.z), Time.deltaTime*2);
        }
    }
}
