using DMSClassLibrary;
using DMSClassLibrary.Containers;
using DMSWeb.Helpers.Interfaces;

namespace DMSWeb.Helpers
{
    public class SystemAccountSession : SessionBase, ISystemAccountSession
    {
        private readonly string id_session_key;
        private readonly string username_session_key;
        private readonly string daycare_id_session_key;
        private readonly string daycare_name_session_key;
        private readonly string access_level_id_session_key;
        private readonly string access_level_session_key;
        private readonly string first_name_session_key;
        private readonly string last_name_session_key;

        public SystemAccountSession(IHttpContextAccessor _httpContextAccessor) : base(_httpContextAccessor)
        {
            id_session_key = "sa_id";
            username_session_key = "sa_username";
            daycare_id_session_key = "sa_daycare_id";
            daycare_name_session_key = "sa_daycare_name";
            access_level_id_session_key = "sa_access_level_id";
            access_level_session_key = "sa_session_access_level";
            first_name_session_key = "sa_first_name";
            last_name_session_key = "sa_last_name";
        }

        public int GetSessionDaycareId()
        {
            return GetSessionIntValue(daycare_id_session_key);
        }

        public string GetSessionDaycareName()
        {
            return GetSessionStringValue(daycare_name_session_key);
        }

        public string GetSessionSystemAccessLevel()
        {
            return GetSessionStringValue(access_level_session_key);
        }

        public int GetSessionSystemAccessLevelId()
        {
            return GetSessionIntValue(access_level_id_session_key);
        }

        public int GetSessionSystemAccountId()
        {
            return GetSessionIntValue(id_session_key);
        }

        public string GetSessionSystemUsername()
        {
            return GetSessionStringValue(username_session_key);
        }

        public string GetSessionUserFirstName()
        {
            return GetSessionStringValue(first_name_session_key);
        }

        public string GetSessionUserLastName()
        {
            return GetSessionStringValue(last_name_session_key);
        }

        public void SetSessionDaycareId(int daycareid)
        {
            SetIntSession(new IntSessionParameter
            {
                Key = daycare_id_session_key,
                Value = daycareid
            });
        }

        public void SetSessionDaycareName(string daycarename)
        {          
            SetStringSession(new StringSessionParameter { 
                Key = daycare_name_session_key,
                Value = daycarename
            });
        }

        public void SetSessionSystemAccessLevel(string access_level)
        {
            SetStringSession(new StringSessionParameter
            {
                Key = access_level_session_key,
                Value = access_level
            });
        }

        public void SetSessionSystemAccessLevelId(int id)
        {
            SetIntSession(new IntSessionParameter
            {
                Key = access_level_id_session_key,
                Value = id
            });
        }

        public void SetSessionSystemAccountId(int id)
        {
            SetIntSession(new IntSessionParameter
            {
                Key = id_session_key,
                Value = id
            });
        }

        public void SetSessionSystemUsername(string username)
        {
            SetStringSession(new StringSessionParameter
            {
                Key = username_session_key,
                Value = username
            });
        }

        public void SetSessionUserFirstName(string first_name)
        {
            SetStringSession(new StringSessionParameter
            {
                Key = first_name_session_key,
                Value = first_name
            });
        }

        public void SetSessionUserLastName(string last_name)
        {
            SetStringSession(new StringSessionParameter
            {
                Key = last_name_session_key,
                Value = last_name
            });
        }
    }
}
