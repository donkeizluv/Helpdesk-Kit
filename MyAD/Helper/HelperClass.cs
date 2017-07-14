namespace MyAD.Helper
{
    public static class HelperClass
    {
        public static int CalculatePage(int totalRecord, int recordPerPage)
        {
            return totalRecord % recordPerPage > 0 ? (totalRecord / recordPerPage) + 1 : totalRecord / recordPerPage;
        }
    }
}