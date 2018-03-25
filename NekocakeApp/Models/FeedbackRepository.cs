namespace NekocakeApp.Models
{
    public class FeedbackRepository : IFeedBackRepository
    {
        private readonly AppDBContext _appContext;

        public FeedbackRepository(AppDBContext appContext)
        {
            _appContext = appContext;
        }

        public void AddFeedback(Feedback feedback)
        {
            _appContext.Feedbacks.Add(feedback);
            _appContext.SaveChanges();
        }
    }
}
