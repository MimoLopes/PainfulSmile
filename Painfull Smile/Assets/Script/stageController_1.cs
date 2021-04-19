using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class stageController_1 : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject gameOverText;
    [SerializeField] private GameObject winText;

    [SerializeField] private GameObject points;
    [SerializeField] private Text pointsText;
    [SerializeField] private GameObject playAgainButton;
    [SerializeField] private GameObject mainMenuButton;
    [SerializeField] private GameObject enemy_1;
    [SerializeField] private GameObject enemy_2;
    public int publicPoints;
    private float gameTime;
    private float reservedGameTime;
    private float spawnTime;
    private float reservedspawnTime;

    [SerializeField] private float radius = 1;
    // Start is called before the first frame update
    void Start()
    {
        gameTime = FindObjectOfType<gameplayInfo>().publicGameTime;
        spawnTime = FindObjectOfType<gameplayInfo>().publicSpawnTime;
        reservedGameTime = gameTime;
        reservedspawnTime = spawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        pointsText.text = "TOTAL " + publicPoints.ToString() + " POINTS!!!";

        gameTime -= Time.deltaTime;
        spawnTime -= Time.deltaTime;

        
        if(spawnTime <= 0 && reservedspawnTime > 0){
            
            float whichEnemy = Random.Range(0, 2f); 

            Vector3 position = Random.insideUnitCircle * radius;

            if(whichEnemy > 1){
                Instantiate(enemy_1, position, Quaternion.identity);
            }
            else{
                Instantiate(enemy_2, position, Quaternion.identity);
            }
            spawnTime = reservedspawnTime;
        }

        if(gameTime <= 0 && player.activeSelf){
            winText.SetActive(true);
            points.SetActive(true);
            playAgainButton.SetActive(true);
            mainMenuButton.SetActive(true);
        }
        if(gameTime > 0 && !player.activeSelf){
            gameOverText.SetActive(true);
            points.SetActive(true);
            playAgainButton.SetActive(true);
            mainMenuButton.SetActive(true);
        }
    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public void PlayAgain(){
        gameTime = reservedGameTime;
        SceneManager.LoadScene (1);
    }

    public void MainMenu(){
        SceneManager.LoadScene (0);
    }
}
