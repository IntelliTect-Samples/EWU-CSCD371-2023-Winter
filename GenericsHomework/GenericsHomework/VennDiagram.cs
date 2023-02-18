namespace GenericsHomework
{
    public class VennDiagram<T> where T : class
    {
        // Using HashSet to store the unique items in the circle
        private List<HashSet<T>> circles = new();

        public VennDiagram(int n)
        {
            // Initialize n circles
            for (int i = 0; i < n; i++)
            {
                circles.Add(new HashSet<T>());
            }
        }

        // Returns: true if items is added, false if element is already present in the circle
        public bool AddItem(int circleIndex, T item)
        {
            if (circleIndex < 0 && circleIndex >= circles.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(circleIndex));
            }

            return circles[circleIndex].Add(item);
        }

        // Returns: true if items is found and removed, false if element is not found in the circle
        public bool RemoveItem(int circleIndex, T item)
        {
            if (circleIndex < 0 && circleIndex >= circles.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(circleIndex));
            }

            return circles[circleIndex].Remove(item);
        }

        // Returns: true if items is found in circle, false otherwise
        public bool Contains(int circleIndex, T item)
        {
            if (circleIndex < 0 && circleIndex >= circles.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(circleIndex));
            }

            return circles[circleIndex].Contains(item);
        }
    }
}