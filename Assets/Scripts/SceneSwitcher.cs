using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{

    public GameObject button;
    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 150, 100), "Go to Level1"))
            SceneManager.LoadScene("MiniGame");

    }

    
    
    void playGame()
    {
        SceneManager.LoadScene(sceneBuildIndex:1);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
