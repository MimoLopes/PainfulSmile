using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    [SerializeField] private GameObject explosion;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float bulletTime;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
            transform.Translate(bulletSpeed * Time.deltaTime, 0, 0);
            
            Destroy(gameObject, bulletTime);
    }

    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("player") || other.gameObject.CompareTag("enemy_1") || other.gameObject.CompareTag("enemy_2")){
            Destroy (this.gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
        }
    }
}
