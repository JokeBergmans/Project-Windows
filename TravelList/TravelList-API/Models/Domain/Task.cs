namespace TravelList_API.Models.Domain
{
    public class Task
    {
        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Completed { get; set; }
        #endregion

        #region Constructors
        public Task()
        {

        }
        #endregion
    }
}
