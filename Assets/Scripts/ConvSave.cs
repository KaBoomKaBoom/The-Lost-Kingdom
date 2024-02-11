using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvSave : MonoBehaviour
{
	public void onButtonClick()
	{
		SaveManager.Save(1, 1, 1);
	}
}
