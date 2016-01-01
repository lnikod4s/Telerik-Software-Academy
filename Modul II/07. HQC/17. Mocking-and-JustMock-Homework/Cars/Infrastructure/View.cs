namespace Cars.Infrastructure
{
    using Contracts;

    public class View : IView
    {
        public View(object model = null)
        {
            this.Model = model;
        }

        public object Model { get; }
    }
}