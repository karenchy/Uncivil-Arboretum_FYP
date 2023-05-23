using UnityEngine;

public class NumberDebugger
{
	private float valuePreviousForDebugFloatAbsChanging;
	private int counterForDebugFloatAbsChanging;

    public void DebugFloatAbsChanging(float delta, float valueCurrent)
    {
		valueCurrent = Mathf.Abs(valueCurrent);

        if (Mathf.Abs(valuePreviousForDebugFloatAbsChanging - valueCurrent) > delta)
        {
            Debug.Log(
				counterForDebugFloatAbsChanging++ + ". "
				+ "New = " + valueCurrent 
				+ ", Old = " + valuePreviousForDebugFloatAbsChanging);
        }

		valuePreviousForDebugFloatAbsChanging = valueCurrent;
    }
}
