using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AppleCountManager appleCounter;
    [SerializeField] private int maxApples = 12;

    [Header("UI Element")]
    [SerializeField] private TMP_Text questionText;

    private int currentAnswer;
    private int previousAnswer = -1;

    public enum OperationType { Addition, Subtraction }
    [SerializeField] private OperationType operation = OperationType.Addition;

    private string operandA;
    private string operandB;
    private string operatorSymbol;

    private bool waitingForNextRound = false;

    private void Start()
    {
        StartNewRound();
    }

    private void Update()
    {
        if (appleCounter == null || waitingForNextRound) return;

        int count = appleCounter.appleCount;

        if (count == currentAnswer)
        {
            Debug.Log("Correct answer!");
            waitingForNextRound = true;

            Invoke(nameof(StartNewRound), 1f);
        }

        if (Input.GetKeyDown(KeyCode.R)) // Force next round manually for debugging
        {
            StartNewRound();
        }
    }

    public void StartNewRound()
    {
        int a, b;

        operation = (Random.value > 0.5f) ? OperationType.Addition : OperationType.Subtraction;

        do
        {
            a = Random.Range(1, maxApples + 1);
            b = Random.Range(1, maxApples + 1);

            currentAnswer = operation == OperationType.Addition ? a + b : a - b;
            Debug.Log($"Trying: {a} {(operation == OperationType.Addition ? "+" : "-")} {b} = {currentAnswer}");
        }
        while (currentAnswer == previousAnswer || currentAnswer < 0 || currentAnswer > maxApples);

        previousAnswer = currentAnswer;

        operandA = a.ToString();
        operandB = b.ToString();
        operatorSymbol = operation == OperationType.Addition ? "+" : "-";

        questionText.text = $"{operandA} {operatorSymbol} {operandB}";
        waitingForNextRound = false;

        Debug.Log($"New question: {questionText.text} = {currentAnswer}");
    }

}