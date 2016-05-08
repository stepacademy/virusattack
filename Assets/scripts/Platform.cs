using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Platform : MonoBehaviour, IDropHandler {

	public bool checkTower;

	#region IDropHandler implementation
	public void OnDrop (PointerEventData eventData)
	{

	}
	#endregion
}
