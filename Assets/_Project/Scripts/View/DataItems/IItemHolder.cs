namespace CountersAnalysis
{
    public interface IItemHolder<T>
    {
        public void init(IDataItem<T> item);

        public void create(T data);

        public void remove(T data);
    }
}