using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
	public QRCodeDecodeController decodeController;
	private void Awake()
	{
		if (decodeController)
			decodeController.onQRScanFinished += ChangeScene;
	}

	public static void ChangeScene(string text)
	{
		DataParser.DataFromQRCode = text;
		SceneManager.LoadScene("ActionMode");
	}

	public static void ChangeScene()
	{
		SceneManager.LoadScene("QRScanScene");
	}
}
