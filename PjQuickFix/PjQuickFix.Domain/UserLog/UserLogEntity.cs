using PjQuickFix.Model.Models;
using System;

namespace PjQuickFix.Domain
{
    public class UserLogEntity
    {
        protected internal UserLogEntity
        (
            long userId,
            LogType logType
        )
        {
            UserId = userId;
            LogType = logType;
            DateTime = DateTime.UtcNow;
        }

        public long UserLogId { get; private set; }

        public long UserId { get; private set; }

        public LogType LogType { get; private set; }

        public DateTime DateTime { get; private set; }

        public UserEntity User { get; private set; }
    }
}
