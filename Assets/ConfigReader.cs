using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System;

public class ConfigReader : MonoBehaviour {
    public string[] lines;
    public string text;
    static FileStream fs;
    private static string path;
    // Use this for initialization
    void Start () {
        path = Path.Combine(Application.dataPath, "config.txt");
        if(!File.Exists(path))
        {
            text = "No File";
        }
        else
        {
            text = "File found";
        }
        //lines = File.ReadAllLines(path);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public int getValueInt(string name)
    {
        for (int i = 0; i < lines.Length; i++)
        {
            string[] s = Regex.Split(lines[i], @"-\s");
            if (s[0] == name)
                return int.Parse(s[1]);
        }
        return 0;
    }
    public void changeValue(string name, int value)
    {
        int counter = 0;
        foreach (string s in lines)
        {
            string[] sp = Regex.Split(s, @"-\s");
            if (sp[0] == name)
            {
                lines[counter] = name + "- " + value;
            }
            counter++;
        }
        File.WriteAllLines(path, lines);
        try
        {
            lines = File.ReadAllLines(path);
        }
        catch (Exception)
        {

            lines = File.ReadAllLines("Config.txt");
        }
    }
    public void readLine()
    {
        text = File.ReadAllLines(path)[0];
    }
    public void writeLine()
    {
        string[] a = new string[1];
        a[0] = "hej";
        File.WriteAllLines(path, a);
    }
    void OnGUI()
    {
        int w = 640, h = 1136;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, 0, w, h * 2 / 50);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 2 / 50;
        style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
        GUI.Label(rect, text, style);
    }
}