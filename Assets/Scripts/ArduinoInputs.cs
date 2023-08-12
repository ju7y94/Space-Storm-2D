using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;
using UnityEngine.UI;

public class ArduinoInputs : MonoBehaviour
{
    public static SerialPort sp = new SerialPort("COM3", 9600); // Change this to match your Arduino's COM Port.
    Thread readThread = new Thread(ReadData);
    static bool checking = true;
    static float valueY;
    // Start is called before the first frame update
    void Start()
    {
        
        OpenConnection();
        readThread.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnApplicationQuit()
    {
        sp.Close();
        checking = false;
    }
    
    public static float GetYAxis()
    {
        return valueY;
    }

    void OpenConnection()
    {
        sp.Open();
        sp.ReadTimeout = 5000;
        print("Opening port");
    }

    public static void ReadData()
    {
        while (checking)
        {
            try
            {
                string message = sp.ReadLine();
                //potVal = int.Parse(message);
                valueY = float.Parse(sp.ReadLine());
                print(valueY);
            }
            catch
            {
                print("Caught Error!");
            }
        }
    }

    public void SendData(string data)
    {
        sp.Write(data);
        print(data);
    }
}
