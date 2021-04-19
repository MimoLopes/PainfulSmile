using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class mainMenu : MonoBehaviour
{
    [SerializeField] private GameObject otherMenu;

    public void Play(){
        SceneManager.LoadScene (1);
    }

    public void OtherMenu(){
        otherMenu.SetActive(true);
        transform.parent.gameObject.SetActive(false);
    }




}
