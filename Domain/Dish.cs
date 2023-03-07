namespace Domain
{
    /// <summary>
    /// Dish available by daytime menu. Contains a dish by name, number of times the dish has been ordered, 
    /// dish type and information if multiple order of the dish is allowed
    /// </summary>
    public class Dish
    {
        public Menu Menu { get; set; }
        public int Id { get; set; }
        public string DishName { get; set; }
        public int Count { get; set; }
        public Course Course { get; set; }
        public bool MultipleOrderAllowed { get; private set; }

        public Dish() {}
        public Dish(Menu menu, int id, string dishName, Course course, bool multipleOrderAllowed)
        {
            Menu = menu;
            Id = id;
            DishName = dishName;
            Course = course;
            MultipleOrderAllowed = multipleOrderAllowed;
        }

    }


    /// <summary>
    /// Course - Type of Dish
    /// </summary>
    public enum Course
    {
        entree,
        side,
        drink,
        dessert
    }
}