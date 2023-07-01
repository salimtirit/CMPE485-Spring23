using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DeathMenu : MonoBehaviour
{
    // Public background image
    public Image backgroundImage;
    private bool isShown = false;
    private float transition = 0.0f;

    // Public text to display when the player dies
    public TextMeshProUGUI gameOverText;

    // Function to call when the player dies
    public void ToggleEndMenu(string text)
    {
        // Show cursor when the player dies
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        // Set active true
        gameObject.SetActive(true);
        isShown = true;
        gameOverText.text = text;
    }

    // Restart the game when the player clicks the restart button
    public void Restart()
    {
        Debug.Log("Restart");
        // Load the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Quit the game when the player clicks the quit button
    public void Quit()
    {
        Debug.Log("Quit");
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
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
        if (!isShown)
            return;

        transition += Time.deltaTime;
        backgroundImage.color = Color.Lerp(new Color(0, 0, 0, 0), Color.black, transition);
    }
}
