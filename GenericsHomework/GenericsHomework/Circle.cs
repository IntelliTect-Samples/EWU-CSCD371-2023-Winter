namespace GenericsHomework;
public class Circle<T> where T : class
{
    public List<T> Items { get; set; }
    public string Label { get; set; }
    public Circle(string label = null!)
    {
        Items = new();
        Label = label ?? "New Circle";
    }
    public override string ToString()
    {
        string result = Label;
        if (Items.Count > 0)
        {
            foreach (T item in Items)
            {
                result += " // " + item.ToString();
            }
        }
        return result;
    }
}
