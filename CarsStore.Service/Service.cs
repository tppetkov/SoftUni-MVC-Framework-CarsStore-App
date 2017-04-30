namespace CarsStore.Service
{
    using CarsStore.Data;

    public abstract class Service
    {
        public Service()
        {
            this.Context=new CarsStoreContext();
        }

        protected CarsStoreContext Context { get; }
    }
}