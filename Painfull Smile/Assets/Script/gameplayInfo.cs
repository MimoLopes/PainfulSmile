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
    [System.NonSerialized] public float publicGameTime;

    private float reservedSpawnTime;
    [System.NonSerialized] public float publicSpawnTime;

    // Start is called before the first frame update
    void Start()
    {
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
