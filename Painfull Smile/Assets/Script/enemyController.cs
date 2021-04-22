using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{    [SerializeField] private bool enemy_1;
    [SerializeField] private bool enemy_2;
    [SerializeField] private float shipSpeed;
    private float reservedShipSpeed;
    public GameObject target;
    private Rigidbody2D rb;
    private Vector3 rotationZ;
    private float angle;
    private float distance;
    [System.NonSerialized] public float wichSpot;

    // Start is called before the first frame update
    void Start()
    {
        reservedShipSpeed = shipSpeed;
        target = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();

        wichSpot = (Random.Range(0f, 2f));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(shipSpeed * Time.deltaTime, 0, 0);

        rotationZ = target.transform.position - transform.position;
        angle = Mathf.Atan2(rotationZ.y, rotationZ.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    
        distance = Vector3.Distance(target.transform.position, transform.position);
        
        if(enemy_2){
            if(distance < 7.5f){
                if(wichSpot >= 1f){
                    target = GameObject.Find("spot_1");
                }
                else{
                    target = GameObject.Find("spot_2");
                }
            }

            if(distance < 1.5f){
                shipSpeed = 0;
            }
            else{
                shipSpeed = reservedShipSpeed;
            }
        }
    }

}
