using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DragHandeler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	public static GameObject item;
	Vector3 startPosition;
	public GameObject selectTower;
	private Vector3 curPos;
	Ray r;
	RaycastHit rh;
	bool canInsert;

	#region IBeginDragHandler implementation
	public void OnBeginDrag (PointerEventData eventData)
	{
		PhisicsRaycast ();
		startPosition = transform.position;
		item = Instantiate (selectTower, new Vector3 (curPos.x, 1, curPos.z), Quaternion.identity) as GameObject;

	}
	#endregion

	#region IDragHandler implementation
	public void OnDrag (PointerEventData eventData)
	{
		PhisicsRaycast ();
		item.transform.position = new Vector3 (curPos.x, 0, curPos.z);
		r = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast (r, out rh)) {
			if (rh.transform.tag == "Platform") {
				if (rh.transform.childCount > 0) {
					canInsert = false;
				}
				else {
					
					item.transform.position = new Vector3 (rh.transform.position.x, 1.49f, rh.transform.position.z);
					canInsert = true;
				}
			}
		}
	}
	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	{
		if (canInsert)
		{
			item.transform.SetParent (rh.transform);
			item.transform.localPosition = new Vector3 (0, 1.49f, 0);
			transform.position = startPosition;

		} 
		else 
		{
			Destroy (item);
		}
		item = null;
	}

	private void PhisicsRaycast()
	{
		
		r = Camera.main.ScreenPointToRay (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 1));
		if (Physics.Raycast (r, out rh)) {
			curPos = rh.point;
		}
	}
	#endregion
}
