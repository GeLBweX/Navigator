using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    [SerializeField] private InputField inputField;
	[SerializeField] MovementController movementController;
    public void ChangeFinal()
    {
		movementController.SetFinal(inputField.text);
    }

	public void ChangeSceneToQRRead()
	{
		SceneController.ChangeScene();
	}
}
