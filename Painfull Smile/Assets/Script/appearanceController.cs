using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class appearanceController : MonoBehaviour
{
    [SerializeField] private bool player;
    [SerializeField] private bool enemy_1;
    [SerializeField] private bool enemy_2;
    [SerializeField] private float shipLife;
    private float reservedShipLife;
    [SerializeField] private GameObject healthBar;
    [SerializeField] private GameObject healthBarPosition;
    [SerializeField] private GameObject[] hull;
    [SerializeField] private GameObject[] largeSail;
    [SerializeField] private GameObject[] smalSail;
    [SerializeField] private GameObject explosion;
    private Vector3 healthBarScale;
    private Vector3 reservedHealthBarScale;

    // Start is called before the first frame update
    void Start()
    {
        reservedShipLife = shipLife;

        healthBarScale = healthBar.transform.localScale;
        reservedHealthBarScale = healthBarScale;
    }

    // Update is called once per frame
    void Update()
    {
        healthBarScale.y = reservedHealthBarScale.y * (shipLife / 100);

        healthBar.transform.localScale = Vector3.Lerp(healthBar.transform.localScale, healthBarScale, Time.deltaTime);

        healthBarPosition.transform.rotation = Quaternion.Euler(0, 0, -healthBarPosition.transform.rotation.z);

        for(int i = 0; i < hull.Length; i++){
            if(shipLife == reservedShipLife && hull[i] == hull[hull.Length -1]){
                hull[i].SetActive(true);
            }
            else if(shipLife > i*(reservedShipLife/hull.Length) && shipLife < (i+1)*(reservedShipLife/hull.Length)){
                hull[i].SetActive(true);
            }
            else{
                hull[i].SetActive(false);
            }
        }

        for(int i = 0; i < largeSail.Length; i++){
            if(shipLife == reservedShipLife && largeSail[i] == largeSail[largeSail.Length -1]){
                largeSail[i].SetActive(true);
            }
            else if(shipLife > i*(reservedShipLife/largeSail.Length) && shipLife < (i+1)*(reservedShipLife/largeSail.Length)){
                largeSail[i].SetActive(true);
            }
            else{
                largeSail[i].SetActive(false);
            }    
        }

        for(int i = 0; i < smalSail.Length; i++){
            if(shipLife == reservedShipLife && smalSail[i] == smalSail[smalSail.Length -1]){
                smalSail[i].SetActive(true);
            }
            else if(shipLife > i*(reservedShipLife/smalSail.Length)+1 && shipLife < (i+1)*(reservedShipLife/smalSail.Length)+1){
                smalSail[i].SetActive(true);
            }
            else{
                smalSail[i].SetActive(false);
            }
        }

        if(shipLife <= 0 && enemy_1 || shipLife <= 0 && enemy_2){
            FindObjectOfType<stageController_1>().publicPoints += 1;
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if(shipLife <= 0){
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

        private void OnCollisionEnter2D(Collision2D other){
            if(player || enemy_2){
                if(other.gameObject.CompareTag("cannonBall")){
                    shipLife -= 10f;
                }
                if(other.gameObject.CompareTag("enemy_1")){
                    shipLife -= 25f;
                }
            }

        if(other.gameObject.CompareTag("cannonBall") && enemy_1){
            shipLife -= 100f;
        }

        if(other.gameObject.CompareTag("player") && enemy_1 || other.gameObject.CompareTag("enemy_2") && enemy_1){
            shipLife -= 100f;
        }
        

        if(other.gameObject.CompareTag("rockIsland")){
            shipLife -= 5f;
        }
    }
}
