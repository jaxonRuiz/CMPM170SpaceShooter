using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class KeyDetector : MonoBehaviour
{
    public Key which;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (Keyboard.current[which].isPressed)
        {
            GetComponent<TextMeshProUGUI>().color = Color.red;
        }
       else
        {
            GetComponent<TextMeshProUGUI>().color = Color.white;
        }
    }
}
