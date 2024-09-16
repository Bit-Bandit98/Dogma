using System;

public struct ConsoleMessage
{
    private string Message;
    private string CurrentTime;
    private string Sender;


    public ConsoleMessage(string GivenMessage, string GivenSender = "System ")
    {
        Message = GivenMessage;
        CurrentTime = "[" +DateTime.Now.ToString("HH:mm:ss") +"]: ";
        Sender = GivenSender;

    }

    public string GetMessage(){ return Sender + CurrentTime + Message; }
}