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

    string[] dirs = Directory.GetFiles(GameManager.directory, "*.txt");

    //Guardar y Salir
    public void SaveAndQuit()
    {
        if (enunciado.text != "" && correcta.text != "" && incorrecta1.text != "" && incorrecta2.text != "")
        {
            string question = FormatQuestion(enunciado.text,correcta.text,incorrecta1.text,incorrecta2.text);
            GameManager.newThematicQuestions.Add(question);
        }
        SceneManager.LoadScene("QTL");
    }

    public void RemoveQuestion(int index) {

    }

    string FormatQuestion(string q, string r1, string r2, string r3)
    {
        return string.Format(QUESTION_FORMAT, SEPARATOR, q, r1, r2, r3);
    }
}