using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField] private GameObject healthBar;
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
        transform.Translate(0, shipSpeed, 0);

        if(Input.GetKey(KeyCode.W)){
            shipSpeed = Mathf.Lerp(0, reservedShipSpeed, 0.1f);
        }
        else{
            shipSpeed = Mathf.Lerp(shipSpeed, 0, 0.01f);
        }

        if(Input.GetKey(KeyCode.D)){
            transform.Rotate(new Vector3(0, 0, -shipRotateSpeed));
            healthBar.transform.Rotate(new Vector3(0, 0, shipRotateSpeed));
        }

        if(Input.GetKey(KeyCode.A)){
            transform.Rotate(new Vector3(0, 0, shipRotateSpeed));
            healthBar.transform.Rotate(new Vector3(0, 0, -shipRotateSpeed));
        }
    }
}
