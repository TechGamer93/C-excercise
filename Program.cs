using System;
using System.Linq;
using System.Collections.Generic;
					
public class Program
{	
	public static void Main()
	{
		//List 1
		List<Model> p = new List<Model>();
		p.Add(new Model() { name = "Jose", time = 60 });
		p.Add(new Model() { name = "Alberto", time = 120 });
		p.Add(new Model() { name = "Mario", time = 80 });
		
		//List 2
		List<Model> list = new List<Model>();
		list.Add(new Model() { name = "Jose", time = 60 });
		list.Add(new Model() { name = "Alberto", time = 120 });
		list.Add(new Model() { name = "Humberto", time = 600 });
		
		//Combine both lists
		p.AddRange(list);
		
		//Ascendent Order of the list
		List<Model> sorted = p.OrderBy(x => x.time).ToList();
		
		//Delete the duplicates
		HashSet<Model> duples = new HashSet<Model>(sorted);
		List<Model> duplex = duples.ToList();
		
		//Printing the results
		foreach (Model model in duplex)
		{
			Console.WriteLine(model);
		}		
	}
}

public class Model : IEquatable<Model>
{
	public string name { get; set; }
	public int time { get; set; }
	
	public override string ToString()
	{
		return "Name: "+ name + ", Time: "+ time;
	}
	
	public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Model objAsList = obj as Model;
            if (objAsList == null) return false;
            else return Equals(objAsList);
        }
        public override int GetHashCode()
        {
            return time;
        }
        public bool Equals(Model other)
        {
            if (other == null) return false;
            return (this.time.Equals(other.time));
        }
}