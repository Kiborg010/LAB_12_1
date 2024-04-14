namespace LAB_12
{
    public class Point<T>
    {
        public T? Data { get; set; }
        public Point<T>? Next { get; set; }
        public Point<T>? Previous { get; set; }

        public Point()
        {
            this.Data = default(T);
            this.Previous = null;
            this.Next = null;
        }

        public Point(T data)
        {
            this.Data = data;
            this.Previous = null;
            this.Next = null;
        }
    }
}