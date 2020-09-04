/*
 * Author: Greg Blodgett
 * Class: Game Development
 * Instructor: Dr. McCown
 * Due Date: 9/7/2020
 * Citations:
 *  https://docs.unity3d.com/530/Documentation/ScriptReference/UI.Button-onClick.html
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneSwitcher : MonoBehaviour
{
   // public GameObject timer;
    public GameObject mainMenu;
    public GameObject player;
    public GameObject countText;
    public Button button;
    

    
    //The game has started:
    //  - Bring up the appropriate text boxes
    //  - Disable to plane blocking the camera
    //  - Strt the timer
    void playGame()
    {
        button.gameObject.SetActive(false);
        countText.SetActive(true);
        mainMenu.SetActive(false);
        Debug.Log(GameManager2.timer);
        GameManager2.timer.SendMessage("startTimer");

    }
    // Start is called before the first frame update
    void Start()
    {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(playGame);
        //timer = GameObject.FindWithTag("timer");
    }
    


    // Update is called once per frame
    void Update()
    {
        
    }
}
