// <copyright file="UnitySerialPort.cs" company="dyadica.co.uk">
// Copyright (c) 2010, 2014 All Right Reserved, http://www.dyadica.co.uk

// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY 
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// </copyright>

// <author>SJB</author>
// <email>github@dyadica.co.uk</email>
// <date>04.09.2013</date>
// <summary>A MonoBehaviour type class containing several functions which can be utilised 
// to perform serial communication within Unity3D</summary>

// This code was updated 04.03.2014 to include Notification Events. Please see:
// http://www.dyadica.co.uk/journal/adding-events-to-the-serialport-script for
// more information.

// This code was updated 03.02.2022 to include Notification Events. My website is
// down so please see the readme.md for more information!

using UnityEngine;
using System.Collections;

using System.IO.Ports;
using System;

using System.Threading;

using System.Collections.Generic;

// new Text Mesh Pro text
using TMPro;
using UnityEngine.UI;

public class NewTestScript : MonoBehaviour
{
    // Init a static reference if script is to be accessed by others when used in a 
    // none static nature eg. its dropped onto a gameObject. The use of "Instance"
    // allows access to public vars as such as those available to the unity editor.

    public static NewTestScript Instance;

    #region Properties

    // The serial port

    public SerialPort SerialPort;

    // Thread for thread version of port
    Thread SerialLoopThread;

    [Header("SerialPort")]     //这是标题头

    // Current com port and set of default
    public string ComPort = "COM5";

    // Current baud rate and set of default
    // 300, 600, 1200, 2400, 4800, 9600, 14400, 19200, 28800, 38400, 57600, 115200
    public int BaudRate = 115200;

    // The parity-checking protocol.
    public Parity Parity = Parity.None;

    // The standard number of stopbits per byte.
    public StopBits StopBits = StopBits.One;

    // The standard length of data bits per byte.
    public int DataBits = 8;

    // The state of the Data Terminal Ready(DTR) signal during serial communication.
    public bool DtrEnable;

    // Whether or not the Request to Send(RTS) signal is enabled during serial communication.
    public bool RtsEnable;

    // Holder for status report information

    private string portStatus = "";
    public string PortStatus
    {
        get { return portStatus; }
        set { portStatus = value; }
    }

    // Read and write timeouts

    public int ReadTimeout = 10;
    public int WriteTimeout = 10;

    // Property used to run/keep alive the serial thread loop

    private bool isRunning = false;
    public bool IsRunning
    {
        get { return isRunning; }
        set { isRunning = value; }
    }

    // Set the gui to show ready

    private string rawData = "Ready";
    public string RawData
    {
        get { return rawData; }
        set { rawData = value; }
    }

    // Storage for parsed incoming data

    private string[] chunkData;
    public string[] ChunkData
    {
        get { return chunkData; }
        set { chunkData = value; }
    }

    [Header("GUI Fields")]

    // Refs populated by the editor inspector for default gui
    // functionality if script is to be used in a non-static
    // context.

    public Text ComStatusText;
    public Text RawDataText;
    public Text StatusMsgBox;

    // public TMP_InputField OutputString;

    // Define a delegate for our event to use. Delegates 
    // encapsulate both an object instance and a method 
    // and are similar to c++ pointers.

    public delegate void SerialDataParseEventHandler(string[] data, string rawData);

    // Define the event that utilizes the delegate to
    // fire off a notification to all registered objs 

    public static event SerialDataParseEventHandler SerialDataParseEvent;

    // Delegate and event for serialport open notification

    public delegate void SerialPortOpenEventHandler();
    public static event SerialPortOpenEventHandler SerialPortOpenEvent;

    // Delegate and event for serialport close notification

    public delegate void SerialPortCloseEventHandler();
    public static event SerialPortCloseEventHandler SerialPortCloseEvent;

    // Delegate and event for serialport sentData notification

    public delegate void SerialPortSentDataEventHandler(string data);
    public static event SerialPortSentDataEventHandler SerialPortSentDataEvent;

    // Delegate and event for serialport sentLineData notification

    public delegate void SerialPortSentLineDataEventHandler(string data);
    public static event SerialPortSentLineDataEventHandler SerialPortSentLineDataEvent;

    public enum LoopMethods
    { Threading, Coroutine }

    [Header("Options")]
    [SerializeField]
    public LoopMethods LoopMethod =
        LoopMethods.Coroutine;

    // If set to true then open the port when the start
    // event is called.

    public bool OpenPortOnStart = false;
    public bool ShowDebugs = true;

    // List of all com ports available on the system

    private ArrayList comPorts =
        new ArrayList();

    [Header("Misc")]
    public List<string> ComPorts =
        new List<string>();

    [Header("Data Read")]

    public ReadMethod ReadDataMethod =
        ReadMethod.ReadLine;
    public enum ReadMethod
    {
        ReadLine,
        ReadToChar
    }

    public string Delimiter;
    public char Separator;

    #endregion Properties


}
