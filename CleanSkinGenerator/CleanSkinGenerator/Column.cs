namespace CleanSkinGenerator
{
    public class Column
    {
        public int Index { get; set; }
        public string Name { get; set; }

        public Column()
        {

        }

        public Column(int index, string name)
        {
            Index = index;
            Name = name;
        }
    }
}