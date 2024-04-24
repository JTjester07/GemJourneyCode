using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Question
{
    public string question; // The question text
    public List<string> answers; // List of multiple-choice answers
}

public class TriviaController : MonoBehaviour
{
    public List<Question> questions; // List of questions to be displayed

    public TextMeshProUGUI questionText; // TextMeshPro text for displaying the question
    public List<Button> answerButtons; // List of buttons for multiple-choice answers

    public Canvas correctAnswerCanvas; // Canvas to deactivate on correct answer
    public Canvas incorrectAnswerCanvas; // Canvas to activate on incorrect answer

    private void OnEnable()
    {
        // Ensure there are questions in the list
        if (questions == null || questions.Count == 0)
        {
            Debug.LogError("No questions found!");
            return;
        }

        // Select a random question from the list
        Question randomQuestion = GetRandomQuestion();

        // Display the selected question and answers
        DisplayQuestion(randomQuestion);
    }

    private Question GetRandomQuestion()
    {
        // Select a random question from the list
        int randomIndex = Random.Range(0, questions.Count);
        return questions[randomIndex];
    }

    private void DisplayQuestion(Question question)
    {
        // Display the question text
        questionText.text = question.question;

        // Randomly shuffle the indices of answer buttons
        List<int> buttonIndices = new List<int>();
        for (int i = 0; i < answerButtons.Count; i++)
        {
            buttonIndices.Add(i);
        }
        buttonIndices.Shuffle(); // Custom method to shuffle the list of button indices

        // Display the multiple-choice answers
        for (int i = 0; i < answerButtons.Count; i++)
        {
            int buttonIndex = buttonIndices[i];
            if (i < question.answers.Count)
            {
                // Set button text to the answer at the shuffled index
                answerButtons[buttonIndex].GetComponentInChildren<TextMeshProUGUI>().text = question.answers[i];

                // Add button click listener
                answerButtons[buttonIndex].onClick.RemoveAllListeners(); // Remove existing listeners
                int answerIndex = i; // Capture the current answer index for the lambda expression
                answerButtons[buttonIndex].onClick.AddListener(() => OnAnswerClicked(answerIndex == 0)); // Check if the answer is correct (index 0 is correct)
            }
            else
            {
                // If there are fewer answers than available buttons, deactivate the button
                answerButtons[buttonIndex].gameObject.SetActive(false);
            }
        }
    }


    private void OnAnswerClicked(bool isCorrect)
    {
        if (isCorrect)
        {
            // Correct answer clicked
            correctAnswerCanvas.gameObject.SetActive(false); // Deactivate the original canvas
        }
        else
        {
            // Incorrect answer clicked
            if (incorrectAnswerCanvas != null)
            {
                incorrectAnswerCanvas.gameObject.SetActive(true); // Activate the specified incorrect answer canvas
                Invoke("DeactivateIncorrectCanvas", 3f); // Deactivate after 3 seconds
            }
        }
    }

    private void DeactivateIncorrectCanvas()
    {
        if (incorrectAnswerCanvas != null)
        {
            incorrectAnswerCanvas.gameObject.SetActive(false); // Deactivate the incorrect answer canvas
        }
    }
}

public static class ListExtensions
{
    private static System.Random rng = new System.Random();

    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}


