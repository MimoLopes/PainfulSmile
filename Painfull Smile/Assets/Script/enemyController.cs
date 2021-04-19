using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    [SerializeField] private GameObject healthBar;
    [SerializeField] private bool enemy_1;
    [SerializeField] private bool enemy_2;
    [SerializeField] private float shipSpeed;
    private float reservedShipSpeed;
    [SerializeField] private float rotateSpeed;
    private GameObject target;
    private Rigidbody2D rb;
    private Vector3 rotationZ;
    private float angle;
    public float wichSpot;

    [SerializeField] private float distance;


    // Start is called before the first frame update
    void Start()
    {
        reservedShipSpeed = shipSpeed;
        target = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
            transform.Translate(shipSpeed, 0, 0);

            rotationZ = target.transform.position - transform.position;
            angle = Mathf.Atan2(rotationZ.y, rotationZ.x) * Mathf.Rad2Deg;
            rb.rotation = angle;

            healthBar.transform.Rotate(0, 0, -healthBar.transform.rotation.z);

        if(enemy_2){
            distance = Vector3.Distance(target.transform.position, transform.position);

            if(distance < 1f){
                shipSpeed = 0;
            }
            else{
                shipSpeed = reservedShipSpeed;
            }

            if(distance < 7.5f){
                wichSpot = (Random.Range(0, 1));

                if(wichSpot > 1f){
                    target = GameObject.Find("spot_1");
                }
                else{
                    target = GameObject.Find("spot_2");
                }
            }
        }
    }

}
