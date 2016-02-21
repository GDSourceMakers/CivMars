using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class ifStatement : MonoBehaviour {


	public UnityEvent ifTrue;
	public UnityEvent ifFalse;

	public void Activate(bool a)
	{
		if (a)
		{
			ifTrue.Invoke();
		}
		else
		{
			ifFalse.Invoke();
		}
	}
}
