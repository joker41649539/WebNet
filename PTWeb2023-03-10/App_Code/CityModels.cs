using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class City
{
    public int id { get; set; }
    public string name { get; set; }
    public int parent { get; set; }
}

public class TreeViewItem
{
    public string name { get; set; }
    public string type { get; set; }
    public additionalParameter additionalParameters { get; set; }
}

public class additionalParameter
{
    public int id { get; set; }
    public bool children { get; set; }
}