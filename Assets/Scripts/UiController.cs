﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    [SerializeField] private InputField inputField;
    public void ChangeFinal()
    {
        print("fdhg");
        MovementController.SetFinal(inputField.text);
    }
}
