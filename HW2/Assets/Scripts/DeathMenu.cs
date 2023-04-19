using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour
{
    // Public background image
    public Image backgroundImage;
    private bool isShown = false;
    private float transition = 0.0f;


    // Function to call when the player dies
    public void ToggleEndMenu()
    {
        // Set active true
        gameObject.SetActive(true);
        isShown = true;
    }
    
    // Restart the game when the player clicks the restart button
    public void Restart()
    {
        // Load the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Quit the game when the player clicks the quit button
    public void Quit()
    {
        // Quit the game
        Application.Quit();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        // Set active false
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(!isShown)
            return;
        
        transition += Time.deltaTime;
        backgroundImage.color = Color.Lerp(new Color(0, 0, 0, 0), Color.black, transition);
    }
}
