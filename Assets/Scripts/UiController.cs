using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    [SerializeField] private InputField inputField;
    public void ChangeFinal()
    {
        MovementController.SetFinal(inputField.text);
    }
}
