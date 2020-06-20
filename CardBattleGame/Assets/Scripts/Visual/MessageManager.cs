using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MessageManager : MonoBehaviour
{
    public Text MessageText;
    public GameObject MessagePanel;
    public static MessageManager Instance;

    private void Awake()
    {
        Instance = this;
        MessagePanel.SetActive(false);
    }

    public void ShowMessage(string message, float duration)
    {
        StartCoroutine(ShowMessageCoroutine(message, duration));
    }

    private IEnumerator ShowMessageCoroutine(string message, float duration)
    {
        MessageText.text = message;
        MessagePanel.SetActive(true);

        yield return new WaitForSeconds(duration);

        MessagePanel.SetActive(false);
        // TODO Command.CommandExecutionComplete();
    }

    // TEST PURPOSE ONLY
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
            ShowMessage("Your Turn", 3f);

        if (Input.GetKeyDown(KeyCode.E))
            ShowMessage("Enemy Turn", 3f);
    }
}
