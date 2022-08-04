using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game_Behaviour : MonoBehaviour
{
    public float _timeStart = 30f;

    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private GameObject _restartButton;

    void Start()
    {
        Time.timeScale = 1.0f;
        _restartButton.SetActive(false);
        _timerText.text = _timeStart.ToString();
    }
   
    void Update()
    {
        _timeStart -= Time.deltaTime;
        _timerText.text = Mathf.Round(_timeStart).ToString();
        if (Mathf.Round(_timeStart) <= 0 || !(GameObject.FindGameObjectWithTag("Enemy"))) {
            Time.timeScale = 0.0f;
            _restartButton.SetActive(true);
        }
    }

    public void Restart() {
        SceneManager.LoadScene(0);
    }
}
