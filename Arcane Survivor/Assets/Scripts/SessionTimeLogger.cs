using System;
using System.IO;
using UnityEngine;

public class SessionTimeLogger : MonoBehaviour
{
    private float sessionStartTime;
    private string logPath;

    private void Start()
    {
        sessionStartTime = Time.time;
        logPath = Path.Combine(Application.persistentDataPath, "SessionTimes.txt");
        Debug.Log(logPath);

        if (!File.Exists(logPath))
        {
            File.WriteAllText(logPath, "Session Playtime Log\n");
        }
    }

    private void OnApplicationQuit()
    {
        float sessionLength = Time.time - sessionStartTime;
        string logLine = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") +
                         " - Session length: " +
                         sessionLength.ToString("F2") +
                         " seconds";

        File.AppendAllText(logPath, logLine + Environment.NewLine);
    }
}
