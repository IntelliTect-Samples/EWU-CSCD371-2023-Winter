namespace GenericsHomework;
public class VennDiagram<Circle>
{
    public List<Circle> Circles { get; set; }
    public string Title { get; set; }

    public VennDiagram(string title = null!)
    {
        Circles = new();
        Title = title ?? "New Venn Diagram";
    }

    override public string ToString()
    {
        string result = Title;
        if (Circles.Count > 0)
        {
            foreach (Circle circ in Circles)
            {
                result += "\n" + circ!.ToString();
            }
        }
        return result;
    }
}