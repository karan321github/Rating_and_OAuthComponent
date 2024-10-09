using GoogleAuth.Models;

namespace GoogleAuth.Repository
{
    public static class checkBoxRepository
    {
       

        public static IReadOnlyList<CheckBoxViewModel> GetCourses()
        {
            return new List<CheckBoxViewModel>()  {
            new CheckBoxViewModel
        {
            Id = 1,
            LableName = "Physics",
            isChecked = true
        },
        new CheckBoxViewModel
        {
            Id = 2,
            LableName = "Chemistry",
            isChecked = false
        },
        new CheckBoxViewModel
        {
            Id = 3,
            LableName = "Mathematics",
            isChecked = true
        },
        new CheckBoxViewModel
        {
            Id = 4,
            LableName = "Biology",
            isChecked = false
        },
    };
        }
    }
}
