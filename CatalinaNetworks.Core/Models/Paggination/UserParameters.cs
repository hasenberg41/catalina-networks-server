namespace CatalinaNetworks.Core.Models.Paggination
{
    public class UserParameters
    {
        const int maxPageSize = 50;
        private int _pageSize = 10;

        public int PageNumber { get; set; } = 1;
        public int PageSize
        {
            get => _pageSize; set
            {
                if (value <= 0)
                {
                    _pageSize = 1;
                }
                else if (value > maxPageSize)
                {
                    _pageSize = maxPageSize;
                }
                else
                {
                    _pageSize = value;
                }
            }
        }
    }
}
