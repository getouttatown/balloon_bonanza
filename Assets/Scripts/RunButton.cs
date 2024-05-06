using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RunButton : MonoBehaviour
{
    private bool running = false;
    private ColorBlock cb;
    public Button m_RunButton;
    private TMP_Text m_Text;

    void Awake()
    {
        m_Text = m_RunButton.GetComponentInChildren<TMP_Text>();
        cb = m_RunButton.colors;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_RunButton.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if (!running) {
            m_Text.text = "Stop";
            cb.normalColor = new Color(255, 0, 0);
            cb.pressedColor = new Color(255, 0, 0);
            cb.selectedColor = new Color(255, 0, 0);
            m_RunButton.colors = cb;
            running = true;
            
            FindObjectOfType<GameManager>().RunLevel();
        }
        else {
            m_Text.text = "Run";
            cb.normalColor = new Color(0, 255, 0);
            cb.pressedColor = new Color(0, 255, 0);
            cb.selectedColor = new Color(0, 255, 0);
            m_RunButton.colors = cb;
            running = false;
            
            FindObjectOfType<GameManager>().StopLevel();
        }
    }
}
