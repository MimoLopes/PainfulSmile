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
    [SerializeField] private GameObject playAgainButton;
    [SerializeField] private GameObject mainMenuButton;
    [SerializeField] private GameObject enemy_1;
    [SerializeField] private GameObject enemy_2;
    [SerializeField] private Text pointsText;
    public int publicPoints;
    private float gameTime;
    private float spawnTime;
    private float reservedspawnTime;
    private bool endGame;

    [SerializeField] private float radius = 1;
    // Start is called before the first frame update
    void Start()
    {
        endGame = false;

        gameTime = FindObjectOfType<gameplayInfo>().publicGameTime;
        spawnTime = FindObjectOfType<gameplayInfo>().publicSpawnTime;
        reservedspawnTime = spawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        pointsText.text = "TOTAL " + publicPoints.ToString() + " POINTS!!!";

        gameTime -= Time.deltaTime;
        spawnTime -= Time.deltaTime;

        
        if(spawnTime <= 0 && reservedspawnTime > 0 && gameTime > 0 && !endGame){
            
            float whichEnemy = Random.Range(0, 2f); 

            Vector3 position = Random.insideUnitCircle * radius;

            if(whichEnemy >= 1){
                Instantiate(enemy_1, position, Quaternion.identity);
            }
            else{
                Instantiate(enemy_2, position, Quaternion.identity);
            }
            spawnTime = reservedspawnTime;
        }

        if(player && gameTime <= 0){
            winText.SetActive(true);
            endGame = true;
        }

        if(!player && gameTime > 0){
            gameOverText.SetActive(true);
            endGame = true;
        }

        if(endGame){
            points.SetActive(true);
            playAgainButton.SetActive(true);
            mainMenuButton.SetActive(true);

            Destroy(GameObject.FindObjectOfType<enemyController>());
            Destroy(GameObject.FindObjectOfType<playerController>());
            Destroy(GameObject.FindObjectOfType<cannonController>());
            Destroy(GameObject.FindObjectOfType<bulletController>());
        }
    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public void PlayAgain(){
        SceneManager.LoadScene (1);
    }

    public void MainMenu(){
        SceneManager.LoadScene (0);
    }
}
