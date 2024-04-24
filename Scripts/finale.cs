using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class finale : MonoBehaviour
{
    public GameObject panelToChange; // Reference to the Panel GameObject you want to modify
    public Sprite sprite1; // Sprite to use when points are below a certain threshold
    public Sprite sprite2; // Sprite to use when points are between the thresholds for sprite1 and sprite2
    public Sprite sprite3; // Sprite to use when points are above a certain threshold
    public TextMeshProUGUI pointsText; // Reference to the TextMeshProUGUI component for displaying points

    void Update()
    {
        // Access the public variable MainMenu.points to determine which sprite to use
        int points = MainMenu.points;

        // Change the sprite of the panel based on the value of points
        if (points < 50)
        {
            ChangePanelSprite(sprite1);
            pointsText.text = "The heroes have taken our lair! We do not have the power to stop them!";
        }
        else if (points < 200)
        {
            ChangePanelSprite(sprite2);
            pointsText.text = "We have stopped the heroes from taking our lair and stopping our plans! Great!";
        }
        else
        {
            ChangePanelSprite(sprite3);
            pointsText.text = "We have obtained so much power that we have converted the heroes evil! Perfect!";
        }
    }

    void ChangePanelSprite(Sprite sprite)
    {
        // Change the sprite of the panel
        if (panelToChange != null)
        {
            Image panelImage = panelToChange.GetComponent<Image>();
            if (panelImage != null)
            {
                panelImage.sprite = sprite;
            }
        }
    }
}
