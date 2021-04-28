using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class gameplayInfo : MonoBehaviour
{
    [SerializeField] private GameObject options;
    [SerializeField] private Text gameTime;
    [SerializeField] private Text spawnTime;

    private float reservedGameTime;
    public float publicGameTime;

    private float reservedSpawnTime;
    public float publicSpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < Object.FindObjectsOfType<gameplayInfo>().Length; i++){
            if(Object.FindObjectsOfType<gameplayInfo>()[i] != this){
                if (Object.FindObjectsOfType<gameplayInfo>()[i].name == gameObject.name){
                    Destroy(gameObject);
                }
            }
        }
        DontDestroyOnLoad (transform.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0){
            if(options.activeSelf){
            float.TryParse(gameTime.text, out reservedGameTime);
            publicGameTime = reservedGameTime;

            float.TryParse(spawnTime.text, out reservedSpawnTime);
            publicSpawnTime = reservedSpawnTime;
            }
        }
    }
}
