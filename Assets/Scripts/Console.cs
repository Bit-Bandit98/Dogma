using System.Collections.Generic;
using UnityEngine;
using System.Text;
public class Console : MonoBehaviour
{
    private static List<string> Log = new List<string>();
    private static int MaxLines = 10;
    private static string LastMessage;
    public delegate void OnConsole();
    public static OnConsole OnConsoleUpdated;
    public static void LogMessage(string Message)
    {
        ConsoleMessage NewMessage = new ConsoleMessage(Message);
        Log.Insert(0, NewMessage.GetMessage() +"\n");

        
        if (Log.Count >= MaxLines) Log.RemoveAt(Log.Count - 1);
        LastMessage = Log[0];
        InvokeOnConsoleUpdated();
        
    }

    public List<string> GetLog() { return Log; }

    public static string GetMessages()
    {
        StringBuilder TempString = new StringBuilder("");
        for(int i = Log.Count - 1; i >= 0; i--) { 
             
            TempString.Append(Log[i]);
        }
        return TempString.ToString();
    }
    
    public static string GetLastMessage() { return LastMessage; }
    private static void InvokeOnConsoleUpdated() { if (OnConsoleUpdated != null) OnConsoleUpdated.Invoke(); }
}