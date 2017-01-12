using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneUtil : MonoBehaviour
{
	public string scene;

	public void OpenScene()
	{
		SceneManager.LoadSceneAsync(scene, LoadSceneMode.Single);
	}
}
