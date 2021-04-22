using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonController : MonoBehaviour
{
    private GameObject target;
    [SerializeField] private bool player;
    [SerializeField] private bool enemy_2;
    [SerializeField] private GameObject cannonBall;
    [SerializeField] private GameObject cannonFront;
    [SerializeField] private float cannonFrontContdown;
    private float reservedCannonFrontContdown;
    [SerializeField] private GameObject [] cannonR;
    [SerializeField] private float cannonRContdown;
    private float reservedCannonRContdown;
    [SerializeField] private GameObject [] cannonL;
    [SerializeField] private float cannonLContdown;
    private float reservedCannonLContdown;
    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        
        reservedCannonFrontContdown = cannonFrontContdown;
        reservedCannonRContdown = cannonRContdown;
        reservedCannonLContdown = cannonLContdown;
    }

    // Update is called once per frame
    void Update()
    {

        distance = Vector3.Distance(target.transform.position, transform.position);

        if(player){
            if(Input.GetMouseButtonDown(2) && cannonFrontContdown <= 0){
                Instantiate(cannonBall, cannonFront.transform.position, cannonFront.transform.rotation);

                cannonFrontContdown = reservedCannonFrontContdown;
            }
            else{
                cannonFrontContdown -= Time.deltaTime;
            }

            if(Input.GetMouseButtonDown(0) && cannonRContdown <= 0){
                for (int i = 0; i < cannonR.Length; i++){
                Instantiate(cannonBall, cannonR[i].transform.position, cannonR[i].transform.rotation);
                }
                cannonRContdown = reservedCannonRContdown;
            }
            else{
                    cannonRContdown -= Time.deltaTime;
            }

            if(Input.GetMouseButtonDown(1) && cannonLContdown <= 0){
                for (int i = 0; i < cannonL.Length; i++){
                    Instantiate(cannonBall, cannonL[i].transform.position, cannonL[i].transform.rotation);
                }
                cannonLContdown = reservedCannonLContdown;
            }
            else{
                cannonLContdown -= Time.deltaTime;
            } 
        }

        if(enemy_2 && distance < 4){

            if(cannonRContdown <= 0 && gameObject.GetComponentInParent<enemyController>().wichSpot >= 1f){
                for (int i = 0; i < cannonR.Length; i++){
                Instantiate(cannonBall, cannonR[i].transform.position, cannonR[i].transform.rotation);
                }
                cannonRContdown = reservedCannonRContdown;
            }
            else{
                    cannonRContdown -= Time.deltaTime;
            }

            if(cannonLContdown <= 0 && gameObject.GetComponentInParent<enemyController>().wichSpot < 1f){
                for (int i = 0; i < cannonL.Length; i++){
                    Instantiate(cannonBall, cannonL[i].transform.position, cannonL[i].transform.rotation);
                }
                cannonLContdown = reservedCannonLContdown;
            }
            else{
                cannonLContdown -= Time.deltaTime;
            }
        }
    }
}
