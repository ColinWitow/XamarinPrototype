using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesLibrary
{
    public class CourseManager
    {
        private readonly Course[] courses;
        int currentIndex = 0;
        int lastIndex;

        public CourseManager()
        {
            courses = InitCourses();
            lastIndex = courses.Length - 1;
        }

        private Course[] InitCourses()
        {
            var initCourses = new Course[]
            {
                new Course()
                {
                    Title = "Android Dev",
                    Description = "Talk about developing Android",
                    Image = "Foothills"
                },
                new Course()
                {
                    Title = "IOS Dev",
                    Description = "Talk about developing IOS",
                    Image = "WQModule"
                },
                new Course()
                {
                    Title = "Windows Dev",
                    Description = "Talk about developing Windows",
                    Image = "SurveyModule"
                }
            };

            return initCourses;

        }

        public void MoveFirst()
        {
            currentIndex = 0;
        }

        public void MovePrev()
        {
            if (currentIndex > 0)
            {
                currentIndex--;
            }
        }

        public void MoveNext()
        {
            if (currentIndex < lastIndex)
            {
                currentIndex++;
            }
        }

        public Course Current
        {
            get { return courses[currentIndex]; }
        }

        public Boolean CanMovePrev
        {
            get { return currentIndex > 0; }
        }

        public Boolean CanMoveNext
        {
            get { return currentIndex < lastIndex; }
        }
    }
}

