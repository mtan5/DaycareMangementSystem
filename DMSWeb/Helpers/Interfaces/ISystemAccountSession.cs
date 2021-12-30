namespace DMSWeb.Helpers.Interfaces
{
    public interface ISystemAccountSession
    {
        void SetSessionSystemAccountId(int id);
        void SetSessionSystemUsername(string username);
        void SetSessionSystemAccessLevelId(int id);
        void SetSessionSystemAccessLevel(string access_level);
        void SetSessionDaycareId(int daycareid);
        void SetSessionDaycareName(string daycarename);
        void SetSessionUserFirstName(string first_name);
        void SetSessionUserLastName(string last_name);
        int GetSessionSystemAccountId();
        string GetSessionSystemUsername();
        int GetSessionSystemAccessLevelId();
        string GetSessionSystemAccessLevel();
        string GetSessionUserFirstName();
        string GetSessionUserLastName();
        int GetSessionDaycareId();
        string GetSessionDaycareName();
    }
}
