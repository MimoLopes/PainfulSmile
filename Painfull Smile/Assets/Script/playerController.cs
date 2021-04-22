using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField] private float shipSpeed;
    private float reservedShipSpeed;
    [SerializeField] private float shipRotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        reservedShipSpeed = shipSpeed;
        shipSpeed = 0;
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(0, shipSpeed * Time.deltaTime, 0);

        if(Input.GetKey(KeyCode.W)){
            shipSpeed = reservedShipSpeed;
        }
        else{
            shipSpeed = Mathf.Lerp(shipSpeed, 0, Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.D)){
            transform.Rotate(new Vector3(0, 0, -shipRotateSpeed * Time.deltaTime));
        }

        if(Input.GetKey(KeyCode.A)){
            transform.Rotate(new Vector3(0, 0, shipRotateSpeed * Time.deltaTime));
        }
    }
}
