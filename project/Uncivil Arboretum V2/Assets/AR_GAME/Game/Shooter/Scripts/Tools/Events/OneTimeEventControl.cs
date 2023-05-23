using UnityEngine;
using UnityEngine.Events;

public class OneTimeEventControl : MonoBehaviour 
{
	public KeyCode oneTimeFunctionKey = KeyCode.Return;
	public UnityEvent OnPressOneTimeFunctionKey;
	private bool isOneTimeFunctionCalled = false;

    void Update() 
	{
        if (!isOneTimeFunctionCalled && Input.GetKeyDown(oneTimeFunctionKey))
		{
			isOneTimeFunctionCalled = true;
            OnPressOneTimeFunctionKey.Invoke();
		}
    }
}
