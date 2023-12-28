using Balta.NotificationContext;
using Balta.SharedContext;

namespace Balta.ContentContext
{
    public class CarrerItem : Base
    {
        public CarrerItem(int order,
            string title,
            string descriptions,
            Course course)
        {
            if (course == null)
                AddNotification(new Notification("Course", "Curso inválido"));
            this.Order = order;
            this.Title = title;
            this.Descriptions = descriptions;
            this.CourseCarrer = course;
        }
        public int Order { get; set; }
        public string Title { get; set; }
        public string Descriptions { get; set; }
        public Course CourseCarrer { get; set; }
    }
}