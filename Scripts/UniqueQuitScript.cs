using UnityEngine;

public class UniqueQuitScript : MonoBehaviour
{
    private static UniqueQuitScript instance;

    private void Awake()
    {
        // Ensure only one instance of UniqueQuitScript exists
        if (instance == null)
        {
            instance = this;
            // Keep this GameObject alive when loading new scenes
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If another instance exists, destroy this one
            Destroy(gameObject);
            return;
        }
    }

    private void Update()
    {
        // Check for ESC key press
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Quit the application
            Application.Quit();
        }
    }
}

