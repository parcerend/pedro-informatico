﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class QuestionFR : MonoBehaviour
{
    private const string QUESTION_FORMAT = "{1}{0}{2}{0}{3}{0}{4}";
    private const string SEPARATOR = "%%%%";


    [SerializeField] TMP_InputField enunciado, correcta, incorrecta1, incorrecta2;

    string[] dirs = Directory.GetFiles("Assets\\Config\\", "*.txt");

    //GUARDA LA PREGUNTA EN EL ARCHIVO
    public void WriteFile()
    {
        string path = "Assets/config/" + GameManager.GameThematic + ".txt";
        //COMO SE ESCRIBE

        string question = FormatQuestion(enunciado.text,correcta.text,incorrecta1.text,incorrecta2.text);
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(question);
        writer.Close();
    }

    //Guardar y Salir
    public void SaveAndQuit()
    {
        WriteFile();
        SceneManager.LoadScene("Settings");
    }

    //Agregar otra pregunta
    public void AddQuestion()
    {
        WriteFile();
        enunciado.text = "";
        correcta.text = "";
        incorrecta1.text = "";
        incorrecta2.text = "";
    }

    string FormatQuestion(string q, string r1, string r2, string r3)
    {
        return string.Format(QUESTION_FORMAT, SEPARATOR, q, r1, r2, r3);
    }
}