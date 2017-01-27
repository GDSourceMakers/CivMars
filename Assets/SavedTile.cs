using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[Serializable]
public class SavedTile
{
	public string ID;
	public Dictionary<string, SavedData> datas = new Dictionary<string, SavedData>();

	public SavedTile(string id)
	{
		this.ID = id;
	}
}

[Serializable]
public class SavedData
{
}

[Serializable]
public class SavedOre : SavedTile
{
	public int amount;

	public SavedOre(string id,int am):base(id)
	{
		ID = id;
		amount = am;
	}
}

