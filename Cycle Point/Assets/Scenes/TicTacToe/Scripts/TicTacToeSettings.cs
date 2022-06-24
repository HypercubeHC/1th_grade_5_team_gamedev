using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class TicTacToeSettings : MonoBehaviour {

    [SerializeField]
    private TicTacToeController ticTacToeController;
    [SerializeField]
    private RectTransform canvasRect;
    [SerializeField]
    private Text p1WinsText;
    [SerializeField]
    private Toggle p1AiToggle;
    [SerializeField]
    private Text p2WinsText;
    [SerializeField]
    private Toggle p2AiToggle;
    [SerializeField]
    private Transform settingsPanel;
    [SerializeField]
    private GameObject settingsAiPanel;
    [SerializeField]
    private Text speedSliderText;
    [SerializeField]
    private Slider speedSlider;
    [SerializeField]
    private Text gameOverText;
    [SerializeField]
    private Button startButton;
    [SerializeField]
    private Button endButton;
    [SerializeField]
    private float buttonBlinkSpeed = 4;
    [SerializeField]
    private float buttonBlinkDuration = 2.3f;

    private int totalrounds = 0;
    private int p1Score = 0;
    private int p2Score = 0;

    private Coroutine hideSettingsCoroutine = null;
    private Coroutine showSettingsCoroutine = null;


    private void Start() {
        ticTacToeController.onGameOverDelegate = OnGameOver;
        ticTacToeController.p1Ai = true;
        ticTacToeController.p2Ai = false;
        //StartCoroutine(StartButtonBlinkCoroutine());
    }

    public void CheckIfAnyAiIsActive() {
        settingsAiPanel.SetActive(p1AiToggle.isOn || p2AiToggle.isOn);
    }

    public void OnP1AiToggled(bool active) {
        ticTacToeController.p1Ai = active;
        CheckIfAnyAiIsActive();
    }
    public void OnP2AiToggled(bool active) {
        ticTacToeController.p2Ai = active;
        CheckIfAnyAiIsActive();
    }
    public void OnShortcutsToggled(bool active) {
        ticTacToeController.useShortcuts = active;
    }
    public void OnVisualizeToggled(bool active) {
        ticTacToeController.visualizeAI = active;
        speedSliderText.gameObject.SetActive(active);
        speedSlider.gameObject.SetActive(active);
    }
    public void OnSpeedChanged(float value) {
        ticTacToeController.algorithmStepDuration = value;
        speedSliderText.text = "Step Duration: " + System.Math.Round(value, 2) + "s";
    }

    public void OnStartClicked() {
        startButton.interactable = false;
        gameOverText.text = "";
        ticTacToeController.StartGame();
    }
    private void StopAnimationCoroutines() {
        if (hideSettingsCoroutine != null) {
            StopCoroutine(hideSettingsCoroutine);
            hideSettingsCoroutine = null;
        }
        if (showSettingsCoroutine != null) {
            StopCoroutine(showSettingsCoroutine);
            showSettingsCoroutine = null;
        }
    }

    public void OnGameOver(int win) {

        totalrounds++;
        startButton.interactable = true;
        if (totalrounds >= 4) {
            startButton.gameObject.SetActive(false);
            endButton.gameObject.SetActive(true);
        }
    }
}
