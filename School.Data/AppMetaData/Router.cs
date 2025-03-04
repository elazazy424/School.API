namespace School.Data.AppMetaData
{
    public static class Router
    {
        public const string singleRoute = "/{id}";
        public const string root = "Api";
        public const string version = "V1";
        public const string rule = root + "/" + version + "/";

        public static class studentRouting
        {
            public const string Prefix = rule + "Student";
            public const string List = Prefix + "/List";
            public const string GetById = Prefix + singleRoute;
            public const string Create = Prefix + "/Create";
            public const string Edit = Prefix + "/Edit";
            public const string Delete = Prefix + "/{id}";
            public const string Paginated = Prefix + "/Paginated";
        }
        public static class DepartmentRouting
        {
            public const string Prefix = rule + "Department";
            public const string GetById = Prefix + "/Id";
        }
        public static class ApplicationUserRouting
        {
            public const string Prefix = rule + "ApplicationUser";
            public const string AddUser = Prefix + "/Create";
            public const string Paginated = Prefix + "/Paginated";
            public const string GetById = Prefix + singleRoute;
        }
    }
}
