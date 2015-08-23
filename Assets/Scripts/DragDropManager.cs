using UnityEngine;
using System.Collections;

public class DragDropManager : MonoBehaviour {
	static DragDropManager instance;
	static GameObject currentDragTarget;

	void Awake(){
		instance = this;
	}

	public static void RegisterDragTarget(GameObject dragTarget){
		if(!currentDragTarget){
			currentDragTarget = dragTarget;
			dragTarget.GetComponent<RectTransform>().SetParent(instance.transform);
			dragTarget.transform.localRotation = Quaternion.identity;
			dragTarget.transform.localScale = Vector3.one;
		}
	}

	public static void ResetDragTarget(GameObject dragTarget){
		currentDragTarget = null;
	}

	public static bool IsDragging(){
		return currentDragTarget != null;
	}

	public static GameObject GetDraggedObject(){
		return currentDragTarget;
	}
}
