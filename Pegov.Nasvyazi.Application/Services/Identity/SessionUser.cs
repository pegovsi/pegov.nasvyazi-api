using System;

namespace Pegov.Nasvyazi.Application.Services.Identity
{
    public class SessionUser
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        
        public string UserId { get; set; }
        public string User { get; set; }
        /// <summary>
        /// Время создания токена
        /// </summary>
        
        public DateTime Date { get; set; }
        
        public string Token { get; set; }
        /// <summary>
        /// Время жизни токена
        /// </summary>
        public int Duration { get; set; }
    }
}