namespace feature_sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var ex_list = new List<ExBase>() {
                new ExSpan(),
            };

            ex_list.ForEach(ex => {
                ex.Exec();
            });
        }
    }

}
