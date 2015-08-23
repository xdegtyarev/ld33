using UnityEngine;

public class DataContainer<T> : ScriptableObject where T: class  {
	public virtual T GetData(){return null;}
}
