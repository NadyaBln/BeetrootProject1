namespace lesson_13_inheritance_CW
{
    public class Animal
    {
        public string Name { get; set; }
        public int PawsCount { get; set; }
        public int Size { get; set; }

        public virtual void MakeNoize()
        {

        }

        public override int GetHashCode()
        {
            return 0;
        }
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            Animal? animal = obj as Animal;
            if (animal == null)
            {
                return false;
            }
            if (this.Name != animal.Name) return false;
            if (this.Size != animal.Size) return false;
            if (this.PawsCount != animal.PawsCount) return false;

            return true;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
