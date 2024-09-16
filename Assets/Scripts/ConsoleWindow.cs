using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using TMPro;
using UnityEngine.UI;
public class ConsoleWindow : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ConsoleText;
    private StringBuilder SB = new StringBuilder();
    private void Awake()
    {
        Console.OnConsoleUpdated += UpdateConsole;
    }
    private void UpdateConsole()
    {
       
        ConsoleText.text = Console.GetMessages();
             
    }
}
