using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
	[SerializeField] Button[] Buttons;

	void Start()
	{
		Button btn = Buttons[0].GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClickForFirstButton);

		Button btn2 = Buttons[1].GetComponent<Button>();
		btn2.onClick.AddListener(TaskOnClickForSecondButton);

		Button btn3 = Buttons[2].GetComponent<Button>();
		btn3.onClick.AddListener(TaskOnClickForThirdButton);
	}

	void TaskOnClickForFirstButton()
	{
		Debug.Log("You have clicked the first button!");
	}

	void TaskOnClickForSecondButton()
	{
		Debug.Log("You have clicked the second button!");
	}

	void TaskOnClickForThirdButton()
	{
		Debug.Log("You have clicked the third button!");
	}
}
